using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace signal_test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configurar CORS para permitir solicitudes desde cualquier origen con credenciales
            //var cors = new EnableCorsAttribute("*", "accept,accesstoken,authorization,cache-control,pragma,content-type,origin", "GET,PUT,POST,DELETE,TRACE,HEAD,OPTIONS");
            //config.EnableCors(cors);

            // Configuración de rutas
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

}
