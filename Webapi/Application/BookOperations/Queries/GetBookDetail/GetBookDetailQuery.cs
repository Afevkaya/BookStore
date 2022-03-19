using Webapi.DBOperations;
using AutoMapper;
using Webapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // Kullanıcıya gösterilecek ViewModel 
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).Where(book => book.Id == BookId).SingleOrDefault<Book>();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }

            BookDetailViewModel bookDetail = _mapper.Map<BookDetailViewModel>(book);

            return bookDetail;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }


}