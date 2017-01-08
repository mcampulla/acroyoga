using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using Swashbuckle.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using acroyoga.it.admin.Models;
using Microsoft.OData.Edm;

namespace acroyoga.it.admin
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //// Web API routes
            //config.MapHttpAttributeRoutes();

            config
              .EnableSwagger(c =>
              {
                  c.SingleApiVersion("v1", "Acroyoga API");
                  c.CustomProvider(defaultProvider => new ODataSwaggerProvider(defaultProvider, c, config));
              })
              .EnableSwaggerUi();

            //ODataModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Event>("Events");
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            config.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel());

            config.EnableCors();

            config.EnsureInitialized();

            //config.MapODataServiceRoute(
            //    routeName: "ODataRoute",
            //    routePrefix: "odata",
            //    model: builder.GetEdmModel());

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.Namespace = "Acroyoga";
            builder.ContainerName = "AcroyogaContainer";

            builder.EntitySet<Event>("Events");
            builder.EntitySet<Gallery>("Galleries");
            builder.EntitySet<Picture>("Pictures");

            return builder.GetEdmModel();
        }
    }
}
