using CollegeBooks.Logic.Validator;
using System.Net;
using System.Xml.Linq;

namespace CollegeBooks.Logic.Commands
{
    public class AddBookCommand : IValidable
    {
        public string Title { get; set; }

        public string PublishingHouseEmail { get; set; }

        public async Task<string> Validate()
        {
            var errors = string.Empty;

            var validator = new AddBookCommandValidator();

            FluentValidation.Results.ValidationResult fluentResult = await validator.ValidateAsync(this);

            if (!fluentResult.IsValid)
            {
                errors += string.Join("", fluentResult.Errors);
            }

            return await Task.FromResult(errors);
        }
    }
}
