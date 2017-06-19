using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Model.Common
{
    public interface ISong
    {
        Guid Id { get; set; }
        string Name { get; set; }
        decimal Duration { get; set; }
        string Genre { get; set; }
        Guid AlbumId { get; set; }

        IAlbum Album { get; set; }
        ICollection<IArtist> Artists { get; set; }
    }
}
