using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using mono_lvl3.Common.Filters;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Model.DomainModels;
using mono_lvl3.Model.Common;
using mono_lvl3.Repository.Common;
using AutoMapper;

namespace mono_lvl3.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        #region Properties

        protected IGenericRepository Repository { get; private set; }

        #endregion Properties

        #region Constructors

        public AlbumRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Methods

        public virtual async Task<IEnumerable<IAlbum>> GetAsync(IFilter filter = null)
        {
            if (filter != null)
            {
                var album = Mapper.Map<IEnumerable<AlbumPOCO>>(
                    await Repository.GetWhere<Album>()
                    .OrderBy(a => a.Name)
                    .ToListAsync());

                if (!string.IsNullOrWhiteSpace(filter.SearchString))
                {
                    album = album.Where(a => a.Name.ToUpper()
                        .Contains(filter.SearchString.ToUpper()))
                        .ToList();
                }

                return album;
            }
            else
            {
                return Mapper.Map<IEnumerable<IAlbum>>(await Repository.GetWhere<Album>().ToListAsync());
            }
        }

        public virtual async Task<IAlbum> GetByIDAsync(Guid id)
        {
            return Mapper.Map<AlbumPOCO>(await Repository.GetWhere<Album>().Where(a => a.Id == id).FirstOrDefaultAsync());
        }

        public virtual Task<int> AddAsync(IAlbum album)
        {
            return Repository.AddAsync<Album>(Mapper.Map<Album>(album));
        }

        public virtual Task<int> UpdateAsync(IAlbum album)
        {
            return Repository.UpdateAsync<Album>(Mapper.Map<Album>(album));
        }

        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<Album>(id);
        }

        #endregion Methods
    }
}
