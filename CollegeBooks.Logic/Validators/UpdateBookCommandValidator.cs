using CollegeBooks.Logic.Commands;
using FluentValidation;

namespace CollegeBooks.Logic.Validator
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.NumberOfReadings).GreaterThan(0);
        }

    }
}
