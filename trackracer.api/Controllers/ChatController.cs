using System;
using Microsoft.AspNetCore.Mvc;
using trackracer.api.Interfaces;
using trackracer.Models.Accounts;
using Microsoft.AspNetCore.SignalR;
using trackracer.RacerPages; // Make sure this namespace matches where ChatSignalHub is

namespace trackracer.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatManager _chatService;
        private readonly IHubContext<ChatSignalHub> _chatHub;

        public ChatController(IChatManager chatService, IHubContext<ChatSignalHub> chatHub)
        {
            _chatService = chatService;
            _chatHub = chatHub;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatModel message)
        {
            var result = await _chatService.SendMessageAsync(message);

            // Send message via SignalR to all connected clients
            await _chatHub.Clients.All.SendAsync("ReceiveMessage", message.SenderName, message.ReceiverName, message.ChatMessage);

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
