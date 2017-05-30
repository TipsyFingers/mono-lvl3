using mono_lvl3.Common.Filters;
using mono_lvl3.Models.Common;
using mono_lvl3.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mono_lvl3.Repository.Common
{
    public interface IArtistRepository
    {
        Task<IEnumerable<ArtistPOCO>> GetAsync(IFilter filter = null);
        Task<IArtist> GetByIDAsync(Guid id);
        Task<int> AddAsync(IArtist artist);
        Task<int> UpdateAsync(IArtist artist);
        Task<int> DeleteAsync(Guid id);
    }
}
