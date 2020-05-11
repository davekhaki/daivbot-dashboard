using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dashboard.Data;
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

            Assert.AreEqual("username: theusername , password: thepassword , id: 1", users[0].ToString());
        }

        [TestMethod]
        public void UserToString()
        {
            User user = new User();
            user.id = 50;
            user.username = "the username";
            user.password = "the password";

            Assert.AreEqual("username: the username , password: the password , id: 50", user.ToString());
        }

    }
       
}
