using System;
using System.Collections.Generic;
using System.Linq;
using mono_lvl3.Repository.Common;
using mono_lvl3.DAL.DbContext;
using mono_lvl3.DAL.EntityModels;
using System.Data.Entity.Migrations;

namespace mono_lvl3.Repository
{
    class AlbumRepository : IAlbumRepository
    {
        private DataContext _db = new DataContext();

        public IEnumerable<Album> GetAll()
        {
            List<Album> data = _db.AlbumsModel.ToList();
            return data;
        }

        public Album Get(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID is null");
            }

            Album data = _db.AlbumsModel.Where(m => m.Id == id).FirstOrDefault();

            if (data == null)
            {
                throw new ArgumentNullException("MODEL is null");
            }

            return data;
        }

        public void Add(Album album)
        {
            if (album == null)
            {
                throw new ArgumentNullException("ALBUM is null");
            }

            _db.AlbumsModel.Add(album);
            _db.SaveChanges();
        }

        public void Update(Album album)
        {
            if (album == null)
            {
                throw new ArgumentNullException("ALBUM is null");
            }

            _db.AlbumsModel.AddOrUpdate(album);
            _db.SaveChanges();
        }

        public void Remove(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID is null");
            }

            _db.AlbumsModel.Remove(_db.AlbumsModel.Where(m => m.Id == id).FirstOrDefault());
            _db.SaveChanges();
        }
    }
}
