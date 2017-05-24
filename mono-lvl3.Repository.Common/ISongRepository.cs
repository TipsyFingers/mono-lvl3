using mono_lvl3.Models.DomainModels;
using System;
using System.Collections.Generic;

namespace mono_lvl3.Repository.Common
{
    public interface ISongRepository
    {
        IEnumerable<SongDomainModel> GetAll();
        SongDomainModel Get(Guid id);
        void Add(SongDomainModel song);
        void Update(SongDomainModel song);
        void Remove(Guid id);
    }
}
