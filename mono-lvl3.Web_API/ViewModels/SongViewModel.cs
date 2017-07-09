using mono_lvl3.Model.Common;
using System;
using System.Collections.Generic;

namespace mono_lvl3.Web_API.ViewModels
{
    public class SongViewModel
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