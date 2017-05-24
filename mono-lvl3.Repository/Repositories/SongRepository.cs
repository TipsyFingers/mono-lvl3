using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using mono_lvl3.Repository.Common;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.DAL.DbContext;
using mono_lvl3.Models.DomainModels;
using AutoMapper;

namespace mono_lvl3.Repository
{
    class SongRepository : ISongRepository
    {
        private DataContext _db = new DataContext();

        public IEnumerable<SongDomainModel> GetAll()
        {
            List<Song> data = _db.SongsModel.ToList();

            return Mapper.Map(data, new List<SongDomainModel>());
        }

        public SongDomainModel Get(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID is null");
            }

            Song data = _db.SongsModel.Where(m => m.Id == id).FirstOrDefault();

            if (data == null)
            {
                throw new ArgumentNullException("MODEL is null");
            }

            return Mapper.Map(data, new SongDomainModel());
        }

        public void Add(SongDomainModel songDM)
        {
            if (songDM == null)
            {
                throw new ArgumentNullException("SONG is null");
            }

            Song song = new Song();

            song = Mapper.Map(songDM, song);

            _db.SongsModel.Add(song);
            _db.SaveChanges();
        }

        public void Update(SongDomainModel songDM)
        {
            if (songDM == null)
            {
                throw new ArgumentNullException("SONG is null");
            }

            Song song = new Song();
            song = Mapper.Map(songDM, song);

            _db.SongsModel.AddOrUpdate(song);
            _db.SaveChanges();
        }

        public void Remove(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID is null");
            }

            _db.SongsModel.Remove(_db.SongsModel.Where(m => m.Id == id).FirstOrDefault());
            _db.SaveChanges();
        }
    }
}
