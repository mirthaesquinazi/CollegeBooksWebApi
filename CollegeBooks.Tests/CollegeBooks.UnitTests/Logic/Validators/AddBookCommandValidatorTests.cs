using CollegeBooks.CommonTests;
using CollegeBooks.CommonTests.Builders.Commands;
using CollegeBooks.Logic.Commands;
using CollegeBooks.Logic.Validator;

namespace CollegeBooks.UnitTests.Logic.Validators
{
    public class AddBookCommandValidatorTests : ValidatorTestsBase
    {
        private readonly AddBookCommand _dto;
        private readonly AddBookCommandValidator _validator;

        public AddBookCommandValidatorTests()
        {
            _dto = AddBookCommandBuilder.BuildInstance();
            _validator = new AddBookCommandValidator();
        }

        [Fact]
        public async Task Validate_ValidEntity_ReturnsNoErrors()
        {
            //Arrange
            //All the properties have been set with valid values in the Builder.

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_dto);

            //Assert
            Validate_Ok(fluentValidationResult);
        }

        #region Validate Email

        [Fact]
        public async Task Validate_EmailWithValidFormat_ReturnsOk()
        {
            //Arrange
            _dto.PublishingHouseEmail = "email@gmail.com";

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_dto);

            //Assert
            Validate_Ok(fluentValidationResult);
        }

        [Fact]
        public async Task Validate_Email_WithInvalidFormat_ReturnsError()
        {
            //Arrange
            _dto.PublishingHouseEmail = TestsHelper.GenerateRandomString(10);

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_dto);

            //Assert
            Validate_Error(fluentValidationResult, nameof(_dto.PublishingHouseEmail));
        }

        #endregion

        // Here we can go on with the extra validations.
    }
}
