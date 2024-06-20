using CollegeBooks.Logic.Dtos;
using FluentValidation;

namespace CollegeBooks.Logic.Validator
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();

            RuleFor(x => x.PublishingHouseEmail).EmailAddress();

        }

    }
}
