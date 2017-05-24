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
    public abstract class ArtistRepository : IArtistRepository
    {
        private DataContext _db = new DataContext();
        readonly IArtistRepository artistRepository;

        public ArtistRepository(IArtistRepository artistRepositroy)
        {
            this.artistRepository = artistRepositroy;
        }

        public IEnumerable<ArtistDomainModel> GetAll()
        {
            List<Artist> data = _db.ArtistsModel.ToList();

            return Mapper.Map(data, new List<ArtistDomainModel>());
        }

        public ArtistDomainModel Get(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID is null");
            }

            Artist data = _db.ArtistsModel.Where(m => m.Id == id).FirstOrDefault();

            if (data == null)
            {
                throw new ArgumentNullException("MODEL is null");
            }

            return Mapper.Map(data, new ArtistDomainModel());
        }

        public void Add(ArtistDomainModel artistDM)
        {
            if (artistDM == null)
            {
                throw new ArgumentNullException("ARTIST is null");
            }

            Artist artist = new Artist();

            artist = Mapper.Map(artistDM, artist);

            _db.ArtistsModel.Add(artist);
            _db.SaveChanges();
        }

        public void Update(ArtistDomainModel artistDM)
        {
            if (artistDM == null)
            {
                throw new ArgumentNullException("ARTIST is null");
            }

            Artist artist = new Artist();
            artist = Mapper.Map(artistDM, artist);

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
