using mono_lvl3.DAL.EntityModels;
using System;
using System.Collections.Generic;

namespace mono_lvl3.Repository.Common
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAll();
        Album Get(Guid id);
        void Add(Album Album);
        void Update(Album Album);
        void Remove(Guid id);
    }
}
