using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dashboard.Models;
using MySql.Data.MySqlClient;
using Dashboard.Data;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Dashboard.Core;
using Dashboard.Core.Constants;
using System.Collections;
using System.Web;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private int IncreaseCounter()
        {
            int? currentValue = HttpContext.Session.GetInt32(CounterConstants.CounterName);
            int newValue;
            if (currentValue.HasValue)
            {
                newValue = currentValue.Value + CounterConstants.CounterIncreaseValue;        
            }
            else
            {
                newValue = CounterConstants.CounterInitialValue;              
            }
            HttpContext.Session.SetInt32(CounterConstants.CounterName, newValue);
            return newValue;
        }

        public IActionResult Index()
        {
            TempData["omg"] = HttpContext.Session.GetString("username");
            ViewBag.Counter = IncreaseCounter();
            return View();
        }

        public IActionResult Privacy()
        {
            TempData["omg"] = HttpContext.Session.GetString("username");
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string password, string Email)
        {
            RegisterManager r = new RegisterManager();

            if (r.CheckUsername(username) == false && r.CheckPassword(username, password) == true)
            {
                using SqlConnection conn = new SqlConnection(ConfigClass.connectionString);
                using SqlCommand query = new SqlCommand($"insert into [dbo].[user] (id, username, password, email) values ('{r.GetId()}', '{username}', '{password}', '{Email}')", conn);
                conn.Open();

                query.ExecuteNonQuery();
                conn.Close();

            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            string IsUsername = HttpContext.Session.GetString("username");
            if (String.IsNullOrEmpty(IsUsername))
            {
                var Model = new RegisterViewModel();
                return View(Model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User user = new User();
            LoginViewModel viewModel = new LoginViewModel();
            using SqlConnection conn = new SqlConnection(ConfigClass.connectionString);
            using SqlCommand query = new SqlCommand($"select * from [dbo].[user] where username = '{username}'", conn);
            conn.Open();

            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                user.Password = reader.GetString(2);
                if (user.Password == password)
                {
                    viewModel.Username = username;
                    HttpContext.Session.SetString("username", username);

                    TempData["loginmsg"] = UserConstants.LoginSuccessMsg;
                    return View("Index", viewModel);
                }
                else
                {
                    TempData["loginfailmsg"] = UserConstants.LoginFailMsg;
                    return RedirectToAction("Login", "Home");
                }
            }
            conn.Close();
            TempData["loginfailmsg"] = UserConstants.LoginFailMsg;
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Login()
        {
            string IsUsername = HttpContext.Session.GetString("username");
            if (String.IsNullOrEmpty(IsUsername))
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Profile()
        {
            string IsUsername = HttpContext.Session.GetString("username");
            if (String.IsNullOrEmpty(IsUsername))
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
