using OpenAI;
using OpenAI.Chat;

namespace ExamMeAI.Demo.OpenAI
{
    public sealed class ChatDemo
    {
        private static ChatDemo _chatDemo = null!;
        public static ChatDemo GetInstance()
        {
            if (_chatDemo == null)
            {
                return new ChatDemo();
            }
            return _chatDemo;
        }

        internal void WriteAnswerToConsole(string OpenRouterKey)
        {
            ChatClient client = new(model: "gpt-4o", apiKey: OpenRouterKey);

            ChatCompletion completion = client.CompleteChat("Jak używać delegatów we wzorcu projektowym DI?");

            Console.WriteLine($"OpenAI response: {completion.Content[0].Text}");
        }
    }
}
