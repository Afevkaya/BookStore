using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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
    public class BookController : ControllerBase
    {
        // Servisler'i projede kullanabilmek için önce program.cs dosyasına eklemek gerekli.
        // Ayrıca kullanacağınız yerde instance'nı oluşturmamız gerekli.

        // Proje içerisinde kullanacağımız servislerin instanceları
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        // Dependency Injection
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();


            return Ok(result);

        }


        // Post,Put,Delete işlemlerinde kullanıcıya bir response döner.
        // Bu response, işlemin iyi veya kötü sonuçlandığını kullanıcıya bildirmek içindir.
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.updatedBookModel = updatedBook;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();


            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {


            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

    }
}