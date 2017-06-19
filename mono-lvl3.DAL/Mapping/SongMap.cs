using mono_lvl3.DAL.EntityModels;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;

namespace mono_lvl3.DAL.Mapping
{
    public class SongMap : EntityTypeConfiguration<Song>
    {
        public SongMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name).HasMaxLength(50);

            this.Property(t => t.Duration);

            this.Property(t => t.Genre).HasMaxLength(50);

            // Table and Column mappings
            this.ToTable("Songs");
            this.Property(t => t.Name).HasColumnName("SongName").HasColumnType("NVarchar");
            this.Property(t => t.Duration).HasColumnName("SongDuration").HasColumnType("Decimal").HasPrecision(18, 2);
            this.Property(t => t.Genre).HasColumnName("Genre").HasColumnType("NVarchar");


            // Relationships

            // 1-* (Album-Song)
            //this.HasRequired(t => t.Album)
            //    .WithMany(t => t.Songs)
            //    .HasForeignKey(d => d.Album_Id);

            this.HasKey(t => t.AlbumId);

            // *-* (Song-Artist)
            this.HasMany(t => t.Artists)
                .WithMany(t => t.Songs);
        }
    }
}
