using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Models.Common
{
    public interface IArtist
    {
        Guid Id { get; set; }
        string ArtistName { get; set; }
        string FName { get; set; }
        string LName { get; set; }
        string From { get; set; }

        ICollection<IAlbum> Albums { get; set; }
        ICollection<ISong> Songs { get; set; }
    }
}
