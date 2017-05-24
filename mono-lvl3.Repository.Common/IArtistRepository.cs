using mono_lvl3.Models.DomainModels;
using System;
using System.Collections.Generic;

namespace mono_lvl3.Repository.Common
{
    public interface IArtistRepository
    {
        IEnumerable<ArtistDomainModel> GetAll();
        ArtistDomainModel Get(Guid id);
        void Add(ArtistDomainModel artistDM);
        void Update(ArtistDomainModel artist);
        void Remove(Guid id);
    }
}
