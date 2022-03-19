using Webapi.DBOperations;

namespace Webapi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand 
    {
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookModel updatedBookModel { get; set; }
        public int BookId { get; set; }

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }

            book.Title = updatedBookModel.Title != default ? updatedBookModel.Title : book.Title;
            book.GenreId = updatedBookModel.GenreId != default ? updatedBookModel.GenreId : book.GenreId;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }   
        public int GenreId { get; set; }

    }
}