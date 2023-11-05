using IST.Models.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace PushTasks.Hubs
{
    public  class TasksHub : Hub
    {
        private static readonly Dictionary<string, string> _usersConnections = new Dictionary<string, string>();
     
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public void SetUserIdConnection(string userName)
        {
            if (_usersConnections.ContainsKey(userName))
            {
                _usersConnections[userName] = Context.ConnectionId;
            }
            else
            {
                _usersConnections.Add(userName, Context.ConnectionId);
            }
        }

        public async Task SendTaskToUser(int taskId, string taskname, string username)
        {
            if (_usersConnections.ContainsKey(username))
            {
                var userConnectionId = _usersConnections[username];
                await Clients.Client(userConnectionId).SendAsync("BindTaskToUser", taskId, taskname);
            }
        }
    }
}
