using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;
using ExamMeAI.Demo.OpenAI;
using Microsoft.AspNetCore.Mvc;
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
            if (_config.GetConnectionString("OpenAIKey") != null)
            {

                //AzureOpenAIClient azureClient = new(
                //    new Uri("https://your-azure-openai-resource.com"),
                //    new ApiKeyCredential(_config.GetConnectionString("OpenAIKey")));

                var client = new OpenAIClient(new AzureKeyCredential(_config.GetConnectionString("OpenAIKey")));

                ChatClient chatClient = client.GetChatClient("gpt-5-nano");

                var answer = "Get - wysyła żądanie do klienta, a POST - wysył na server. Obydwa są metodami protokołu WSL.";
                var question = "Jaka jest różnica pomiędzy metodami HTTP GET i POST?";

                ChatCompletion completion = chatClient.CompleteChat(
                    [
                        new SystemChatMessage("Jesteś wykwalifikowanym nauczycielem oceniającym odpowiedź." +
                        "Odnieś się do odpowiedzi użytkownika na zasadzie 'odpowiedź' - 'komentarz'" +
                        "w sekcji 'Analiza odpowiedzi:' oraz rozwiń odpowiedź i ocenę w sekcji 'Omówienie zagadnienia:'." +
                        "W sekcji 'Ocena:' umieść szacunkową ocenę 1-6 oraz 'Wyczerpanie tematu:' przedstaw" +
                        " procentową wartość ujętych w odpowiedzi kwestii ze wszystkich które uwzględnia pytanie w twojej ocenie."),

                        new UserChatMessage($"Oceń odpowiedź:'{answer}' udzieloną na pytanie: '{question}'"),
                    ]);

                Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");
            }

            if (false)
            {
                if (_config.GetConnectionString("OpenRouterKey") != null)
                    ChatDemo.GetInstance().WriteAnswerToConsole(_config.GetConnectionString("OpenRouterKey"));
            }
            return View();
        }
    }
}
