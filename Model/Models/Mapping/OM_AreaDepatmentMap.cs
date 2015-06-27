using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_AreaDepatmentMap : EntityTypeConfiguration<OM_AreaDepatment>
    {
        public OM_AreaDepatmentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Guid, t.Department_Guid, t.Area_Guid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Department_Guid)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Area_Guid)
                .IsRequired()
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("OM_AreaDepatment");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.Department_Guid).HasColumnName("Department_Guid");
            this.Property(t => t.Area_Guid).HasColumnName("Area_Guid");
        }
    }
}
