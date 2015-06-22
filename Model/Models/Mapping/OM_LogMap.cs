using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_LogMap : EntityTypeConfiguration<OM_Log>
    {
        public OM_LogMap()
        {
            // Primary Key
            this.HasKey(t => t.Guid);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.User_Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Operation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Doc_Name)
                .HasMaxLength(32);

            this.Property(t => t.Doc_View)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("OM_Log");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.User_Guid).HasColumnName("User_Guid");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.CreateDatetime).HasColumnName("CreateDatetime");
            this.Property(t => t.Operation).HasColumnName("Operation");
            this.Property(t => t.Doc_Name).HasColumnName("Doc_Name");
            this.Property(t => t.Doc_View).HasColumnName("Doc_View");
        }
    }
}
