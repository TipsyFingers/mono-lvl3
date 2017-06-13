namespace mono_lvl3.DAL.DbContext
{
    using EntityModels;
    using Mapping;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("name=mono-lvl3") { }

        public virtual DbSet<Artist> ArtistsModel { get; set; }
        public virtual DbSet<Album> AlbumsModel { get; set; }
        public virtual DbSet<Song> SongsModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().ToTable("Artists");
            modelBuilder.Entity<Album>().ToTable("Albums");
            modelBuilder.Entity<Song>().ToTable("Songs");
        }
    }


    public interface IDataContext : IDisposable
    {
        DbSet<Artist> ArtistsModel { get; set; }
        DbSet<Album> AlbumsModel { get; set; }
        DbSet<Song> SongsModel { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync();
    }

}