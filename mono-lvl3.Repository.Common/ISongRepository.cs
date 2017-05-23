using mono_lvl3.DAL.EntityModels;
using System;
using System.Collections.Generic;

namespace mono_lvl3.Repository.Common
{
    public interface ISongRepository
    {
        IEnumerable<Song> GetAll();
        Song Get(Guid id);
        void Add(Song song);
        void Update(Song song);
        void Remove(Guid id);
    }
}
