using CollegeBooks.Logic.Validator;

namespace CollegeBooks.Logic.Commands
{
    public class UpdateBookCommand : IValidable
    {
        public int NumberOfReadings { get; set; }

        public async Task<string> Validate()
        {
            var errors = string.Empty;

            var validator = new UpdateBookCommandValidator();

            FluentValidation.Results.ValidationResult fluentResult = await validator.ValidateAsync(this);

            if (!fluentResult.IsValid)
            {
                errors += string.Join("", fluentResult.Errors);
            }

            return await Task.FromResult(errors);
        }
    }
}
