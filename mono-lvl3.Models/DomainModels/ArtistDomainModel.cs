using System;
using System.Collections.Generic;

namespace mono_lvl3.Models.DomainModels
{
    public class ArtistDomainModel
    {
        public ArtistDomainModel()
        {
            
        }

        public Guid Id { get; set; }
        public string ArtistName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string From { get; set; }

        public virtual ICollection<AlbumDomainModel> Albums { get; set; }
        public virtual ICollection<SongDomainModel> Songs { get; set; }
    }
}
