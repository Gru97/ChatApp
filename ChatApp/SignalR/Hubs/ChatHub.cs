using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections;

namespace ChatApp.SignalR
{
    public class ChatHub : Hub
    {

        private static Hashtable User_ConnectionId = new Hashtable(20);
        public void registerConId()
        {
            string userID;
            using (DataAccess.Repository.UserRepo repo=new DataAccess.Repository.UserRepo())
            {
                userID = repo.GetUserIDByUsername(HttpContext.Current.User.Identity.Name).ToString();

            }
            if (User_ConnectionId.ContainsKey(userID))
                User_ConnectionId[userID] = Context.ConnectionId;
            else
                User_ConnectionId.Add(userID, Context.ConnectionId);
        }
 

        public void SendMessage(string receiverId,string message,bool messageType)
        {
            string sender = HttpContext.Current.User.Identity.Name.ToString();
            //This is called from one client who wants to broadcast a message to others.
            //When server-side code calls a method on the client (means when the bellow code executes), 
            //a packet is sent across the active transport that contains the name and parameters of the method to be called (on all clients)
            //(when an object is sent as a method parameter, it is serialized using JSON).
            //The client then matches the method name to methods defined in client - side code.
            //If there is a match, the client method will be executed using the deserialized parameter data.
            //The so called method must be in the script tag directly and not in another function or inside an event,
            //otherwise the server won't find it (out problem)
            if (!messageType)
            {
               
                //send message to it's own sender which is current user
                string userID;
                using (DataAccess.Repository.UserRepo repo = new DataAccess.Repository.UserRepo())
                {
                    userID = repo.GetUserIDByUsername(HttpContext.Current.User.Identity.Name).ToString();

                }
                string s = User_ConnectionId[userID].ToString();              
                Clients.Client(s).peerTopeer(sender, message,receiverId);

                //send message to the receiver only
                if (User_ConnectionId[receiverId] != null)
                {
                    string r = User_ConnectionId[receiverId].ToString();
                    Clients.Client(r).peerTopeer(sender, message,receiverId);


                }
            }
            else
            {
                Clients.All.broadcastMessage(sender, message,receiverId);
            }

        }
        
    }
}