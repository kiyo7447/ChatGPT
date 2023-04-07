using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MatchingWebApp.Hubs
{
    public class ChatHub : Hub
    {
        private static int _connectedUsers = 0;
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }



        public override async Task OnConnectedAsync()
        {
            _connectedUsers++;
            await UpdateConnectedUsersCount();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _connectedUsers--;
            await UpdateConnectedUsersCount();
            await base.OnDisconnectedAsync(exception);
        }

        private async Task UpdateConnectedUsersCount()
        {
            await Clients.All.SendAsync("UpdateConnectedUsersCount", _connectedUsers);
        }
    }
}
