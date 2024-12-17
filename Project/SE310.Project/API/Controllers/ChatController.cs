using Core.LLama.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //public class ChatController : BaseApiController
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;
        private readonly StatefulChatService _statefulChatService;
        public ChatController(ILogger<ChatController> logger, StatefulChatService statefulChatService)
        {
            _logger = logger;
            _statefulChatService = statefulChatService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Validate the anti-CSRF token
        public async Task<IActionResult> SendMessage(string userInput)
        {
            // Here you can process the user's input
            _logger.LogInformation($"Message received: {userInput}");

            var sendMessageInput = new SendMessageInput()
            {
                Text = userInput,
            };

            var result = await _statefulChatService
                .Send(sendMessageInput);

            // Return a JSON response with a success message or processed data
            return Json(new { success = true, message = result });
        }

        // Return the default view
        public IActionResult Index()
        {
            return View();
        }
        //private readonly OpenAIClient _openAIClient;

        //public ChatController(OpenAIClient openAIClient)
        //{
        //    _openAIClient = openAIClient;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Chat([FromBody] String userInput)
        //{
        //    var chatMessages = new ChatMessage[]
        //    {
        //        new SystemChatMessage("Bạn là một trợ lý ảo thông minh và rất giỏi trong lĩnh vực dược phẩm"),
        //        new UserChatMessage("Xin chào, bạn có thể giúp tôi không"),
        //        new AssistantChatMessage("Chắc chắn rồi, PMQ Pharmacy có thể tư vấn được gì cho bạn?"),
        //        new UserChatMessage(userInput)
        //    };

        //    try
        //    {
        //        var chatClient = _openAIClient.GetChatClient("gpt-4o-mini");
        //        var completion = await chatClient.CompleteChatAsync(chatMessages);
        //        return Ok($"result: {completion.Value}");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Đã xảy ra lỗi: {ex.Message}");
        //    }
        //}
    }
}
