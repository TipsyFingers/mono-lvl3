using System;
using System.Collections.Generic;

namespace mono_lvl3.DAL.EntityModels
{
    public class Artist
    {
        public Artist()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string ArtistName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string From { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
