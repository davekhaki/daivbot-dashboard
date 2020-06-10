using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dashboard.Data;
using Dashboard.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard.UnitTests
{
    [TestClass]
    public class UserUnitTests
    {
        [TestMethod]
        public void GetAllUsersUnitTest()
        {
            UserDatabaseManager userDbMan = new UserDatabaseManager();

            List<User> users = userDbMan.GetAllUsers().ToList();

            Assert.AreEqual("ID: 1, username: username, password: password, email: email", users[0].ToString());
        }

        [TestMethod]
        public void UserToString()
        {
            User user = new User
            {
                Id = 50,
                Username = "the username",
                Password = "the password",
                Email = "the email"
            };

            Assert.AreEqual("ID: 50, username: the username, password: the password, email: the email", user.ToString());
        }

    }
       
}
