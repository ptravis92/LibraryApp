using API.Models;
using Bogus;

namespace API.Data;

public class DataGenerator
{
    Faker<User> user;
    Faker<Book> book;
    Faker<Review> review;
    Faker<Author> author;
    Faker<Publisher> publisher;

    public DataGenerator()
    {
        Randomizer.Seed = new Random(500);

        user = new Faker<User>()
            .RuleFor(user => user.Name, faker => faker.Name.FullName())
            .RuleFor(user => user.TypeId, 2);

        var users = user.Generate(50);

        author = new Faker<Author>()
            .RuleFor(author => author.Name, faker => faker.Name.FullName());

        var authors = author.Generate(100);

        publisher = new Faker<Publisher>()
            .RuleFor(publisher => publisher.Name, faker => faker.Company.CompanyName());

        var publishers = publisher.Generate(50);

        book = new Faker<Book>()
            .RuleFor(book => book.Title, faker => faker.Lorem.Sentence(1,5))
            .RuleFor(book => book.AuthorId, faker => faker.Random.Int(1, 100))
            .RuleFor(book => book.Description, faker => faker.Lorem.Paragraph(2))
            .RuleFor(book => book.CoverImage, faker => faker.Image.PlaceImgUrl())
            .RuleFor(book => book.PublisherId, faker => faker.Random.Int(1, 50))
            .RuleFor(book => book.CategoryId, faker => faker.Random.Int(1, 8))
            .RuleFor(book => book.CategoryId, faker => faker.Random.Int(1, 8))
            .RuleFor(book => book.ISBN, faker => faker.Random.Digits(13).ToString())
            .RuleFor(book => book.PageCount, faker => faker.Random.Int(100, 500));

        var books = book.Generate(500);

        review = new Faker<Review>()
            .RuleFor(review => review.UserId, faker => faker.Random.Int(1, 50))
            .RuleFor(review => review.BookId, faker => faker.Random.Int(1, 500))
            .RuleFor(review => review.Rating, faker => faker.Random.Int(1, 5))
            .RuleFor(review => review.Body, faker => faker.Lorem.Paragraph(3));

        var reviews = review.Generate(100);
    }
}
