using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using mono_lvl3.Repository.Common;
using mono_lvl3.Service.Common;

namespace mono_lvl3.Service
{
    public class ArtistService : IArtistService
    {
        #region Properties

        protected IArtistRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public ArtistService(IArtistRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        public Task<IEnumerable<IArtist>> GetAsync(IFilter filter = null)
        {
            return Repository.GetAsync(filter);
        }

        public Task<IArtist> GetByIDAsync(Guid id)
        {
            return Repository.GetByIDAsync(id);
        }

        public Task<int> AddAsync(IArtist artist)
        {
            return Repository.AddAsync(artist);
        }

        public Task<int> UpdateAsync(IArtist artist)
        {
            return Repository.UpdateAsync(artist);
        }

        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }

        #endregion Methods

    }
}
