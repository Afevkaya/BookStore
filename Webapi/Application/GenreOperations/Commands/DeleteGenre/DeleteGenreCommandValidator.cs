using FluentValidation;

namespace Webapi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command=>command.GenreId).GreaterThan(0).WithMessage("Genre Id 0 dan büyük olmalıdır.");
        }
    }
}