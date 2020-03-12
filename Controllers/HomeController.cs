using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevUtilitiesV2MVCApp.Models;

namespace DevUtilitiesV2MVCApp.Controllers
{
     public class HomeController : Controller
     {
          public IActionResult Index()
          {
               return View();
          }

          public IActionResult Privacy()
          {
               return View();
          }

          [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
          public IActionResult Error()
          {
               return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
          }
     }
}
