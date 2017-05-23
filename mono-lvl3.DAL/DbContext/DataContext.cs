namespace mono_lvl3.DAL.DbContext
{
    using EntityModels;
    using System;
    using System.Data.Entity;
    using System.Linq;


    public class DataContext : DbContext
    {
        public DataContext() : base("name=mono-lvl3") { }

        public virtual DbSet<Artist> ArtistsModel { get; set; }
        public virtual DbSet<Album> AlbumsModel { get; set; }
        public virtual DbSet<Song> SongsModel { get; set; }
    }
}