using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatApp.Infrastructure
{
    public class CustomAthurize: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}