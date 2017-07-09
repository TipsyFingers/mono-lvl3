using mono_lvl3.Model.Common;
using System;
using System.Collections.Generic;

namespace mono_lvl3.Web_API.ViewModels
{
    public class AlbumViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<IArtist> Artists { get; set; }
        public virtual ICollection<ISong> Songs { get; set; }
    }
}