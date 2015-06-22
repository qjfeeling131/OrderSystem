using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_UserMap : EntityTypeConfiguration<OM_User>
    {
        public OM_UserMap()
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

            this.Property(t => t.Pwd)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Post)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(150);

            this.Property(t => t.Img)
                .HasMaxLength(250);

            this.Property(t => t.Account)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Key)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("OM_User");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Pwd).HasColumnName("Pwd");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Post).HasColumnName("Post");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Img).HasColumnName("Img");
            this.Property(t => t.IsDel).HasColumnName("IsDel");
            this.Property(t => t.CreateDatetime).HasColumnName("CreateDatetime");
            this.Property(t => t.UpdateDatetime).HasColumnName("UpdateDatetime");
            this.Property(t => t.Account).HasColumnName("Account");
            this.Property(t => t.Key).HasColumnName("Key");
        }
    }
}
