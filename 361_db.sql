/* User, password, name are reserved words, so we have to make sure we use quotes when using those */
drop table if exists "Item";
drop table if exists "List";
drop table if exists "User";

create table "User" (
	userId int identity(1,1) primary key not null,
	"email" varchar(255) not null unique,
	"password" varchar(100) not null,
	"nickName" varchar(255),
);

create table "List" (
	listId int identity(1,1) primary key not null,
	"name" varchar(100) not null,
	userId int foreign key references "User"(userId) not null,
	constraint "listName-userId" unique ("name", userId) /* This alows diffent users to have lists of the same name */
);

create table "Item" (
	itemId int identity(1,1) primary key not null,
	"name" varchar(100) not null,
	"quantity" int,
	listId int foreign key references "List"(listId) not null,
	constraint "itemName-listId" unique ("name", listId) /* This alows diffent lists to have items of the same name */
);

/* These are test data inserts for unit tests*/
insert into "User" ("email", "password", "nickName") values ('email', 'password', 'nick');
insert into "List" ("name", userId) values ('List 1', (select userId from "User" where "email" = 'email'));
insert into "List" ("name", userId) values ('List 2', (select userId from "User" where "email" = 'email'));
Insert into "Item" ("name", listId) values ('Item 1', (select listId from "List" where "name" = 'List 1'));
Insert into "Item" ("name", listId) values ('Item 2', (select listId from "List" where "name" = 'List 1'));
Insert into "Item" ("name", listId) values ('Item 3', (select listId from "List" where "name" = 'List 2'));