using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace Bonisoft_1.Views.Shared
{
    public static class MvcHelperExtensions
    {
        public static MvcLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return new MvcLink(ajaxHelper.ViewContext, ajaxHelper.ActionLink(MvcLink.InnerText, actionName, routeValues, ajaxOptions, htmlAttributes));
        }

        public static MvcLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, object routeValues, object htmlAttributes)
        {
            return new MvcLink(htmlHelper.ViewContext, htmlHelper.ActionLink(MvcLink.InnerText, actionName, routeValues, htmlAttributes));
        }
    }
}