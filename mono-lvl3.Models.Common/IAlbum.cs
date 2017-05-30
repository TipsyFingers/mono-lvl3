using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Models.Common
{
    public interface IAlbum
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Genre { get; set; }
        decimal Price { get; set; }
        DateTime Relased { get; set; }

        ICollection<IArtist> Artists { get; set; }
        ICollection<ISong> Songs { get; set; }
    }
}
