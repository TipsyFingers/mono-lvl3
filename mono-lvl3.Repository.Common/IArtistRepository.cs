using mono_lvl3.DAL.EntityModels;
using System;
using System.Collections.Generic;

namespace mono_lvl3.Repository.Common
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAll();
        Artist Get(Guid id);
        void Add(Artist artist);
        void Update(Artist artist);
        void Remove(Guid id);
    }
}
