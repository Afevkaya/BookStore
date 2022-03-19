using FluentValidation;

namespace Webapi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand> 
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0).WithMessage("Author Id 0 dan büyük olmalıdır.");
        }
    }
}