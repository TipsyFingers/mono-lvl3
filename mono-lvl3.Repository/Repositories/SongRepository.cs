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
    public class SongRepository : ISongRepository
    {
        #region Properties

        protected IGenericRepository Repository { get; private set; }

        #endregion Properties

        #region Constructors

        public SongRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Methods

        public virtual async Task<IEnumerable<ISong>> GetAsync(IFilter filter = null)
        {
            if (filter != null)
            {
                var song = Mapper.Map<IEnumerable<SongPOCO>>(
                    await Repository.GetWhere<Song>()
                    .OrderBy(a => a.Name)
                    .ToListAsync());

                if (!string.IsNullOrWhiteSpace(filter.SearchString))
                {
                    song = song.Where(a => a.Name.ToUpper()
                        .Contains(filter.SearchString.ToUpper()))
                        .ToList();
                }

                return song;
            }
            else
            {
                return Mapper.Map<IEnumerable<SongPOCO>>(await Repository.GetWhere<Song>().ToListAsync());
            }
        }

        public virtual async Task<ISong> GetByIDAsync(Guid id)
        {
            return Mapper.Map<SongPOCO>(await Repository.GetWhere<Song>().Where(a => a.Id == id).FirstOrDefaultAsync());
        }

        public virtual Task<int> AddAsync(ISong song)
        {
            return Repository.AddAsync<Song>(Mapper.Map<Song>(song));
        }

        public virtual Task<int> UpdateAsync(ISong song)
        {
            return Repository.UpdateAsync<Song>(Mapper.Map<Song>(song));
        }

        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<Song>(id);
        }

        #endregion Methods
    }
}
