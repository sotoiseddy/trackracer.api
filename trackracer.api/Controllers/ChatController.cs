using System;
using Microsoft.AspNetCore.Mvc;
using trackracer.api.Interfaces;
using trackracer.Models.Accounts;
namespace trackracer.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatManager _chatService;

        public ChatController(IChatManager chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatModel message)
        {
            var result = await _chatService.SendMessageAsync(message);
            return Ok(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetChatHistory(string user1Id, string user2Id)
        {
            var messages = await _chatService.GetChatHistoryAsync(user1Id, user2Id);
            return Ok(messages);
        }
    }

}
