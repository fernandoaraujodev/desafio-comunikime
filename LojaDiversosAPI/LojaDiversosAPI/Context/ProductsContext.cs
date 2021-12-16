using LojaDiversosAPI.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace LojaDiversosAPI.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }


        // String de conexão com o banco
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }


        // Modelando o DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region TabelaProduct

            modelBuilder.Entity<Product>().ToTable("Products");
            //Chave Primaria
            modelBuilder.Entity<Product>().Property(x => x.Id);
            //Name
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(40);
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnType("varchar(40)");
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();
            //Price
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("float");
            modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired();
            //Available Quantity 
            modelBuilder.Entity<Product>().Property(x => x.AvailableQuantity).HasColumnType("int");
            modelBuilder.Entity<Product>().Property(x => x.AvailableQuantity).IsRequired();
            //Description
            modelBuilder.Entity<Product>().Property(x => x.Description).HasColumnType("Text");
            modelBuilder.Entity<Product>().Property(x => x.Description).IsRequired();
            //UrlImage
            modelBuilder.Entity<Product>().Property(x => x.UrlImage).HasMaxLength(250);
            modelBuilder.Entity<Product>().Property(x => x.UrlImage).HasColumnType("varchar(250)");
            modelBuilder.Entity<Product>().Property(x => x.UrlImage).IsRequired();
            //CreationDate
            modelBuilder.Entity<Product>().Property(t => t.CreationDate).HasColumnType("DateTime");
            modelBuilder.Entity<Product>().Property(t => t.CreationDate).HasDefaultValueSql("GetDate()");
            //ChangeDate     
            modelBuilder.Entity<Product>().Property(t => t.ChangeDate).HasColumnType("DateTime");
            modelBuilder.Entity<Product>().Property(t => t.ChangeDate).HasDefaultValueSql("GetDate()");
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
