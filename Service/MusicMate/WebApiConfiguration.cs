using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MusicMate
{
    public class WebApiConfiguration
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "static files",
                routeTemplate: "{controller}/{path*}",
                defaults: new { 
                    controller = "Static",
                    action = "ServeStaticFile",
                    id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        } 
    }
}
