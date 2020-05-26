using System;
using System.Data.SqlClient;
using System.Linq;
using Dashboard.Data;

namespace Dashboard.Core
{
    public class RegisterManager
    {
        public int GetId()
        {
            //this method is used to calculate the id which is given to new users
            int id = 0;

            using (SqlConnection conn = new SqlConnection(ConfigClass.connectionString))
            {
                using SqlCommand query = new SqlCommand("select max(id) from [dbo].[user]", conn);
                conn.Open();
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);

                }
            }
            return id + 1;
        }

        public bool CheckUsername(string username)
        {
            //this method checks if a user already exists with a certain username
            int result;
            using SqlConnection conn = new SqlConnection(ConfigClass.connectionString);
            using SqlCommand query = new SqlCommand($"SELECT 1 FROM [dbo].[user] WHERE username='{username}'", conn);
            conn.Open();

            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetInt32(0);
                if (result == 1) return true;
                else return false;
            }
            return false;
        }

        public bool CheckPassword(string username, string password)
        {
            //this method checks to see if a password is viable
            // : a password must exist, must contain 1 capital letter, must contain a number and cant be the same as the username
            if (password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && username != password)
            {
                return true;
            }
            else return false;
        }
    }
}