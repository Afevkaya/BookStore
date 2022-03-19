using AutoMapper;
using Webapi.DBOperations;
using Webapi.Entities;

namespace Webapi.Application.AuthorOperations.Queries.GetAuthorDetail
{

    public class GetAuthorDetailQuery 
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }


        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        

        public AuthorDetailViewModel Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Id == AuthorId);
            if (author is null)
            {   
                throw new InvalidOperationException("Yazar Bulunamdı");
            }

            var result = _mapper.Map<AuthorDetailViewModel>(author);
            return result;
        }

    }

    public class AuthorDetailViewModel 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
    }
}
