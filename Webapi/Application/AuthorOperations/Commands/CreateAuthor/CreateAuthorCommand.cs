using AutoMapper;
using Webapi.DBOperations;
using Webapi.Entities;

namespace Webapi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorModel AuthorModel { get; set; }
        public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Name == AuthorModel.Name);
            if(author is not null)
            {
                throw new InvalidOperationException("Yazar zaten bulunmaktadır");
            }

            author = _mapper.Map<Author>(AuthorModel);
            _dbContext.Add(author);
            _dbContext.SaveChanges();

        }

    }

    public class CreateAuthorModel 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}