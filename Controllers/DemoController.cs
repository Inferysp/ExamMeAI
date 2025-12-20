using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;
using ExamMeAI.Demo.OpenAI;
using ExamMeAI.singletons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OpenAI;
using OpenAI.Chat;


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

        //Akcja Dla AJAX
        [HttpPost]
        public IActionResult PostOpenAiResponceOnBtnClick()
        {
            var client = new OpenAIClient(new AzureKeyCredential(_config.GetConnectionString("OpenAIKey")));

            ChatClient chatClient = client.GetChatClient("gpt-5-nano");


            ChatCompletion completion = chatClient.CompleteChat(
                [
                    // System messages represent instructions or other guidance about how the assistant should behave
                    new SystemChatMessage("You are a helpful assistant that talks like a Miki mouse."),
                    new UserChatMessage("Jak używać asynchroniczności we wzorcu projektowym DI??"),
                ]);

            var r = $"{completion.Role}: {completion.Content[0].Text}";

            Console.WriteLine($"testy stringa: {r}");
            return Content(r);
        }

        //Akcja Dla AJAX
        [HttpPost]
        public IActionResult PostStringOnBtnClick()
        {
            var r = "testowy massage Demo!!!";
            Console.WriteLine($"testy stringa: {r}");
            return Content(r);
        }

        //Akcja Dla AJAX
        [HttpPost]
        public async Task<IActionResult> PostOpenRouterResponseOnBtnClick()
        {
            if (false)
            {
                if (_config.GetConnectionString("OpenRouterKey") != null)
                    ChatDemo.GetInstance().WriteAnswerToConsole(_config.GetConnectionString("OpenRouterKey"));
            }
            return View();
        }
    }
}
