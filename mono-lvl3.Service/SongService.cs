using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using mono_lvl3.Repository.Common;
using mono_lvl3.Service.Common;

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
            IUnitOfWork unitOfWork = await Repository.CreateUnitOfWork();

            await Repository.AddAsync(unitOfWork, song);
            return await unitOfWork.CommitAsync();
        }

        public async Task<int> UpdateAsync(ISong song)
        {
            IUnitOfWork unitOfWork = await Repository.CreateUnitOfWork();

            await Repository.UpdateAsync(unitOfWork, song);
            return await unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            IUnitOfWork unitOfWork = await Repository.CreateUnitOfWork();

            await Repository.DeleteAsync(unitOfWork, id);
            return await unitOfWork.CommitAsync();
        }

        #endregion Methods
    }
}
