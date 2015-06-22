using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_PermissionMap : EntityTypeConfiguration<OM_Permission>
    {
        public OM_PermissionMap()
        {
            // Primary Key
            this.HasKey(t => t.Guid);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AreaName)
                .HasMaxLength(50);

            this.Property(t => t.ControllerName)
                .HasMaxLength(50);

            this.Property(t => t.ActionName)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("OM_Permission");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.AreaName).HasColumnName("AreaName");
            this.Property(t => t.ControllerName).HasColumnName("ControllerName");
            this.Property(t => t.ActionName).HasColumnName("ActionName");
            this.Property(t => t.FormMethod).HasColumnName("FormMethod");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.IsDel).HasColumnName("IsDel");
            this.Property(t => t.CreateDatetime).HasColumnName("CreateDatetime");
            this.Property(t => t.UpdateDateTime).HasColumnName("UpdateDateTime");
            this.Property(t => t.IsAdmin).HasColumnName("IsAdmin");
        }
    }
}
