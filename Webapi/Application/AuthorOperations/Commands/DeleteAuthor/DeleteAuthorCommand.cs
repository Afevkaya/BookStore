using Webapi.DBOperations;

namespace Webapi.Application.AuthorOperations.Commands.DeleteAuthor 
{
    public class DeleteAuthorCommand 
    {
        private readonly BookStoreDbContext _dbcontext;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if(author is null)
            {
                throw new InvalidOperationException("Author bulunamadı");
            }

            // Book kontrol işlemi yapılacak
            
            _dbcontext.Authors.Remove(author);
            _dbcontext.SaveChanges();
        }
    }
}