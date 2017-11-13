using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Cache;
using Entities;

namespace Lppa.UI.Web.Security
{
    public class Authorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == ".leathergoods");
            var user = (User)Cache.Get(cookie.Value);
            if (user == null)
            {
                filterContext.HttpContext.Items.Remove("User");
                var fullname = filterContext.Controller.GetType().Name;
                var controller = fullname.Substring(0, fullname.Length - 10);
                filterContext.Result = new RedirectToActionResult("Login", "Home", new { redirectTo = controller });
            } else {
                filterContext.HttpContext.Items.Add("User", user.UserName);
            }
        }
    }
}
