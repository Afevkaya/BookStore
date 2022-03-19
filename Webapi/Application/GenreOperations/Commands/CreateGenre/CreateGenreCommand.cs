using AutoMapper;
using Webapi.DBOperations;
using Webapi.Entities;

namespace Webapi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreModel GenreModel { get; set; }

        public CreateGenreCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == GenreModel.Name);
            if (genre is not null)
            {
                throw new InvalidOperationException("Kitap türü zaten bulunmaktadır");
            }

            genre = new Genre();
            genre.Name = GenreModel.Name;
            _dbContext.Add(genre);
            _dbContext.SaveChanges();
        }


    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}