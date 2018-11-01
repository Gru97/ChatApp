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

        
    }
}