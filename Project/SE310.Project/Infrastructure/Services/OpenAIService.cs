//using OpenAI.Chat;
//using OpenAI.Chat.Interfaces;
//using OpenAI.Models;

//namespace Infrastructure.Services
//{
//    public class OpenAIService : IOpenAIService
//    {
//        private readonly IOpenAIService _openAI;

//        public OpenAIService(string apiKey)
//        {
//            _openAI = new OpenAIService(new OpenAiOptions { ApiKey = apiKey });
//        }

//        public async Task<string> GetChatResponse(string prompt)
//        {
//            var response = await _openAI.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
//            {
//                Messages = new List<ChatMessage>
//            {
//                ChatMessage.CreateSystemMessage("You are a helpful assistant."),
//                ChatMessage.CreateUserMessage(prompt)
//            },
//                Model = OpenAI.GPT3.ObjectModels.Models.Gpt_4
//            });

//            return response.Choices.First().Message.Content;
//        }
//    }
//}
