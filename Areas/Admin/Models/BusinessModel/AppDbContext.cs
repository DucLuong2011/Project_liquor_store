using Microsoft.EntityFrameworkCore;
using Project_WAD.Areas.Admin.Models.BusinessModel;
using Project_WAD.Areas.Admin.Models.DataModel;

namespace Project_WAD.Areas.Admin.Models.BusinessModel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // khai báo thêm ràng buộc UNIQUE
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
            // khai báo khóa chính trên nhiều trường cho bảng OrderDetail
            modelBuilder.Entity<OrderDetail>()
                 .HasKey(c => new { c.OrderId, c.ProductId });
        }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
