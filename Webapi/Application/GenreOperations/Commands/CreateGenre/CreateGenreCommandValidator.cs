using FluentValidation;

namespace Webapi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.GenreModel.Name).NotEmpty().WithMessage("Tür adı boş olamaz").MinimumLength(4).WithMessage("Tür adi en az 4 karakterden oluşmalıdır.");
        }
    }
}