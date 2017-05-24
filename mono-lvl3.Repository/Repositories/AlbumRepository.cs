using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using mono_lvl3.Repository.Common;
using mono_lvl3.DAL.DbContext;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Models.DomainModels;
using AutoMapper;

namespace mono_lvl3.Repository
{
    public abstract class AlbumRepository : IAlbumRepository
    {
        private DataContext _db = new DataContext();
        readonly IAlbumRepository albumRepositroy;

        public AlbumRepository(IAlbumRepository albumRepository)
        {
            this.albumRepositroy = albumRepository;
        }

        public IEnumerable<AlbumDomainModel> GetAll()
        {
            List<Album> data = _db.AlbumsModel.ToList();

            return Mapper.Map(data, new List<AlbumDomainModel>());
        }

        public AlbumDomainModel Get(Guid id)
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

            return Mapper.Map(data, new AlbumDomainModel());
        }

        public void Add(AlbumDomainModel albumDM)
        {
            if (albumDM == null)
            {
                throw new ArgumentNullException("ALBUM is null");
            }

            Album album = new Album();

            album = Mapper.Map(albumDM, album);

            _db.AlbumsModel.Add(album);
            _db.SaveChanges();
        }

        public void Update(AlbumDomainModel albumDM)
        {
            if (albumDM == null)
            {
                throw new ArgumentNullException("ALBUM is null");
            }

            Album album = new Album();

            album = Mapper.Map(albumDM, album);

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
