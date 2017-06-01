using mono_lvl3.DAL.EntityModels;
using System.Data.Entity.ModelConfiguration;

namespace mono_lvl3.DAL.Mapping
{
    public class AlbumMap : EntityTypeConfiguration<Album>
    {
        public AlbumMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name).HasMaxLength(50);

            this.Property(t => t.Genre).HasMaxLength(50);

            this.Property(t => t.Price);

            this.Property(t => t.Relased);

            // Table and Column mappings
            this.ToTable("Artist");
            this.Property(t => t.Name).HasColumnName("AlbumName").HasColumnType("NVarchar");
            this.Property(t => t.Genre).HasColumnName("Genre").HasColumnType("NVarchar");
            this.Property(t => t.Price).HasColumnName("Price").HasColumnType("Decimal").HasPrecision(18, 2);
            this.Property(t => t.Relased).HasColumnName("RelaseDate").HasColumnType("DateTime");


            // Relationships

            // *-* (Album-Artist)
            this.HasMany(t => t.Artists)
                .WithMany(t => t.Albums);
        }
    }
}
