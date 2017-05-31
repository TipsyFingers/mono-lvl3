using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using mono_lvl3.Repository.Common;
using mono_lvl3.Service.Common;

namespace mono_lvl3.Services
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

        public Task<IEnumerable<ISong>> GetAsync(IFilter filter = null)
        {
            return Repository.GetAsync(filter);
        }

        public Task<ISong> GetByIDAsync(Guid id)
        {
            return Repository.GetByIDAsync(id);
        }

        public Task<int> AddAsync(ISong song)
        {
            return Repository.AddAsync(song);
        }

        public Task<int> UpdateAsync(ISong song)
        {
            return Repository.UpdateAsync(song);
        }

        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }

        #endregion Methods
    }
}
