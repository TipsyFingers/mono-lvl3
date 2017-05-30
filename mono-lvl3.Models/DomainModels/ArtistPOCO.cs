using System;
using System.Collections.Generic;
using mono_lvl3.Models.Common;

namespace mono_lvl3.Models.DomainModels
{
    public class ArtistPOCO : IArtist
    {
        public Guid Id { get; set; }
        public string ArtistName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string From { get; set; }

        public virtual ICollection<IAlbum> Albums { get; set; }
        public virtual ICollection<ISong> Songs { get; set; }
    }
}
