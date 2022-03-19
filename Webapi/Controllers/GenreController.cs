using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.GenreOperations.Commands.CreateGenre;
using Webapi.Application.GenreOperations.Commands.DeleteGenre;
using Webapi.Application.GenreOperations.Commands.UpdateGenre;
using Webapi.Application.GenreOperations.Queries.GetGenreDetail;
using Webapi.Application.GenreOperations.Queries.GetGenres;
using Webapi.DBOperations;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_dbContext, _mapper);
            var genres = query.Handle();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenre(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_dbContext, _mapper);
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            
            query.GenreId = id;
            validator.ValidateAndThrow(query);
            var genre = query.Handle();

            return Ok(genre);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_dbContext, _mapper);
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            
            command.GenreModel = newGenre;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_dbContext);
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();

            command.GenreId = id;
            command.GenreModel = updateGenre;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            
            command.GenreId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}