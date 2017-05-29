using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using mono_lvl3.Common;
using mono_lvl3.Repository.Common;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Models.DomainModels;
using AutoMapper;
using mono_lvl3.DAL.DbContext;
using mono_lvl3.Repository.Repositories;

namespace mono_lvl3.Repository
{
    public class AlbumRepository : GenericRepository<DataContext, Album>
    {
        IGenericRepository<Album> repository;

        public AlbumRepository(AlbumRepository repository)
        {
            this.repository = repository;
        }
    }
}
