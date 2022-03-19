using Microsoft.EntityFrameworkCore;
using Webapi.Entities;
using Webapi.DBOperations;

namespace WebApi.DBOperations
{
    // Initial Data için bir Data Generator'ın yazılması
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange(
                    new Author { 
                        Name = "Fyodor",
                        Surname = "Dostoyevski",
                        BirthDate = DateTime.Now
                    },
                    new Author { 
                        Name = "Stefan",
                        Surname = "Zweig",
                        BirthDate = DateTime.Now
                    },
                    new Author { 
                        Name = "Franz",
                        Surname = "Kafka",
                        BirthDate = DateTime.Now
                    }
                );

                context.Genres.AddRange(
                    new Genre {
                        Name = "Personal Growth"
                    },
                    new Genre {
                        Name = "Science Fiction"
                    },
                    new Genre {
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book {
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12),
                        AuthorId = 1
                    },
                    new Book {
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,23),
                        AuthorId = 2
                    },
                    new Book {
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2001,12,21),
                        AuthorId = 3
                    }
                );

                context.SaveChanges();
            }
        }
    }
}