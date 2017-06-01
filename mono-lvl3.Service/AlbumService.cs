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

        public Task<int> AddAsync(IAlbum album)
        {
            return Repository.AddAsync(album);
        }

        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }

        public Task<IEnumerable<IAlbum>> GetAsync(IFilter filter = null)
        {
            return Repository.GetAsync(filter);
        }

        public Task<IAlbum> GetByIDAsync(Guid id)
        {
            return Repository.GetByIDAsync(id);
        }

        public Task<int> UpdateAsync(IAlbum album)
        {
            return Repository.UpdateAsync(album);
        }

        #endregion Methods

    }
}
