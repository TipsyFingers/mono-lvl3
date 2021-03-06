﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using mono_lvl3.Model.Mapping;
using mono_lvl3.WebMVC.Mapping;

namespace mono_lvl3.WebMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(cfg => {
                cfg.AddProfile<ModelMappingProfile>();
                cfg.AddProfile<WebMappingProfile>();
            });
        }
    }
}
