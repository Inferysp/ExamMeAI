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

                ChatCompletion completion = chatClient.CompleteChat(
                    [
                        // System messages represent instructions or other guidance about how the assistant should behave
                        new SystemChatMessage("You are a helpful assistant that talks like a pirate."),
                        // User messages represent user input, whether historical or the most recent input
                        new UserChatMessage("Hi, can you help me?"),
                        // Assistant messages in a request represent conversation history for responses
                        new AssistantChatMessage("Arrr! Of course, me hearty! What can I do for ye?"),
                        new UserChatMessage("What's the best way to train a parrot?"),
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
