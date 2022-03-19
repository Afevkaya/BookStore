using Webapi.DBOperations;

namespace Webapi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public UpdateGenreModel GenreModel { get; set; }
        public int GenreId { get; set; }


        public UpdateGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            if (_dbContext.Genres.Any(x => x.Name == GenreModel.Name && x.Id != GenreId))
            {
                throw new InvalidOperationException("Aynı isimli kitap türü zaten bulunmaktadır.");
            }

            genre.Name = GenreModel.Name.Trim() == default ? genre.Name  : GenreModel.Name;
            genre.isActive = GenreModel.isActive;
            _dbContext.SaveChanges();

        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; } = true;
    }
}