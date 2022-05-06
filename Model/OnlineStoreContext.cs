using Microsoft.EntityFrameworkCore;

namespace Session12.ProductManager.Model
{
    public class OnlineStoreContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //    .HasData(Product.FakeData.Generate(40));

            //modelBuilder.Entity<Person>()
            //    .HasData(Person.FakeData.Generate(30));
            
        } 
    }
}
