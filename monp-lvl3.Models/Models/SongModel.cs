namespace mono_lvl3.Models.Models
{
    using System;
    using System.Collections.Generic;

    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Duration { get; set; }
        public string Genre { get; set; }
        public Guid AlbumId { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}