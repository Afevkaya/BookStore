using FluentValidation;

namespace Webapi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    { 
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0).WithMessage("BookId 0 dan büyük olmalı");
        }

    }
}