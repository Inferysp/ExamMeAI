using Azure;
using OpenAI;
using OpenAI.Chat;

namespace ExamMeAI.singletons
{
    public class ChatOpenAI
    {
        private static ChatOpenAI _chatAI = null!;

        public static ChatOpenAI GetInstance()
        {
            if (_chatAI == null)
            {
                return new ChatOpenAI();
            }
            return _chatAI;
        }

        public string RunAiTest(string key, string question, string answer)
        {
            var client = new OpenAIClient(new AzureKeyCredential(key));

            ChatClient chatClient = client.GetChatClient("gpt-5-nano");

            //var answer = "Get - wysyła żądanie do klienta, a POST - wysył na server. Obydwa są metodami protokołu WSL.";
            //var question = "Jaka jest różnica pomiędzy metodami HTTP GET i POST?";

            ChatCompletion completion = chatClient.CompleteChat(
                [
                    new SystemChatMessage("Jesteś wykwalifikowanym nauczycielem oceniającym odpowiedź." +
                        "Odnieś się do odpowiedzi użytkownika na zasadzie 'odpowiedź' - 'komentarz'" +
                        "w sekcji 'Analiza odpowiedzi:' oraz rozwiń odpowiedź i ocenę w sekcji 'Omówienie zagadnienia:'." +
                        "W sekcji 'Ocena:' umieść szacunkową ocenę 1-6 oraz 'Wyczerpanie tematu:' przedstaw" +
                        " procentową wartość ujętych w odpowiedzi kwestii ze wszystkich które uwzględnia pytanie w twojej ocenie."),

                        new UserChatMessage($"Oceń odpowiedź:'{answer}' udzieloną na pytanie: '{question}'"),
                    ]);

            //Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");

            return completion.Content[0].Text;
        }
    }
}
