using ExamMeAI.Demo.OpenAI;
using Microsoft.AspNetCore.Mvc;

namespace ExamMeAI.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult DemoPage()
        {
            return View();
        }

        public IActionResult MakeTest()
        {
            ChatDemo.GetInstance().WriteAnswerToConsole();
            return View();
        }
    }
}
