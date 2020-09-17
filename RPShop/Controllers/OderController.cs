using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RPShop.Controllers
{
    public class OderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateOder()
        {
            return View();
        }
    }
}
