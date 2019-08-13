using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public static HashSet<string> ConnectionIds = new HashSet<string>();
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            ConnectionIds.Add(Context.ConnectionId);
            await Clients.All.SendAsync("Counter", ConnectionIds.Count);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            ConnectionIds.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("Counter", ConnectionIds.Count);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
