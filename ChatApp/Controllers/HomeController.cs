using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            
        }      

        [Infrastructure.CustomAthurize]
        public ActionResult Chat(string username)
        {
            using (DataAccess.Repository.MessageRepo repo = new DataAccess.Repository.MessageRepo())
            {
                //ViewBag.username = username;
                //var lst = repo.List();
                //return View(lst);

            }
            return View();
        }

        [HttpPost]
        public ActionResult Chat(DomainModel.ViewModel.MessageAddEditModel m)
        {
            //using (DataAccess.Repository.MessageRepo repo = new DataAccess.Repository.MessageRepo())
            //{
            //    m.user_id = 1;
            //    repo.Add(m);
            //    var context = GlobalHost.ConnectionManager.GetHubContext<SignalR.ChatHub>();

            //    //This really works! It sends these two values to hatHubProxy.client.sendMessage = function (name, message) in view of each client
            //    context.Clients.All.sendMessage(m.user_id, m.message_text);
            //}

            return View();
        }

        public ActionResult LogIn(DomainModel.ViewModel.UserLogInModel lg)
        {
            using (DataAccess.Repository.UserRepo repo = new DataAccess.Repository.UserRepo())
            {
                if (repo.LogIn(lg))
                {
                    FormsAuthentication.SetAuthCookie(lg.username, lg.rememberMe);
                   
                    return RedirectToAction("Chat", "Home", new {User= HttpContext.User.Identity.Name });

                }
                else
                {
                    TempData["ErrorMessage"] = "نام کاربری یا رمز عبور اشتباه است";
                   
                    return View();


                }

            }
        }
    }
}