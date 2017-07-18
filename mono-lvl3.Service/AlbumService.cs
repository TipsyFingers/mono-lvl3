using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using mono_lvl3.Repository.Common;
using mono_lvl3.Service.Common;
using System.Linq;

namespace mono_lvl3.Service
{
    public class AlbumService : IAlbumService
    {
        #region Properties

        protected IAlbumRepository Repository { get; private set; }
        protected IArtistRepository ArtistRepository { get; private set; }

        #endregion Properties


        #region Constructors

        public AlbumService(IAlbumRepository repository, IArtistRepository artistRepository)
        {
            this.Repository = repository;
            this.ArtistRepository = artistRepository;
        }

        #endregion Constructors


        #region Methods

        public async Task<IEnumerable<IAlbum>> GetAsync(IFilter filter = null)
        {
            try
            {
                return await Repository.GetAsync(filter);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public async Task<IAlbum> GetByIDAsync(Guid id)
        {
            try
            {
                return await Repository.GetByIDAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> AddAsync(IAlbum album)
        {
            try
            {
                return await Repository.AddAsync(album);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> UpdateAsync(IAlbum album)
        {
            try
            {
                return await Repository.UpdateAsync(album);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IAlbum> AddArtistsToAlbumAsync(Guid id, IEnumerable<Guid> artistIds)
        {
            try
            {
                return await Repository.AddArtistsToAlbumAsync(id, artistIds);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await Repository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion Methods
    }
}
