using AutoMapper;
using Webapi.DBOperations;
using Webapi.Entities;

namespace Webapi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public UpdateAuthorModel AuthorModel { get; set; }
        public int AuthorId { get; set; }

        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Author bulunamdı");
            }

            author.Name = AuthorModel.Name != default ? AuthorModel.Name : author.Name;
            author.Surname = AuthorModel.Surname != default ? AuthorModel.Surname : author.Surname;
            _dbContext.SaveChanges();
        }
    }




    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}