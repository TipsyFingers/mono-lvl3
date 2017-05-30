﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using mono_lvl3.Common.Filters;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Models.DomainModels;
using mono_lvl3.Models.Common;
using mono_lvl3.Repository.Common;
using AutoMapper;

namespace mono_lvl3.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        #region Properties

        protected IGenericRepository Repository { get; private set; }

        #endregion Properties

        #region Constructors

        public ArtistRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Methods

        public virtual async Task<IEnumerable<ArtistPOCO>> GetAsync(IFilter filter = null)
        {
            if (filter != null)
            {
                var artists = Mapper.Map<IEnumerable<ArtistPOCO>>(
                    await Repository.GetWhere<Artist>()
                    .OrderBy(a => a.LName)
                    .ToListAsync());

                if (!string.IsNullOrWhiteSpace(filter.SearchString))
                {
                    artists = artists.Where(a => a.ArtistName.ToUpper()
                        .Contains(filter.SearchString.ToUpper()))
                        .ToList();
                }

                return artists;
            }
            else
            {
                return Mapper.Map<IEnumerable<ArtistPOCO>>(await Repository.GetWhere<Artist>().ToListAsync());
            }
        }

        public virtual async Task<IArtist> GetByIDAsync(Guid id)
        {
            return Mapper.Map<ArtistPOCO>(await Repository.GetWhere<Artist>().Where(a => a.Id == id).FirstOrDefaultAsync());
        }

        public virtual Task<int> AddAsync(IArtist artist)
        {
            return Repository.AddAsync<Artist>(Mapper.Map<Artist>(artist));
        }

        public virtual Task<int> UpdateAsync(IArtist artist)
        {
            return Repository.UpdateAsync<Artist>(Mapper.Map<Artist>(artist));
        }

        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<Artist>(id);
        }

        #endregion Methods
    }
}
