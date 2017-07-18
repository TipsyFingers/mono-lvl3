using System;
using System.Collections.Generic;
using mono_lvl3.Model.Common;

namespace mono_lvl3.Model.DomainModels
{
    public class SongDomainModel : ISong
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Duration { get; set; }
        public string Genre { get; set; }
        public Guid AlbumId { get; set; }

        //public virtual IAlbum Album { get; set; }
        public virtual ICollection<IArtist> Artists { get; set; }
    }
}
