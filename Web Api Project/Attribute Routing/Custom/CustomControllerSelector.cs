using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Attribute_Routing.Custom
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();

            var ControllerName = routeData.Values["controller"].ToString();
            string versionNumber = "1";
            //var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            //if(versionQueryString["v"] != null)
            //{
            //    versionNumber = versionQueryString["v"];
            //}
            //string customHeader = "X-StudentService-Version";
            //if(request.Headers.Contains(customHeader))
            //{
            //    versionNumber = request.Headers.GetValues(customHeader).FirstOrDefault();
            //    if(versionNumber.Contains(","))
            //    {
            //        versionNumber = versionNumber.Substring(0, versionNumber.IndexOf(","));
            //    }
            //}
            var acceptHeader = request.Headers.
                Accept.Where(a => a.Parameters.Count(p=>p.Name.ToLower() == "version") > 0);
            if(acceptHeader.Any())
            {
                versionNumber = acceptHeader.First().Parameters.First(p => p.Name.ToLower() == "version").Value;
            }
            if(versionNumber == "1")
            {
                ControllerName = ControllerName + "V1";
            }
            else
            {
                ControllerName = ControllerName + "V2";
            }
            HttpControllerDescriptor ControllerDescriptor;
            if(controllers.TryGetValue(ControllerName, out ControllerDescriptor))
            {
                return ControllerDescriptor;
            }
            return null; 

        }
    }
}