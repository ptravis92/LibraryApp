using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<UserType> UserTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>()
            .HasKey(review => new {review.BookId, review.UserId});
        new DbInitializer(modelBuilder).Seed();
    }
}


public class DbInitializer(ModelBuilder modelBuilder)
{
    public void Seed()
    {
        modelBuilder.Entity<UserType>().HasData(
            new UserType() { Id = 1, Name = "Librarian" },
            new UserType() { Id = 2, Name = "Customer" }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Mystery" },
            new Category() { Id = 2, Name = "Historical Fiction" },
            new Category() { Id = 3, Name = "Fantasy" },
            new Category() { Id = 4, Name = "Science Fiction" },
            new Category() { Id = 5, Name = "Horror" },
            new Category() { Id = 6, Name = "NonFiction" },
            new Category() { Id = 7, Name = "Adventure" },
            new Category() { Id = 8, Name = "Romance" }
        );
    }
}

