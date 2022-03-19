using AutoMapper;
using FluentValidation;
using Webapi.DBOperations;
using Webapi.Entities;

namespace Webapi.Application.AuthorOperations.Queries.GetAuthorDetail
{

    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery> 
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0).WithMessage("Author Id 0 dan büyük olmalı");
        }
    }
}