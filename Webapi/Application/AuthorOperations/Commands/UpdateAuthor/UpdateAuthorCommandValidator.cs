using AutoMapper;
using FluentValidation;
using Webapi.DBOperations;
using Webapi.Entities;

namespace Webapi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command=>command.AuthorId).GreaterThan(0).WithMessage("Author Id 0dan büyük olmalıdır.");
            RuleFor(command=>command.AuthorModel.Name).NotEmpty().WithMessage("Author Name boş olamaz").MinimumLength(5).WithMessage("Author Name 5 karakterden uzun olmalıdır.");
            RuleFor(command=>command.AuthorModel.Surname).NotEmpty().WithMessage("Author Surname boş olamaz").MinimumLength(5).WithMessage("Author Surname 5 karakterden uzun olmalıdır.");
        }
    }
}