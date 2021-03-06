﻿using System;
using System.Collections.Generic;
using mono_lvl3.Model.Common;

namespace mono_lvl3.Model.DomainModels
{
    public class AlbumDomainModel : IAlbum
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<IArtist> Artists { get; set; }
        public virtual ICollection<ISong> Songs { get; set; }
    }
}
