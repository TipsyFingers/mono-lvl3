using System;
using System.Collections.Generic;
using System.Linq;
using mono_lvl3.Repository.Common;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.DAL.DbContext;
using System.Data.Entity.Migrations;

namespace mono_lvl3.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private DataContext _db = new DataContext();

        public IEnumerable<Artist> GetAll()
        {
            List<Artist> data = _db.ArtistsModel.ToList();
            return data;
        }

        public Artist Get(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("ID is null");
            }

            Artist data = _db.ArtistsModel.Where(m => m.Id == id).FirstOrDefault();

            if(data == null)
            {
                throw new ArgumentNullException("MODEL is null");
            }

            return data;
        }

        public void Add(Artist artist)
        {
            if(artist == null)
            {
                throw new ArgumentNullException("ARTIST is null");
            }

            _db.ArtistsModel.Add(artist);
            _db.SaveChanges();
        }

        public void Update(Artist artist)
        {
            if (artist == null)
            {
                throw new ArgumentNullException("ARTIST is null");
            }

            _db.ArtistsModel.AddOrUpdate(artist);
            _db.SaveChanges();
        }

        public void Remove(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID is null");
            }

            _db.ArtistsModel.Remove(_db.ArtistsModel.Where(m => m.Id == id).FirstOrDefault());
            _db.SaveChanges();
        }
    }
}
