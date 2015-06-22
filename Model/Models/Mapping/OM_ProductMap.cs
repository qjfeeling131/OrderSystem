using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_ProductMap : EntityTypeConfiguration<OM_Product>
    {
        public OM_ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemCode);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ItemCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ItemName)
                .HasMaxLength(100);

            this.Property(t => t.FrgnName)
                .HasMaxLength(100);

            this.Property(t => t.GroupType)
                .HasMaxLength(10);

            this.Property(t => t.CardCode)
                .HasMaxLength(15);

            this.Property(t => t.WhsCode)
                .HasMaxLength(15);

            this.Property(t => t.Img)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("OM_Product");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.ItemCode).HasColumnName("ItemCode");
            this.Property(t => t.ItemName).HasColumnName("ItemName");
            this.Property(t => t.FrgnName).HasColumnName("FrgnName");
            this.Property(t => t.OnHand).HasColumnName("OnHand");
            this.Property(t => t.GroupType).HasColumnName("GroupType");
            this.Property(t => t.GroupAPrice).HasColumnName("GroupAPrice");
            this.Property(t => t.GroupBPrice).HasColumnName("GroupBPrice");
            this.Property(t => t.GroupCPrice).HasColumnName("GroupCPrice");
            this.Property(t => t.CardCode).HasColumnName("CardCode");
            this.Property(t => t.WhsCode).HasColumnName("WhsCode");
            this.Property(t => t.Img).HasColumnName("Img");
            this.Property(t => t.IsDel).HasColumnName("IsDel");
            this.Property(t => t.CreateDatetime).HasColumnName("CreateDatetime");
            this.Property(t => t.UpdateDateTime).HasColumnName("UpdateDateTime");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
        }
    }
}
