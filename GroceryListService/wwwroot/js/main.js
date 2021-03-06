﻿


var firebaseConfig = {
    apiKey: "AIzaSyAIaP23D9UAPtZnKDkTYayUfaBTbATgEgc",
    authDomain: "testingksp.firebaseapp.com",
    databaseURL: "https://testingksp.firebaseio.com",
    projectId: "testingksp",
    storageBucket: "testingksp.appspot.com",
    messagingSenderId: "492086351194",
    appId: "1:492086351194:web:46c92d46cbd21c7bba8f63",
    measurementId: "G-66FLPL7LNP"
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);

firebase.auth().onAuthStateChanged(function (user) {
    if (user) {
        email = user.email;
        document.getElementById("LogIn").innerText = email;
     } else {
        document.getElementById("LogIn").innerText = "Login";
    }
});

function signout() {
    var Domain = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '');
    firebase.auth().signOut().then(function () {
        window.location.href = Domain + "/Home";
    }).catch(function (error) {
        var errorMessage = error.message;
        window.alert(errorMessage);
    });
}

// Global
var products = [];
var cartItems = [];
var cart_n = document.getElementById('cart_n');
// DIV
var fruitDIV = document.getElementById("fruitDIV");
var juiceDIV = document.getElementById("juiceDIV");
var saladDIV = document.getElementById("SaladDIV");
// information 
var FRUIT = [
    { name: 'chili', price: 2 },
    { name: 'Tomato', price: 4 },
    { name: 'Capsicum', price: 5 }
];

var JUICE = [
    { name: 'Apple', price: 3 },
    { name: 'Banana', price: 2 },
    { name: 'Orange', price: 5 }
];

var SALAD = [
    { name: 'Milk', price: 3 },
    { name: 'Brown Bread', price: 2 },
    { name: 'Cookie', price: 1 }
];
// html 
function HTMLfruitProduct(con) {
    let URL = `img/fruits/fruit${con}.jpg`;
    let btn = `btnFruits${con}`;
    return `
    <div class="col-md-4">
         <div class="card mb-4 shadow-sm">
             <img class="card-img-top" style="height:16rem;" src="${URL}" 
             alt="Card image cap">
             <div class="card-body">
             <i style="color:orange;" class="fa fa-star" ></i>
             <i style="color:orange;" class="fa fa-star" ></i>
             <i style="color:orange;" class="fa fa-star" ></i>
             <i style="color:orange;" class="fa fa-star" ></i>
             <i style="color:orange;" class="fa fa-star" ></i>
             <p class="card-text">${FRUIT[con - 1].name}</p>
             <p class="card-text"> Price: ${FRUIT[con - 1].price}.00</p>
              <div class="d-flex justify-content-center-between align-items-center">
                  <div class="btn-group">
                    <button type="button" onclick="cart2('${FRUIT[con - 1].name}',
                    '${FRUIT[con - 1].price}','${URL}','${con}','${btn}')" class="btn btn-sm btn-outline-secondary"><a href="cart.html" style="color:inherit;">Buy</a></button> 
                    <button id="${btn}" type="button" onclick="cart('${FRUIT[con - 1].name}',
                    '${FRUIT[con - 1].price}','${URL}','${con}','${btn}')" class="btn btn-sm btn-outline-secondary">Add to cart</button> 
                  </div>
                  <small class="text-muted"> Free shipping </small>
               </div>
             </div>
          </div>
    </div>
    `
}

function HTMLjuiceProduct(con) {
    let URL = `img/fruits/fruit1${con}.jpg`;
    let btn = `btnJuice${con}`;
    return `
  <div class="col-md-4">
       <div class="card mb-4 shadow-sm">
           <img class="card-img-top" style="height:16rem;" src="${URL}" 
           alt="Card image cap">
           <div class="card-body">
           <i style="color:orange;" class="fa fa-star" ></i>
           <i style="color:orange;" class="fa fa-star" ></i>
           <i style="color:orange;" class="fa fa-star" ></i>
           <i style="color:orange;" class="fa fa-star" ></i>
           <i style="color:orange;" class="fa fa-star" ></i>
           <p class="card-text">${JUICE[con - 1].name}</p>
           <p class="card-text"> Price: ${JUICE[con - 1].price}.00</p>
            <div class="d-flex justify-content-center-between align-items-center">
                <div class="btn-group">
                  <button type="button" onclick="cart2('${JUICE[con - 1].name}',
                  '${JUICE[con - 1].price}','${URL}','${con}','${btn}')" class="btn btn-sm btn-outline-secondary"><a href="cart.html" style="color:inherit;">Buy</a></button> 
                  <button id="${btn}" type="button" onclick="cart('${JUICE[con - 1].name}',
                  '${JUICE[con - 1].price}','${URL}','${con}','${btn}')" class="btn btn-sm btn-outline-secondary">Add to cart</button> 
                </div>
                <small class="text-muted"> Free shipping </small>
             </div>
           </div>
        </div>
  </div>
  `
}

function HTMLsaladProduct(con) {
    let URL = `img/fruits/fruit2${con}.jpg`;
    let btn = `btnSalad${con}`;
    return `
  <div class="col-md-4">
       <div class="card mb-4 shadow-sm">
           <img class="card-img-top" style="height:16rem;" src="${URL}" 
           alt="Card image cap">
           <div class="card-body">
           <i style="color:orange;" class="fa fa-star" ></i>
           <i style="color:orange;" class="fa fa-star" ></i>
           <i style="color:orange;" class="fa fa-star" ></i>
           <i style="color:orange;" class="fa fa-star" ></i>
           <i style="color:orange;" class="fa fa-star" ></i>
           <p class="card-text">${SALAD[con - 1].name}</p>
           <p class="card-text"> Price: ${SALAD[con - 1].price}.00</p>
            <div class="d-flex justify-content-center-between align-items-center">
                <div class="btn-group">
                  <button type="button" onclick="cart2('${SALAD[con - 1].name}',
                  '${SALAD[con - 1].price}','${URL}','${con}','${btn}')" class="btn btn-sm btn-outline-secondary"><a href="cart.html" style="color:inherit;">Buy</a></button> 
                  <button id="${btn}" type="button" onclick="cart('${SALAD[con - 1].name}',
                  '${SALAD[con - 1].price}','${URL}','${con}','${btn}')" class="btn btn-sm btn-outline-secondary">Add to cart</button> 
                </div>
                <small class="text-muted"> Free shipping </small>
             </div>
           </div>
        </div>
  </div>
  `
}
//Animatioon
function animation() {
    const toast = swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 1000
    });
    toast({
        type: 'successs',
        title: 'Added to shopping cart'
    });
}
//cart function 
function cart(name, price, url, con, btncart) {
    
    var item = {
        name: name,
        price: price,
        url: url
    }
    cartItems.push(item);
    let storage = JSON.parse(localStorage.getItem("cart"));
    if (storage == null) {
        products.push(item);
        localStorage.setItem("cart", JSON.stringify(products));
    } else {
        products = JSON.parse(localStorage.getItem("cart"));
        products.push(item);
        localStorage.setItem("cart", JSON.stringify(products));
    }
    products = JSON.parse(localStorage.getItem("cart"));


    cart_n.innerHTML = `[${products.length}]`;
    document.getElementById(btncart).style.display = "none";
    animation();  


   


var ListName = "List1";
//Call C# Api to push Item in the cart
//https://localhost:44312/API/InsertTODatabase?ProductName=Tomato&Price=100&UserID=60080527
var Domain = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '');
var xmlHttp = new XMLHttpRequest();
var str = Domain + "/API/InsertTODatabase" + "?" + "ProductName=" + name + "&Price=" + price + "&UserID=" + 60080527 + "&ListName=" + ListName;
xmlHttp.open("GET", str, false); // false for synchronous request
xmlHttp.send(null);


}


function cart2(name, price, url, con, btncart) {
    var item = {
        name: name,
        price: price,
        url: url
    }
    cartItems.push(item);
    let storage = JSON.parse(localStorage.getItem("cart"));
    if (storage == null) {
        products.push(item);
        localStorage.setItem("cart", JSON.stringify(products));
    } else {
        products = JSON.parse(localStorage.getItem("cart"));
        products.push(item);
        localStorage.setItem("cart", JSON.stringify(products));
    }
    products = JSON.parse(localStorage.getItem("cart"));
    cart_n.innerHTML = `[${products.length}]`;
    document.getElementById(btncart).style.display = "none";
}

//render
function render() {
    for (let index = 1; index <= 3; index++) {
        fruitDIV.innerHTML += `${HTMLfruitProduct(index)}`;
    }
    for (let index = 1; index <= 3; index++) {
        juiceDIV.innerHTML += `${HTMLjuiceProduct(index)}`;
    }
    for (let index = 1; index <= 3; index++) {
        saladDIV.innerHTML += `${HTMLsaladProduct(index)}`;
    }
    if (localStorage.getItem("cart") == null) {

    } else {
        products = JSON.parse(localStorage.getItem("cart"));
        cart_n.innerHTML = `[${products.length}]`;
    }
}