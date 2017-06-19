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

        public async Task<IEnumerable<IArtist>> GetAsync(IFilter filter = null)
        {
            return await Repository.GetAsync(filter);
        }

        public async Task<IArtist> GetByIDAsync(Guid id)
        {
            return await Repository.GetByIDAsync(id);
        }

        public async Task<int> AddAsync(IArtist artist)
        {
            IUnitOfWork unitOfWork = await Repository.CreateUnitOfWork();

            await Repository.AddAsync(artist);
            return await unitOfWork.CommitAsync();
        }

        public Task<int> UpdateAsync(IArtist artist)
        {
            return Repository.UpdateAsync(artist);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Repository.DeleteAsync(id);
        }

        #endregion Methods
    }
}
