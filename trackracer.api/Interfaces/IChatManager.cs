using System;
using trackracer.Models.Accounts;
namespace trackracer.api.Interfaces
{
    public interface IChatManager
    {
       
        public  Task<ChatModel> SendMessageAsync(ChatModel message);
        public Task<List<ChatModel>> GetChatHistoryAsync(string user1Id, string user2Id);
        
    }
}
