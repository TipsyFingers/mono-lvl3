﻿using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mono_lvl3.Repository.Common
{
    public interface ISongRepository
    {
        Task<IEnumerable<ISong>> GetAsync(IFilter filter = null);
        Task<ISong> GetByIDAsync(Guid id);
        Task<int> AddAsync(ISong song);
        Task<int> UpdateAsync(ISong song);
        Task<IAlbum> AddArtistsToSongAsync(Guid id, IEnumerable<Guid> artistIds);
        Task<int> DeleteAsync(Guid id);

        // Za popunjavanje dropdown liste za odabir albuma na kojemu se nalazi pjesma
        //IEnumerable<IAlbum> GetAlbumsAsync();
    }
}
