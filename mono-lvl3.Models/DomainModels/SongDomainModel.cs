using System;
using System.Collections.Generic;

namespace mono_lvl3.Models.DomainModels
{
    public class SongDomainModel
    {
        public SongDomainModel()
        {
            
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Duration { get; set; }
        public string Genre { get; set; }
        public Guid AlbumId { get; set; }

        public virtual AlbumDomainModel Album { get; set; }
        public virtual ICollection<ArtistDomainModel> Artists { get; set; }
    }
}
