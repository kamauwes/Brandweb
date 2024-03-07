using Brandweb.Models.Domains;
using Microsoft.EntityFrameworkCore;


namespace User.Data
{
    public class UsersDbContext: DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
       // public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //put our configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(a => a.Product_Id);
                entity.Property(a => a.Product_Name)
                .IsRequired();
                entity.HasOne(a => a.Inventory)
                .WithOne(p => p.Product)
                .HasForeignKey<Inventory>(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

              /*  entity.HasOne(a => a.Stock)
               .WithOne(p => p.Product)
               .HasForeignKey<Inventory>(p => p.ProductId)
               .OnDelete(DeleteBehavior.NoAction);
              */
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(a => a.Order_Id);
                entity.Property(a => a.Product_Name)
                .IsRequired();

                entity.HasOne(a => a.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.UserName)
                .IsRequired();

            });
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(a => a.InventoryId);
                entity.Property(a => a.ProductName)
                .IsRequired();

            }); modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(a => a.DetailsId);
                entity.Property(a => a.UnitPrice)
                .IsRequired();

                entity.HasOne(a=>a.Order)
                .WithMany(p=>p.OrderDetails)
                .HasForeignKey(p=>p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a=>a.Product)
                .WithMany(p=>p.OrderDetails)
                .HasForeignKey(p=>p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            });

          /*  modelBuilder.Entity<publisher>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                .IsRequired();
            });

            modelBuilder.Entity<BookPublisher>(entity =>
            {
                entity.HasKey(bp => new { bp.PublisherId, bp.BookId });

                entity.HasOne(bp => bp.Book)
                .WithMany(b => b.BookPublishers)
                .HasForeignKey(bp => bp.BookId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(bp => bp.Publisher)
                .WithMany(b => b.BookPublishers)
                .HasForeignKey(bp => bp.PublisherId)
                .OnDelete(DeleteBehavior.NoAction);
            });*/
        }

    }

}
