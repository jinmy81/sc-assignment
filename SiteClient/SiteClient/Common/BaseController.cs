using SiteClient.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteClient.Common
{
    public class BaseController:Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var notRequiredSignIn = IsNoNeedSignIn(filterContext);
            if (!notRequiredSignIn)
            {
                if (SessionMng.CurrentAccount == null)
                {
                    var returnurl = "";
                    if (!Request.IsAjaxRequest())
                    {
                        returnurl = HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.OriginalString);
                    }
                    var redrectUrl = string.IsNullOrEmpty(returnurl)
                        ? filterContext.HttpContext.Request.ApplicationPath
                        : "/Account/Login" + "?returnurl=" + returnurl;
                    filterContext.Result = new RedirectResult(redrectUrl);
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }

        private static bool IsNoNeedSignIn(ActionExecutingContext filterContext)
        {
            return filterContext.ActionDescriptor.GetCustomAttributes(typeof(AnonymousFilter), true).Length > 0;
        }
    }
}