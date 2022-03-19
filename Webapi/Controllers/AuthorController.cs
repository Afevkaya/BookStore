using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.AuthorOperations.Commands.CreateAuthor;
using Webapi.Application.AuthorOperations.Commands.DeleteAuthor;
using Webapi.Application.AuthorOperations.Commands.UpdateAuthor;
using Webapi.Application.AuthorOperations.Queries.GetAuthorDetail;
using Webapi.Application.AuthorOperations.Queries.GetAuthors;
using Webapi.Application.BookOperations.Commands.CreateBook;
using Webapi.Application.BookOperations.Commands.DeleteBook;
using Webapi.Application.BookOperations.Commands.UpdateBook;
using Webapi.Application.BookOperations.Queries.GetBookDetail;
using Webapi.Application.BookOperations.Queries.GetBooksQuery;
using Webapi.DBOperations;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();

            query.AuthorId = id;
            validator.ValidateAndThrow(query);
            var result = query.Handle();

            return Ok(result);

        }

        [HttpPost] 
        public IActionResult AddAuthor([FromBody] CreateAuthorModel model)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();

            command.AuthorModel = model;
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel model)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();

            command.AuthorId = id;
            command.AuthorModel = model;
            
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            
            command.AuthorId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }
    }
}