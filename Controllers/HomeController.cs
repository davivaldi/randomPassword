using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPass.Models;
 using Microsoft.AspNetCore.Http;

namespace RandomPass.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            StringBuilder passcode = new StringBuilder();
            passcode = RandString();
            ViewBag.passcode = passcode;
            System.Console.WriteLine(passcode);
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
           
            return View();
        }
        public string letters = "ABCDEFGHIJKLMNOQRSTUVWXZ0123456789";
        Random rand = new Random();
        public StringBuilder RandString()
        {
            StringBuilder passcode = new StringBuilder();
            for(int i =0; i< 14; i++)
            {
                passcode.Append(letters[rand.Next(0, letters.Length)]);
            }
            return passcode;
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
