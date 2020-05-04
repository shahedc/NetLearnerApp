using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetLearner.SignalRPoll.Hubs
{
    public class PollHub : Hub
    {
        public async Task SendMessage(string user, string message, string myProjectId, string myProjectVal)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, myProjectId, myProjectVal);
        }
    }
}
