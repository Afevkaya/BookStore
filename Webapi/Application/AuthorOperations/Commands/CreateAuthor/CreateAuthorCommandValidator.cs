using AutoMapper;
using FluentValidation;
using Webapi.DBOperations;
using Webapi.Entities;

namespace Webapi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorModel.Name).NotEmpty().WithMessage("Author name boş olamaz")
                .MinimumLength(4).WithMessage("Author name minimum 4 karakterden oluşmalıdır");
            RuleFor(command => command.AuthorModel.Surname).NotEmpty().WithMessage("Author surname boş olamaz")
                .MinimumLength(5).WithMessage("Author surname minimum 5 karakterden oluşmalıdır");
            RuleFor(command=>command.AuthorModel.BirthDate).NotEmpty().WithMessage("Author birthdate boş olamaz")
                .LessThan(DateTime.Now.Date).WithMessage("Author birthdate ileri bir tarih olamaz");
        }
    }
}