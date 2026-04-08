using ExamMeAI.Demo.controllerDI;
using ExamMeAI.Models;
using ExamMeAI.Providers;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Diagnostics;

namespace ExamMeAI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IDateTime _dateTime;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDateTime dateTime)
        {
            _dateTime = dateTime;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var serverTime = _dateTime.Now;
            if (serverTime.Hour < 12)
            {
                ViewData["Message"] = "It's morning here - Good Morning!";
            }
            else if (serverTime.Hour < 17)
            {
                ViewData["Message"] = "It's afternoon here - Good Afternoon!";
                Log.logger.Info("It's afternoon here - Good Afternoon!");
            }
            else
            {
                ViewData["Message"] = "It's evening here - Good Evening!";
            }
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
