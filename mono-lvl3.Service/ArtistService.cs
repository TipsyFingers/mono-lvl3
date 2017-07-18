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

        public async Task<IEnumerable<IArtist>> GetAsync(IFilter filter = null)
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

        public async Task<IArtist> GetByIDAsync(Guid id)
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

        public async Task<int> AddAsync(IArtist artist)
        {
            try
            {
                return await Repository.AddAsync(artist);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> UpdateAsync(IArtist artist)
        {
            try
            {
                return Repository.UpdateAsync(artist);
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
