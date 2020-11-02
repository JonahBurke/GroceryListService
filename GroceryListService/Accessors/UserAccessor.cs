using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;

namespace GroceryListService.Accessors
{
    public class UserAccessor : DbAccessor
    {
        public UserAccessor(SqlConnection connection) : base(connection) { }

        public Boolean UserExists(int id)
        {
            return SelectUser(id) != null;
        }

        public User SelectUser(int id)
        {
            string query = "SELECT \"email\", \"password\", \"nickname\" FROM \"User\" WHERE userId = @UserID;";
            using (SqlCommand cmd = new SqlCommand(query, GetConnection()))
            {
                cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);

                cmd.Parameters["@UserID"].Value = id;
                try
                {
                    OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    User u = null;
                    while (reader.Read())
                    {
                        u = new User
                        {
                            Id = id,
                            Email = reader["email"].ToString(),
                            Password = reader["Password"].ToString(),
                            Nickname = reader["nickname"].ToString()
                        };
                    }

                    CloseConnection();
                    return u;
                }
                catch (SqlException)
                {
                    return null;
                }
            }
        }

        public void InsertUser(string email, string password, string nickname)
        {
            string query = "INSERT INTO \"User\" (\"email\", \"password\", \"nickname\") values (@Email, @Password, @NickName);";
            using (SqlCommand cmd = new SqlCommand(query, GetConnection()))
            {
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@NickName", System.Data.SqlDbType.NVarChar, 255);

                cmd.Parameters["@Email"].Value = email;
                cmd.Parameters["@Password"].Value = password;
                cmd.Parameters["@NickName"].Value = nickname;
                try
                {
                    OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    CloseConnection();
                    return;
                }
                catch (SqlException)
                {
                    return;
                }
            }
        }

        public void UpdateUser(User user)
        {
            string query = "UPDATE \"User\" SET \"email\" = @Email, \"password\" = @Password, \"nickname\" = @NickName;";
            using SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NickName", System.Data.SqlDbType.NVarChar, 255);

            cmd.Parameters["@Email"].Value = user.Email;
            cmd.Parameters["@Password"].Value = user.Password;
            cmd.Parameters["@NickName"].Value = user.Nickname;
            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                CloseConnection();
                return;
            }
            catch (SqlException)
            {
                return;
            }
        }
    }
}
