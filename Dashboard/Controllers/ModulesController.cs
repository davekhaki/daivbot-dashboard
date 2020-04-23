using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class ModulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Moderation()
        {
            return View();
        }
        public IActionResult Information()
        {
            return View();
        }
        public IActionResult Currency()
        {
            return View();
        }
        public IActionResult Minigames()
        {
            return View();
        }
        public IActionResult Music()
        {
            return View();
        }
        public IActionResult Statistics()
        {
            return View();
        }

    }
}