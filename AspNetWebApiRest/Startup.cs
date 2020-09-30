using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace AspNetWebApiRest
{
    //Completed using this tutorial
    //https://developer.okta.com/blog/2019/03/13/build-rest-api-with-aspnet-web-api



    //The code below creates an OWIN pipeline for hosting your Web API, and configures the routing.
    public class Startup
    {//part 1
        public void Configuration(IAppBuilder app) 
        {
            var congfig = new HttpConfiguration();
            congfig.MapHttpAttributeRoutes();
            congfig.Routes.MapHttpRoute(name:"DefaultApi",routeTemplate:"api/{controller}/{id}",defaults: new {id=RouteParameter.Optional});
            //part 3 start This code removes the XmlFormatter (which was the default output formatter), and configures the JsonFormatter to camel-case property names and to use UTC time for dates.
            congfig.Formatters.Remove(congfig.Formatters.XmlFormatter);
            congfig.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            congfig.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            //part 3 end
            app.UseWebApi(congfig);
        }
    }
}