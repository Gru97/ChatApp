using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //get list of message
            return View();
           
        }

        [HttpPost]
        public ActionResult Index(DomainModel.ViewModel.MessageAddEditModel m)
        {
            using (DataAccess.Repository.MessageRepo repo=new DataAccess.Repository.MessageRepo())
            {
                m.user_id = 1;
                repo.Add(m);
            }
            return View();
        }


        public ActionResult Chat()
        {
            using (DataAccess.Repository.MessageRepo repo = new DataAccess.Repository.MessageRepo())
            {
                var lst = repo.List();
                //return View(lst);

            }
            return View();
        }

        [HttpPost]
        public ActionResult Chat(DomainModel.ViewModel.MessageAddEditModel m)
        {
            using (DataAccess.Repository.MessageRepo repo = new DataAccess.Repository.MessageRepo())
            {
                m.user_id = 1;
                repo.Add(m);
                var context = GlobalHost.ConnectionManager.GetHubContext<SignalR.ChatHub>();
                
                //This really works! It sends these two values to hatHubProxy.client.sendMessage = function (name, message) in view of each client
                context.Clients.All.sendMessage(m.user_id,m.message_text);
            }
         
            return View();
        }

    }
}