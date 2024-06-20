using CollegeBooks.Logic.Dtos;
using FluentValidation;

namespace CollegeBooks.Logic.Validator
{
    public class IdDtoValidator : AbstractValidator<IdDto>
    {
        public IdDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }

    }
}
