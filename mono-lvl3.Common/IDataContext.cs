using mono_lvl3.DAL.EntityModels;
using System.Data.Entity;

namespace mono_lvl3.Common
{
    public interface IDataContext
    {
        DbSet<Artist> ArtistsModel { get; set; }
        DbSet<Album> AlbumsModel { get; set; }
        DbSet<Song> SongsModel { get; set; }
    }
}
