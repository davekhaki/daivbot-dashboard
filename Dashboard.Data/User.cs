using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Data
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return ($"username: {username} , password: {password} , id: {id}");
        }
    }
}
