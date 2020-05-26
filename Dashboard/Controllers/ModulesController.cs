using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;

namespace Dashboard.Controllers
{
    public class ModulesController : Controller
    {
        private LoginViewModel DisplayUsername()
        {
            LoginViewModel TempViewModel = new LoginViewModel();
            TempViewModel.Username = HttpContext.Session.GetString("username");
            return TempViewModel;
        }
        public IActionResult Index()
        {
            return View(DisplayUsername());
        }
        public IActionResult Moderation()
        {
            return View(DisplayUsername());
        }
        public IActionResult Information()
        {
            return View(DisplayUsername());
        }
        public IActionResult Currency()
        {
            return View(DisplayUsername());
        }
        public IActionResult Minigames()
        {
            return View(DisplayUsername());
        }
        public IActionResult Music()
        {
            return View(DisplayUsername());
        }
        public IActionResult Statistics()
        {
            return View(DisplayUsername());
        }

        public IActionResult Testpage()
        {
            return View(DisplayUsername());
        }
    }
}