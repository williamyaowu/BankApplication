using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api.App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            //map Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}