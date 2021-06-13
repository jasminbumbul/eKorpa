using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.SignalR
{
    public class MyHub: Hub
    {
        public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.Name != null)
                await Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            await base.OnConnectedAsync();
        }
    }
}
