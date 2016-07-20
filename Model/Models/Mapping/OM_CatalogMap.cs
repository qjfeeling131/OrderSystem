using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model.Models.Mapping
{
    public class OM_CatalogMap : EntityTypeConfiguration<OM_Catalog>
    {
        public OM_CatalogMap()
        {
            // Primary Key
            this.HasKey(t => t.Guid);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ParentId)
                .HasMaxLength(50);

            this.Property(t => t.CatalogName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CatalogDescride)
                .HasMaxLength(50);



            // Table & Column Mappings
            this.ToTable("OM_Catalog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.CatalogCode).HasColumnName("CatalogCode");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.CatalogDescride).HasColumnName("CatalogDescride");
            this.Property(t => t.CatalogName).HasColumnName("CatalogName");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.Updated).HasColumnName("Updated");
            this.Property(t => t.Remarks).HasColumnName("Remarks");

        }
    }
}
