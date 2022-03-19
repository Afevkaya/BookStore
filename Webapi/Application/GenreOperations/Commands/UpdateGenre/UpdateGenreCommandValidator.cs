using FluentValidation;

namespace Webapi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0).WithMessage("Genre Id 0 dan büyük olmalıdır.");
            RuleFor(command => command.GenreModel.Name).MinimumLength(4).WithMessage("Genre Name en az  4 karakter içermelidir.")
                .When(x=>x.GenreModel.Name.Trim() != string.Empty);
        }
    }
}