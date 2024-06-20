
using CollegeBooks.Logic.Validator;

namespace CollegeBooks.Logic.Dtos
{
    public class IdDto : IValidable
    {
        public int Id { get; set; }

        public async Task<string> Validate()
        {
            var errors = string.Empty;

            var validator = new IdDtoValidator();

            FluentValidation.Results.ValidationResult fluentResult = await validator.ValidateAsync(this);

            if (!fluentResult.IsValid)
            {
                errors += string.Join("", fluentResult.Errors);
            }

            return await Task.FromResult(errors);
        }
    }
}
