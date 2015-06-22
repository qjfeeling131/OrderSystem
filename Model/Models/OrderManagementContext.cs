using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OrderManager.Model.Models.Mapping;

namespace OrderManager.Model.Models
{
    public partial class OrderManagementContext : DbContext
    {
        static OrderManagementContext()
        {
            Database.SetInitializer<OrderManagementContext>(null);
        }

        public OrderManagementContext()
            : base("Name=OrderManagementContext")
        {
        }

        public DbSet<OM_Area> OM_Area { get; set; }
        public DbSet<OM_AreaDepatment> OM_AreaDepatment { get; set; }
        public DbSet<OM_Department> OM_Department { get; set; }
        public DbSet<OM_Log> OM_Log { get; set; }
        public DbSet<OM_MessageBoard> OM_MessageBoard { get; set; }
        public DbSet<OM_Order> OM_Order { get; set; }
        public DbSet<OM_OrderItem> OM_OrderItem { get; set; }
        public DbSet<OM_Permission> OM_Permission { get; set; }
        public DbSet<OM_Product> OM_Product { get; set; }
        public DbSet<OM_ProductPrice> OM_ProductPrice { get; set; }
        public DbSet<OM_Role> OM_Role { get; set; }
        public DbSet<OM_RolePermission> OM_RolePermission { get; set; }
        public DbSet<OM_User> OM_User { get; set; }
        public DbSet<OM_UserRole> OM_UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OM_AreaMap());
            modelBuilder.Configurations.Add(new OM_AreaDepatmentMap());
            modelBuilder.Configurations.Add(new OM_DepartmentMap());
            modelBuilder.Configurations.Add(new OM_LogMap());
            modelBuilder.Configurations.Add(new OM_MessageBoardMap());
            modelBuilder.Configurations.Add(new OM_OrderMap());
            modelBuilder.Configurations.Add(new OM_OrderItemMap());
            modelBuilder.Configurations.Add(new OM_PermissionMap());
            modelBuilder.Configurations.Add(new OM_ProductMap());
            modelBuilder.Configurations.Add(new OM_ProductPriceMap());
            modelBuilder.Configurations.Add(new OM_RoleMap());
            modelBuilder.Configurations.Add(new OM_RolePermissionMap());
            modelBuilder.Configurations.Add(new OM_UserMap());
            modelBuilder.Configurations.Add(new OM_UserRoleMap());
        }
    }
}
