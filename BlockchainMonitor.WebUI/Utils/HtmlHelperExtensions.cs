using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BlockchainMonitor.WebUI.Utils
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ToJson(this HtmlHelper html, object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return MvcHtmlString.Create(serializer.Serialize(obj));
        }

        public static MvcHtmlString ToJson(this HtmlHelper html, object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return MvcHtmlString.Create(serializer.Serialize(obj));
        }
    }
}