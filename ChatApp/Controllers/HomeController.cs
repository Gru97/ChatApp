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
            return View();
        }

        public PartialViewResult LogIn(DomainModel.ViewModel.UserLogInModel lg)
        {

            return PartialView();        
        }
        public PartialViewResult Signup()
        {
            return PartialView();
        }
    }
}