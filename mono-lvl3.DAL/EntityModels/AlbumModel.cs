using System;
using System.Collections.Generic;

namespace mono_lvl3.DAL.EntityModels
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
