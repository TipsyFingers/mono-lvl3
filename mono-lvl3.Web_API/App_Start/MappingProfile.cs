using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mono_lvl3.Model.Mapping;
using mono_lvl3.Web_API.Mapping;

namespace mono_lvl3.Web_API.App_Start
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelMappingProfile());
                cfg.AddProfile(new WebAPIMappingProfile());
            });

            return config;
        }
    }
}