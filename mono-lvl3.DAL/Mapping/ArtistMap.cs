using mono_lvl3.DAL.EntityModels;
using System.Data.Entity.ModelConfiguration;

namespace mono_lvl3.DAL.Mapping
{
    public class ArtistMap : EntityTypeConfiguration<Artist>
    {
        public ArtistMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ArtistName).HasMaxLength(50);

            this.Property(t => t.FName).HasMaxLength(50);

            this.Property(t => t.LName).HasMaxLength(50);

            this.Property(t => t.From).HasMaxLength(50);

            // Table and Column mappings
            this.ToTable("Artists");
            this.Property(t => t.ArtistName).HasColumnName("ArtistName").HasColumnType("NVarchar");
            this.Property(t => t.FName).HasColumnName("FirstName").HasColumnType("NVarchar");
            this.Property(t => t.LName).HasColumnName("LastName").HasColumnType("NVarchar");
            this.Property(t => t.From).HasColumnName("From").HasColumnType("NVarchar");

            // Relationships

            // *-* (Artist-Song)
            this.HasMany(t => t.Songs)
                .WithMany(t => t.Artists);

            // *-* (Artist-Album)
            this.HasMany(t => t.Albums)
                 .WithMany(t => t.Artists);
        }
    }
}
