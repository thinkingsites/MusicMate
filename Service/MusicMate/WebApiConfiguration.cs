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

            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "default api",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "typeless static files",
            //    routeTemplate: "{path*}",
            //    defaults: new
            //    {
            //        controller = "PublicFiles",
            //        path = "html/index.html"
            //    }
            //);

            config.EnsureInitialized();

            appBuilder.UseWebApi(config);
        } 
    }
}
