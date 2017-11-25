using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Cache;
using Entities;

namespace UI.Security
{
    public class IsLogged : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == ".leathergoods");
            var user = (User)Cache.Get(cookie.Value);
            if (user != null)
            {
                filterContext.HttpContext.Items.Add("User", user.UserName);
                filterContext.HttpContext.Items.Add("Role", user.Roles[0].Name.ToUpper());
            }
        }
    }
}
