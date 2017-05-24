using mono_lvl3.Models.DomainModels;
using System;
using System.Collections.Generic;

namespace mono_lvl3.Repository.Common
{
    public interface IAlbumRepository
    {
        IEnumerable<AlbumDomainModel> GetAll();
        AlbumDomainModel Get(Guid id);
        void Add(AlbumDomainModel Album);
        void Update(AlbumDomainModel Album);
        void Remove(Guid id);
    }
}
