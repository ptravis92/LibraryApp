using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options, DataGenerator generator) : IdentityDbContext<User, Role, int>(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<UserType> UserTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(user => user.Role)
            .WithMany(role => role.Users)
            .HasForeignKey(user => user.RoleId)
            .IsRequired();

        modelBuilder.Entity<Role>()
            .HasMany(role => role.Users)
            .WithOne(user => user.Role)
            .HasForeignKey(user => user.RoleId)
            .IsRequired();

        modelBuilder.Entity<Review>()
            .HasKey(review => new {review.BookId, review.UserId});

        modelBuilder.Entity<Book>()
            .HasOne(book => book.Author)
            .WithMany(author => author.Books)
            .HasForeignKey(book => book.AuthorId)
            .IsRequired();

        new DbInitializer(modelBuilder, generator).Seed();
    }
}


public class DbInitializer(ModelBuilder modelBuilder, DataGenerator generator)
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

        modelBuilder.Entity<User>().HasData(generator.users);
        modelBuilder.Entity<Book>().HasData(generator.books);
        modelBuilder.Entity<Author>().HasData(generator.authors);
        modelBuilder.Entity<Publisher>().HasData(generator.publishers);
        modelBuilder.Entity<Review>().HasData(generator.reviews);
    }
}

