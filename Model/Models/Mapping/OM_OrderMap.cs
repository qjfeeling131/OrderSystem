using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_OrderMap : EntityTypeConfiguration<OM_Order>
    {
        public OM_OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Guid);

            // Properties
            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CardCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CardName)
                .HasMaxLength(100);

            this.Property(t => t.DocStatus)
                .HasMaxLength(1);

            this.Property(t => t.User_Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TPLCompany)
                .HasMaxLength(50);

            this.Property(t => t.TPLOrder)
                .HasMaxLength(20);

            this.Property(t => t.TPLContact)
                .HasMaxLength(20);

            this.Property(t => t.TPLPhone)
                .HasMaxLength(15);

            this.Property(t => t.NumCard)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OM_Order");
            this.Property(t => t.DocEntry).HasColumnName("DocEntry");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.CardCode).HasColumnName("CardCode");
            this.Property(t => t.CardName).HasColumnName("CardName");
            this.Property(t => t.DocStatus).HasColumnName("DocStatus");
            this.Property(t => t.DocDate).HasColumnName("DocDate");
            this.Property(t => t.DocDueDate).HasColumnName("DocDueDate");
            this.Property(t => t.User_Guid).HasColumnName("User_Guid");
            this.Property(t => t.TPLCompany).HasColumnName("TPLCompany");
            this.Property(t => t.TPLOrder).HasColumnName("TPLOrder");
            this.Property(t => t.TPLContact).HasColumnName("TPLContact");
            this.Property(t => t.TPLPhone).HasColumnName("TPLPhone");
            this.Property(t => t.NumCard).HasColumnName("NumCard");
            this.Property(t => t.NoteNotice).HasColumnName("NoteNotice");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
        }
    }
}
