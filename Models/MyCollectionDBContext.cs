using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MyCollection.Models
{
    public class MyCollectionDBContext : DbContext
    {

        
        public DbSet<User>Users { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;

        public MyCollectionDBContext()
        {

        }
      
        public MyCollectionDBContext(DbContextOptions<MyCollectionDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyCollectionDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    
        

    }
}
