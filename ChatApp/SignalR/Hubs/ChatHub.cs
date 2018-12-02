using System;
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
            //This is called from one client who wants to broadcast a message to others.
            //When server-side code calls a method on the client (means when the bellow code executes), 
            //a packet is sent across the active transport that contains the name and parameters of the method to be called (on all clients)
            //(when an object is sent as a method parameter, it is serialized using JSON).
            //The client then matches the method name to methods defined in client - side code.
            //If there is a match, the client method will be executed using the deserialized parameter data.
            //The so called method must be in the script tag directly and not in another function or inside an event,
            //otherwise the server won't find it (out problem)
            Clients.All.broadcastMessage(name, message);
        }
        
    }
}