using AutoMapper;
using Webapi.DBOperations;
using Webapi.Entities;

namespace Webapi.Application.GenreOperations.Queries.GetGenreDetail 
{
    public class GetGenreDetailQuery 
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int GenreId { get; set; }

        public GetGenreDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.isActive && x.Id == GenreId);
            if (genre is null) 
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            
            GenreDetailViewModel model = _mapper.Map<GenreDetailViewModel>(genre);
            return model; 

        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}