using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_OrderItemMap : EntityTypeConfiguration<OM_OrderItem>
    {
        public OM_OrderItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Guid);

            // Properties
            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LineNum)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ItemCode)
                .HasMaxLength(50);

            this.Property(t => t.ItemName)
                .HasMaxLength(100);

            this.Property(t => t.ItemFName)
                .HasMaxLength(100);

            this.Property(t => t.Flag)
                .HasMaxLength(1);

            this.Property(t => t.WhsCode)
                .HasMaxLength(30);

            this.Property(t => t.Currency)
                .HasMaxLength(10);

            this.Property(t => t.Img)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("OM_OrderItem");
            this.Property(t => t.DocEntry).HasColumnName("DocEntry");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.LineNum).HasColumnName("LineNum");
            this.Property(t => t.VisualOrder).HasColumnName("VisualOrder");
            this.Property(t => t.ItemCode).HasColumnName("ItemCode");
            this.Property(t => t.ItemName).HasColumnName("ItemName");
            this.Property(t => t.ItemFName).HasColumnName("ItemFName");
            this.Property(t => t.Flag).HasColumnName("Flag");
            this.Property(t => t.WhsCode).HasColumnName("WhsCode");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.OpenQty).HasColumnName("OpenQty");
            this.Property(t => t.CloseQty).HasColumnName("CloseQty");
            this.Property(t => t.Currency).HasColumnName("Currency");
            this.Property(t => t.Img).HasColumnName("Img");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
        }
    }
}
