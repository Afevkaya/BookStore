using Webapi;
using Webapi.DBOperations;
using Webapi.Comman;
using AutoMapper;
using Webapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Application.BookOperations.Queries.GetBooksQuery
{
    public class GetBooksQuery 
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // Veritabanından gelen Entity classını ViewModel'a mapledik
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x=>x.Genre).Include(x=>x.Author).OrderBy(book => book.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }   
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}