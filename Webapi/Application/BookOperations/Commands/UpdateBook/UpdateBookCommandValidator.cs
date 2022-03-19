using FluentValidation;

namespace Webapi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand> 
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0).WithMessage("BookId 0 dan büyük olmalıdır");
            RuleFor(command => command.updatedBookModel.GenreId).GreaterThan(0).WithMessage("GenreId 0 dan büyük olmalı.");

            RuleFor(command => command.updatedBookModel.Title).NotEmpty().WithMessage("Title Boş olamaz").MinimumLength(4).WithMessage("Title 4 karakterden büyük olmalı.");
        }
    }
}