using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_ProductPriceMap : EntityTypeConfiguration<OM_ProductPrice>
    {
        public OM_ProductPriceMap()
        {
            // Primary Key
            this.HasKey(t => t.Guid);

            // Properties
            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Product_ItemCode)
                .HasMaxLength(20);

            this.Property(t => t.Department_Guid)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("OM_ProductPrice");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Product_ItemCode).HasColumnName("Product_ItemCode");
            this.Property(t => t.Department_Guid).HasColumnName("Department_Guid");
        }
    }
}
