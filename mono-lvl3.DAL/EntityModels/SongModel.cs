using System;
using System.Collections.Generic;

namespace mono_lvl3.DAL.EntityModels
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Duration { get; set; }
        public string Genre { get; set; }
        public Guid Album_Id { get; set; }

        public virtual Album Album { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
