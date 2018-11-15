﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatApp.SignalR
{
    public class ChatHub : Hub
    {
        public void SendMessage(string name,string message)
        {
            Clients.All.sendMessage(name, message);
        }
        
    }
}