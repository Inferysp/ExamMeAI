using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;
using ExamMeAI.Demo.OpenAI;
using ExamMeAI.singletons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

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
            string v = "";
            if (_config.GetConnectionString("OpenAIKey") != null)
            {
                var question = "q";
                var answer = "a";

                v = ChatOpenAI.GetInstance().RunAiTest(_config.GetConnectionString("OpenAIKey"), question, answer);
            }

            if (false)
            {
                if (_config.GetConnectionString("OpenRouterKey") != null)
                    ChatDemo.GetInstance().WriteAnswerToConsole(_config.GetConnectionString("OpenRouterKey"));
            }

            return Content(v);
        }
    }
}
