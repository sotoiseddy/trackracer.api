using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace trackracer.RacerPages
{
    public class ChatSignalHub : Hub
    {
        // This method is used to send messages to all connected clients
        public async Task SendMessage(string senderName, string receiverName, string message)
        {
            // Sends the message to all clients connected to the hub
            await Clients.All.SendAsync("ReceiveMessage", senderName, receiverName, message);
        }

        // You can add more methods to handle events, like when a client connects or disconnects
        public override async Task OnConnectedAsync()
        {
            // Code to run when a client connects
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Code to run when a client disconnects
            await base.OnDisconnectedAsync(exception);
        }
    }
}
