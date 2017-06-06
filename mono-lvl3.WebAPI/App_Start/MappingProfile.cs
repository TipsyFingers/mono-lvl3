using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mono_lvl3.Model.Mapping;
using mono_lvl3.WebAPI.Mapping;

namespace mono_lvl3.WebAPI.App_Start
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelMappingProfile());
                cfg.AddProfile(new WebMappingProfile());
            });

            return config;
        }
    }
}