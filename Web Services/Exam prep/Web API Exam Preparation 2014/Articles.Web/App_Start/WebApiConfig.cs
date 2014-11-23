﻿namespace Articles.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using Microsoft.Owin.Security.OAuth;
    using Newtonsoft.Json.Serialization;
    using System.Web.Http.Cors;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ArticleDetails",
                routeTemplate: "api/articles/{id}",
                defaults: new
                {
                    controller = "Articles",
                    action = "Details"
                }
            );

            config.Routes.MapHttpRoute(
                name: "Comments",
                routeTemplate: "api/articles/{id}/comments",
                defaults: new
                {
                    controller = "Comments",
                }
            );

            config.Routes.MapHttpRoute(
                name: "Users",
                routeTemplate: "api/users/{action}",
                defaults: new
                {
                    controller = "Users"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
