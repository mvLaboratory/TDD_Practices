﻿using System.Web.Mvc;
using System.Web.Routing;

namespace TDD_Practices
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      routes.MapMvcAttributeRoutes();
      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}",
          defaults: new { controller = "project", action = "index"}
      );


    }
  }
}
