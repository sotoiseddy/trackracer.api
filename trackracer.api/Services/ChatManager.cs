using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using trackracer.DBContext;
using trackracer.Interfaces;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using trackracer.Models.Accounts;
using trackracer.api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace trackracer.api.Services
{
    public class ChatManager :IChatManager
    {
        private readonly DatabaseContext _context;

        public ChatManager(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ChatModel> SendMessageAsync(ChatModel message)
        {
            _context.ChatTB.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<List<ChatModel>> GetChatHistoryAsync(string user1Id, string user2Id)
        {
            return await _context.ChatTB
                .Where(c =>
                    (c.SenderId == user1Id && c.ReceiverId == user2Id) ||
                    (c.SenderId == user2Id && c.ReceiverId == user1Id))
                .OrderBy(c => c.Id)
                .ToListAsync();
        }
    }
}
