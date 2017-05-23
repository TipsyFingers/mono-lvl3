using System;
using System.Collections.Generic;
using System.Linq;
using mono_lvl3.Repository.Common;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.DAL.DbContext;
using System.Data.Entity.Migrations;

namespace mono_lvl3.Repository
{
    class SongRepository : ISongRepository
    {
        private DataContext _db = new DataContext();

        public IEnumerable<Song> GetAll()
        {
            List<Song> data = _db.SongsModel.ToList();
            return data;
        }

        public Song Get(Guid id)
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

            return data;
        }

        public void Add(Song song)
        {
            if (song == null)
            {
                throw new ArgumentNullException("SONG is null");
            }

            _db.SongsModel.Add(song);
            _db.SaveChanges();
        }

        public void Update(Song song)
        {
            if (song == null)
            {
                throw new ArgumentNullException("SONG is null");
            }

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
