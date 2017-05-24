﻿using System;
using System.Collections.Generic;

namespace mono_lvl3.Models.DomainModels
{
    public class AlbumDomainModel
    {
        public AlbumDomainModel()
        {
            
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime Relased { get; set; }

        public virtual ICollection<ArtistDomainModel> Artists { get; set; }
        public virtual ICollection<SongDomainModel> Songs { get; set; }
    }
}
