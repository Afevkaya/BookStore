using Microsoft.EntityFrameworkCore;
using Webapi.Entities;

namespace Webapi.DBOperations
{
    // Db operasyonları için kullanılacak olan DB Context'i yaratılması
    // Veritabanındaki tablomuz ile projemizde bulunan entityleri maplediğimiz sınıf.
    
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }  
        public DbSet<Author> Authors { get; set; }  
    }
}