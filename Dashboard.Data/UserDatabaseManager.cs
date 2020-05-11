using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dashboard.Data
{
    public class UserDatabaseManager
    {
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using(SqlConnection conn = new SqlConnection(ConfigClass.connectionString))
            {
                using(SqlCommand query = new SqlCommand("select * from [dbo].[user]", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        User usr = new User();
                        usr.id = reader.GetInt32(0);
                        usr.username = reader.GetString(1);
                        usr.password = reader.GetString(2);

                        users.Add(usr);
                    }
                }
            }
            return users;
        }
    }
}
