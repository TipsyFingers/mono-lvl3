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
            return await Repository.GetAsync(filter);
        }

        public async Task<ISong> GetByIDAsync(Guid id)
        {
            return await Repository.GetByIDAsync(id);
        }

        public async Task<int> AddAsync(ISong song)
        {
            return await Repository.AddAsync(song);
        }

        public async Task<int> UpdateAsync(ISong song)
        {
            return await Repository.UpdateAsync(song);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Repository.DeleteAsync(id);
        }


        // Za popunjavanje dropdown liste za odabir albuma na kojemu se nalazi pjesma
        //public IEnumerable<IAlbum> GetAlbumsAsync()
        //{
        //    return Repository.GetAlbumsAsync();
        //}

        #endregion Methods
    }
}
