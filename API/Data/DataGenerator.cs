using API.Models;
using Bogus;

namespace API.Data;

public class DataGenerator
{
    private Faker<User> user;
    private Faker<Book> book;
    private Faker<Review> review;
    private Faker<Author> author;
    private Faker<Publisher> publisher;
    public List<User> users;
    public List<Book> books;
    public List<Review> reviews;
    public List<Author> authors;
    public List<Publisher> publishers;

    public DataGenerator()
    {
        int id = 1;
        Randomizer.Seed = new Random(500);

        user = new Faker<User>()
            .RuleFor(user => user.Id, faker => id++)
            .RuleFor(user => user.UserName, faker => faker.Name.FullName())
            //.RuleFor(user => user.RoleId, 2)
            ;

        users = user.Generate(50);

        author = new Faker<Author>()
            .RuleFor(author => author.Id, faker => id++)
            .RuleFor(author => author.Name, faker => faker.Name.FullName());

        authors = author.Generate(100);

        publisher = new Faker<Publisher>()
            .RuleFor(publisher => publisher.Id, faker => id++)
            .RuleFor(publisher => publisher.Name, faker => faker.Company.CompanyName());

        publishers = publisher.Generate(50);

        book = new Faker<Book>()
            .RuleFor(book => book.Id, faker => id++)
            .RuleFor(book => book.Title, faker => faker.Lorem.Sentence(1,5))
            .RuleFor(book => book.AuthorId, faker => faker.PickRandom(authors).Id)
            .RuleFor(book => book.Description, faker => faker.Lorem.Paragraph(2))
            .RuleFor(book => book.CoverImage, faker => $"https://picsum.photos/id/{faker.Random.Int(1, 500)}")
            .RuleFor(book => book.PublisherId, faker => faker.PickRandom(publishers).Id)
            .RuleFor(book => book.CategoryId, faker => faker.Random.Int(1, 8))
            .RuleFor(book => book.ISBN, faker => faker.Random.Digits(13).ToString())
            .RuleFor(book => book.PageCount, faker => faker.Random.Int(100, 500))
            .RuleFor(book => book.PublicationDate, faker => faker.Date.Between(DateTime.Now.AddYears(-100), DateTime.Now))
            .RuleFor(book => book.CheckedOutUntil, faker => faker.Date.Between(DateTime.Now.AddDays(7), DateTime.Now.AddDays(12)).OrNull(faker, .7f))
            ;

        books = book.Generate(500);

        var userIdsReviewIds = books.Where(book => book != null)
            .SelectMany(book => users.Where(user => user != null)
                .Select(user => new {BookId = book.Id, UserId = user.Id}))
            .ToList();

        review = new Faker<Review>()
            .RuleFor(review => review.UserId, faker => userIdsReviewIds[id++].UserId)
            .RuleFor(review => review.BookId, faker => userIdsReviewIds[id++].BookId)
            .RuleFor(review => review.Rating, faker => faker.Random.Int(1, 5))
            .RuleFor(review => review.Body, faker => faker.Lorem.Paragraph(3));

        reviews = review.Generate(100);
    }
}
