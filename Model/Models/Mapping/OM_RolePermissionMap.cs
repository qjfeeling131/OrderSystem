using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_RolePermissionMap : EntityTypeConfiguration<OM_RolePermission>
    {
        public OM_RolePermissionMap()
        {
            // Primary Key
            this.HasKey(t => t.Guid);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Role_Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Permission_Guid)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OM_RolePermission");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.Role_Guid).HasColumnName("Role_Guid");
            this.Property(t => t.Permission_Guid).HasColumnName("Permission_Guid");
            this.Property(t => t.IsDel).HasColumnName("IsDel");
            this.Property(t => t.CreateDatetime).HasColumnName("CreateDatetime");
            this.Property(t => t.UpdateDatetime).HasColumnName("UpdateDatetime");
        }
    }
}
