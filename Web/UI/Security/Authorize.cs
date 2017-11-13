using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Cache;

namespace Lppa.UI.Web.Security
{
    public class Authorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == ".leathergoods");
            var user = Cache.Get(cookie.Value);
            if (user == null)
            {
                var fullname = filterContext.Controller.GetType().Name;
                var controller = fullname.Substring(0, fullname.Length - 10);
                filterContext.Result = new RedirectToActionResult("Index", "Login", new { redirectTo = controller });
            }
        }
    }
}
