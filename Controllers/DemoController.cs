using ExamMeAI.Demo.OpenAI;
using Microsoft.AspNetCore.Mvc;

namespace ExamMeAI.Controllers
{
    public class DemoController : Controller
    {
        private readonly IConfiguration _config;
        public DemoController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IActionResult DemoPage()
        {
            return View();
        }

        public IActionResult MakeTest()
        {
            if(_config.GetConnectionString("OpenAIKey") != null)
                ChatDemo.GetInstance().WriteAnswerToConsole(_config.GetConnectionString("OpenAIKey"));
            return View();
        }
    }
}
