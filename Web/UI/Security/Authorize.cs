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
    public class Authorize : ActionFilterAttribute
    {
        private readonly string RoleName;
        public Authorize(string _RoleName)
        {
            RoleName = _RoleName.ToUpper();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == ".leathergoods");
            var user = (User)Cache.Get(cookie.Value);
            if (user == null)
                redirectToLogin(filterContext, cookie.Value);
            else {
                var valid = false;
                if(user.Roles != null) {
                    foreach(var role in user.Roles)
                    {
                        if(role.Name.ToUpper() == RoleName)
                        {
                            valid = true;
                            break;
                        }
                    }
                }
                if(!valid)
                    redirectToLogin(filterContext, cookie.Value);
                else {
                    filterContext.HttpContext.Items.Add("User", user.UserName);
                    filterContext.HttpContext.Items.Add("Role", user.Roles[0].Name.ToUpper());
                }
            }
        }

        private void redirectToLogin(ActionExecutingContext filterContext, string cookie)
        {
            filterContext.HttpContext.Items.Remove("User");
            filterContext.HttpContext.Items.Remove("Role");
            Cache.Remove(cookie);
            var fullname = filterContext.Controller.GetType().Name;
            var controller = fullname.Substring(0, fullname.Length - 10);
            filterContext.Result = new RedirectToActionResult("Login", "Home", new { redirectTo = controller });
        }
    }
}
