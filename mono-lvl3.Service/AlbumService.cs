using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using mono_lvl3.Repository.Common;
using mono_lvl3.Service.Common;


namespace mono_lvl3.Service
{
    public class AlbumService : IAlbumService
    {
        #region Properties

        protected IAlbumRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public AlbumService(IAlbumRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors


        #region Methods

        public async Task<IEnumerable<IAlbum>> GetAsync(IFilter filter = null)
        {
            return await Repository.GetAsync(filter);
        }

        public async Task<IAlbum> GetByIDAsync(Guid id)
        {
            return await Repository.GetByIDAsync(id);
        }

        public async Task<int> AddAsync(IAlbum album)
        {
            IUnitOfWork unitOfWork = await Repository.CreateUnitOfWork();

            await Repository.AddAsync(album);
            return await unitOfWork.CommitAsync();
        }

        public async Task<int> UpdateAsync(IAlbum album)
        {
            return await Repository.UpdateAsync(album);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Repository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(params Guid[] id)
        {
            try
            {
                IUnitOfWork unitOfWork = await Repository.CreateUnitOfWork();
                foreach (Guid i in id)
                {
                    await unitOfWork.DeleteAsync<IArtist>(i);
                }
                return await unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion Methods
    }
}
