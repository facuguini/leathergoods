using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Session
{
    public class SessionCookie : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == ".leathergoods");
            if(cookie.Value == null)
                filterContext.HttpContext.Response.Cookies.Append(
                    ".leathergoods",
                    Guid.NewGuid().ToString(),
                    new CookieOptions() {
                        HttpOnly = true
                    }
                );
        }
    }
}
