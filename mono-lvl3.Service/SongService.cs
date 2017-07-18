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
    public class SongService : ISongService
    {
        #region Properties

        protected ISongRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public SongService(ISongRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        public async Task<IEnumerable<ISong>> GetAsync(IFilter filter = null)
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

        public async Task<ISong> GetByIDAsync(Guid id)
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

        public async Task<int> AddAsync(ISong song)
        {
            try
            {
                return await Repository.AddAsync(song);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> UpdateAsync(ISong song)
        {
            try
            {
                return await Repository.UpdateAsync(song);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IAlbum> AddArtistsToSongAsync(Guid id, IEnumerable<Guid> artistIds)
        {
            try
            {
                return await Repository.AddArtistsToSongAsync(id, artistIds);
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


        // Za popunjavanje dropdown liste za odabir albuma na kojemu se nalazi pjesma
        //public IEnumerable<IAlbum> GetAlbumsAsync()
        //{
        //    return Repository.GetAlbumsAsync();
        //}

        #endregion Methods
    }
}
