using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            var jsonString = 
            JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            return MvcHtmlString.Create(jsonString);
        }
    }
}