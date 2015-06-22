using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_AreaMap : EntityTypeConfiguration<OM_Area>
    {
        public OM_AreaMap()
        {
            // Primary Key
            this.HasKey(t => t.Guid);

            // Properties
            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.AreaCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.Name)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("OM_Area");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.AreaCode).HasColumnName("AreaCode");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
