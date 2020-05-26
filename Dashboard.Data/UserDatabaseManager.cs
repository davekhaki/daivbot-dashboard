using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Dashboard.Data
{
    public class UserDatabaseManager
    {
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(ConfigClass.connectionString))
            {
                using SqlCommand query = new SqlCommand("select * from [dbo].[user]", conn);
                conn.Open();

                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    User usr = new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3)
                    };

                    users.Add(usr);
                }
                conn.Close();
            }
            return users;
        }
    }
}
