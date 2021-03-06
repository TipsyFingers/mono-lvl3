﻿using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mono_lvl3.Repository.Common
{
    public interface IArtistRepository
    {
        Task<IEnumerable<IArtist>> GetAsync(IFilter filter = null);
        Task<IArtist> GetByIDAsync(Guid id);
        Task<int> AddAsync(IArtist artist); /// INT umjesto interface
        Task<int> UpdateAsync(IArtist artist);
        Task<int> DeleteAsync(Guid id);
    }
}
