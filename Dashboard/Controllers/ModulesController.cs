using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Dashboard.Data;

namespace Dashboard.Controllers
{
    public class ModulesController : Controller
    {
        public IActionResult Index()
        {
            TempData["omg"] = HttpContext.Session.GetString("username");
            return View();
        }

        [HttpPost]
        public ActionResult Moderation(string status, string serverid, string password)
        {
            ModerationViewModel viewModel = new ModerationViewModel();
            using SqlConnection conn = new SqlConnection(ConfigClass.connectionString);
            using SqlCommand query = new SqlCommand($"select Password from [dbo].[servers] where ServerId = '{serverid}'", conn);
            conn.Open();

            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                string RealPassword = reader.GetString(0);
                if(RealPassword == password)
                {
                    conn.Close();
                    using SqlCommand updateQuery = new SqlCommand($"update [dbo].[servers] set ModerationEnabled = '{status.ToString()}' where ServerId = '{serverid}'", conn);
                    conn.Open();
                    updateQuery.ExecuteReader();
                    TempData["UpdateSuccess"] = "<script>alert('The settings have been updated.');</script>";
                    return RedirectToAction("Index", "Home");
                }
            }
            conn.Close();
            return View();
        }

        public IActionResult Moderation()
        {
            TempData["omg"] = HttpContext.Session.GetString("username");
            return View();
        }
        public IActionResult Information()
        {
            TempData["omg"] = HttpContext.Session.GetString("username");
            return View();
        }
        public IActionResult Currency()
        {
            TempData["omg"] = HttpContext.Session.GetString("username");
            return View();
        }
        public IActionResult Minigames()
        {
            TempData["omg"] = HttpContext.Session.GetString("username");
            return View();
        }
        public IActionResult Music()
        {
            TempData["omg"] = HttpContext.Session.GetString("username");
            return View();
        }
        public IActionResult Statistics()
        {
            TempData["omg"] = HttpContext.Session.GetString("username");
            return View();
        }

    }
}