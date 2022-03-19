using FluentValidation;

namespace Webapi.Application.BookOperations.Commands.CreateBook
{
    // Classın bir validate classı olabilmesi için AbstractValidator abstact sınıfını implement etmesi gerekir.
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0).WithMessage("GenreId 0 dan büyük olmalı.");
            RuleFor(command => command.Model.PageCount).GreaterThan(0).WithMessage("Page Count 0 dan büyük olmalı.");
            RuleFor(command => command.Model.PublishDate).NotEmpty().WithMessage("DateTime Boş olamaz")
                    .LessThan(DateTime.Now.Date).WithMessage("Date Time gelecek bir tarih olamaz");
            RuleFor(command => command.Model.Title).NotEmpty().WithMessage("Title Boş olamaz").MinimumLength(4).WithMessage("Title 4 karakterden büyük olmalı.");
        }
    }
}