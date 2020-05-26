using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return ($"ID: {Id}, username: {Username}, password: {Password}, email: {Email}");
        }
    }
}
