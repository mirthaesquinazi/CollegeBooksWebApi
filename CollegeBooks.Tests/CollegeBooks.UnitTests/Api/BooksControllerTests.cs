using CollegeBooks.Api.Controllers;
using CollegeBooks.CommonTests.Builders.Dtos;
using CollegeBooks.Logic.Dtos;
using CollegeBooks.Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace CollegeBooks.UnitTests.Api
{
    public class BooksControllerTests : ApiBaseControllerTests<BooksController>
    {
        private readonly BookDto _dto;
        private readonly IEnumerable<BookDto> _dtoList;
        private readonly Mock<IBookService> _userServiceMock;

        public BooksControllerTests()
        {
            _dto = BookDtoBuilder.BuildInstance();
            _dtoList = [_dto];
            _userServiceMock = Mocker.GetMock<IBookService>();
        }

        #region GetAllAsync

        [Fact]
        public async Task GetAllAsync_ReturnsNoContent()
        {
            //Arrange
            _userServiceMock.Setup(x => x.GetAllAsync()); // Returns Null

            //Act
            var result = await Controller.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var objectResult = Assert.IsAssignableFrom<NoContentResult>(result.Result);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);
        }
       
        [Fact]
        public async Task GetAllAsync_ReturnsOkAndDto()
        {
            //Arrange

            _userServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(_dtoList);

            //Act
            var result = await Controller.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetAllAsync_WithException_ReturnInternalServerError()
        {
            //Arrange
            _userServiceMock.Setup(x => x.GetAllAsync()).Throws(new Exception()); //For example db problems.

            //Act
            var result = await Controller.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var objectResult = Assert.IsAssignableFrom<StatusCodeResult>(result.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetAllAsync_Call_GetAllAsync_FromService()
        {
            //Arrange
            _userServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(_dtoList);

            // Act
            await Controller.GetAllAsync();

            // Assert
            _userServiceMock.Verify(x => x.GetAllAsync(), Times.Once);
        }


        #endregion


    }
}
