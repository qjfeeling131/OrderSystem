using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_UserRoleMap : EntityTypeConfiguration<OM_UserRole>
    {
        public OM_UserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Guid);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.User_Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Role_Guid)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OM_UserRole");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.User_Guid).HasColumnName("User_Guid");
            this.Property(t => t.Role_Guid).HasColumnName("Role_Guid");
            this.Property(t => t.IsDel).HasColumnName("IsDel");
            this.Property(t => t.CreateDatetime).HasColumnName("CreateDatetime");
            this.Property(t => t.UpdateDateTime).HasColumnName("UpdateDateTime");
        }
    }
}
