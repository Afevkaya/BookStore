using FluentValidation;

namespace Webapi.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(query=> query.BookId).GreaterThan(0).WithMessage("Book Id 0 dan büyük olmalıdır.");
        }
    }
}