﻿using System.Web.Http;

namespace TDD_Practices
{
  public class WebApiConfig
  {
    public static void Register(HttpConfiguration configuration)
    {
      configuration.MapHttpAttributeRoutes();
      configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
        new { id = RouteParameter.Optional });
    }
  }
}