using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TM6P1HI\\SQLEXPRESS;Database=StoreDb;Trusted_Connection=True;");
        }
        public DbSet<Category> Category { get; set; }

        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<AddToCart> AddToCart { get; set; }

        public DbSet<WishList> WishList { get; set; }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<UserDefn> UserDefn { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name)
                                .IsRequired()
                                .HasMaxLength(100);
            });
            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.ProdType)
                                   .IsRequired()
                                   .HasMaxLength(100);
                entity.HasOne(x => x.Category)
                           .WithMany(x => x.ProductType).HasForeignKey(x => x.CategoryId);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.ProductType)
                            .WithMany(x => x.Product).HasForeignKey(x => x.ProductTypeId);

                entity.Property(x => x.ProductName)
                          .IsRequired()
                          .HasMaxLength(100);

                entity.Property(x => x.Specification)
                          .IsRequired()
                          .HasMaxLength(100);

                entity.Property(x => x.Description)
                         .IsRequired()
                         .HasMaxLength(1000);

                entity.Property(x => x.Picture)
                       .IsRequired()
                        .HasMaxLength(200);

                entity.Property(x => x.Price)
                       .IsRequired()
                       .HasMaxLength(100);

                entity.Property(x => x.AddQuantity)
                       .IsRequired()
                       .HasMaxLength(100);

                entity.Property(x => x.InStock)
                     .IsRequired()
                     .HasMaxLength(100);
              
                entity.Property(x => x.IsDeleted);

            });
            modelBuilder.Entity<AddToCart>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Product)
                         .WithMany(x => x.AddToCart).HasForeignKey(x => x.ProductId);
                /*entity.HasOne(x => x.UserDefn)
                       .WithMany(x => x.AddToCart).HasForeignKey(x => x.UserId);*/

                entity.HasOne(x => x.OrderDetails)
                       .WithMany(x => x.AddToCart).HasForeignKey(x => x.OrderDetailsId); 



                 entity.Property(x => x.Quantity);
                                     /*  .IsRequired();*/

                entity.Property(x => x.TotalPrice)
                        /*  .IsRequired()*/
                          .HasMaxLength(30);

                entity.Property(x => x.IsPurchased)
                       /*  .IsRequired()*/
                       .HasMaxLength(30);


            });

              modelBuilder.Entity<WishList>(entity =>
              {
                  entity.HasKey(x => x.Id);

                   entity.HasOne(x => x.Product)
                               .WithMany(x => x.WishList).HasForeignKey(x => x.ProductId);

                  entity.HasOne(x => x.UserDefn)
                               .WithMany(x => x.WishList).HasForeignKey(x => x.UserId);
               
              });


            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.AddToCart)
                             .WithMany(x => x.Orders).HasForeignKey(x => x.CartId);

                entity.Property(x => x.OrderDate)
                            .IsRequired()
                            .HasMaxLength(30);

                entity.Property(x => x.OrderTime)
                           .IsRequired()
                           .HasMaxLength(30);

               

              /*  entity.HasOne(x => x.OrderDetails)
                             .WithMany(x => x.Orders).HasForeignKey(x => x.OrderDetailsId);*/

                entity.HasOne(x => x.Status)
                            .WithMany(x => x.Orders).HasForeignKey(x => x.StatusId);

            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.StatusName)
                            .IsRequired()
                            .HasMaxLength(100);


            });

          
           

        

            modelBuilder.Entity<UserDefn>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.UserName)
                     .IsRequired()
                     .HasMaxLength(100);

                entity.Property(x => x.Password)
                        .IsRequired()
                        .HasMaxLength(100);

                entity.Property(x => x.EmailId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.RoleName)
                  .IsRequired()
                  .HasMaxLength(100);

            });
            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(x => x.Id);


                entity.HasOne(x => x.UserDefn)
                         .WithMany(x => x.OrderDetails).HasForeignKey(x => x.UserId);

                entity.Property(x => x.ContactNo)
                         .IsRequired()
                         .HasMaxLength(30);

                entity.Property(x => x.DeliveryAddress)
                            .IsRequired()
                            .HasMaxLength(100);

                entity.Property(x => x.Pincode)
                           .IsRequired()
                           .HasMaxLength(20);
            });


        }

    }
}
