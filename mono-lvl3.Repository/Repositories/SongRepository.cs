using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using mono_lvl3.Common;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Models.DomainModels;
using AutoMapper;
using mono_lvl3.DAL.DbContext;
using mono_lvl3.Repository.Repositories;
using mono_lvl3.Repository.Common;

namespace mono_lvl3.Repository
{
    public class SongRepository : GenericRepository<DataContext, Song>
    {
        IGenericRepository<Song> repository;

        public SongRepository(SongRepository repository)
        {
            this.repository = repository;
        }
    }
}
