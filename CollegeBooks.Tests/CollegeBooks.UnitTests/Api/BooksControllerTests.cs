using CollegeBooks.Api.Controllers;
using CollegeBooks.CommonTests.Builders.Commands;
using CollegeBooks.CommonTests.Builders.Dtos;
using CollegeBooks.Logic.Commands;
using CollegeBooks.Logic.Dtos;
using CollegeBooks.Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace CollegeBooks.UnitTests.Api
{
    public class BooksControllerTests : ApiBaseControllerTests<BooksController>
    {
        private readonly IdDto _idDto;
        private readonly BookDto _dto;
        private readonly AddBookCommand _addBookCommand;
        private readonly UpdateBookCommand _updateBookCommand;

        private readonly IEnumerable<BookDto> _dtoList;
        private readonly Mock<IBookService> _userServiceMock;

        public BooksControllerTests()
        {
            _dto = BookDtoBuilder.BuildInstance();
            _idDto = new IdDto { Id = _dto.Id };

            _addBookCommand = AddBookCommandBuilder.BuildInstance();
            _updateBookCommand = UpdateBookCommandBuilder.BuildInstance();

            _dtoList = [_dto];
            _userServiceMock = Mocker.GetMock<IBookService>();
        }


        #region GetByIdAsync

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFound()
        {
            //Arrange
            _userServiceMock.Setup(x => x.GetByIdAsync(_dto.Id)); // Returns Null

            //Act
            var result = await Controller.GetByIdAsync(_dto.Id);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var objectResult = Assert.IsAssignableFrom<NotFoundResult>(result.Result);
            Assert.Equal(StatusCodes.Status404NotFound, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkAndDto()
        {
            //Arrange
            _userServiceMock.Setup(x => x.GetByIdAsync(_dto.Id)).ReturnsAsync(_dto);

            //Act
            var result = await Controller.GetByIdAsync(_dto.Id);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetByIdAsync_WithException_ReturnInternalServerError()
        {
            //Arrange
            _userServiceMock.Setup(x => x.GetByIdAsync(_dto.Id)).Throws(new Exception()); //For example db problems.

            //Act
            var result = await Controller.GetByIdAsync(_dto.Id);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var objectResult = Assert.IsAssignableFrom<StatusCodeResult>(result.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetByIdAsync_Call_GetByIdAsync_FromService()
        {
            //Arrange
            _userServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_dto);

            // Act
            await Controller.GetByIdAsync(_dto.Id);

            // Assert
            _userServiceMock.Verify(x => x.GetByIdAsync(_dto.Id), Times.Once);
        }


        #endregion

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

        #region InsertAsync

        [Fact]
        public async Task InsertAsync_ReturnsCreatedAndIdDto()
        {
            //Arrange
            _userServiceMock.Setup(x => x.InsertAsync(_addBookCommand)).ReturnsAsync(_idDto);

            //Act
            var result = await Controller.InsertAsync(_addBookCommand);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status201Created, objectResult.StatusCode);
        }

        [Fact]
        public async Task InsertAsync_WithException_ReturnInternalServerError()
        {
            //Arrange
            _userServiceMock.Setup(x => x.InsertAsync(_addBookCommand)).Throws(new Exception());

            //Act
            var result = await Controller.InsertAsync(_addBookCommand);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var objectResult = Assert.IsAssignableFrom<StatusCodeResult>(result.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }

        [Fact]
        public async Task InsertAsync_Call_InsertAsync_FromService()
        {
            //Arrange
            _userServiceMock.Setup(x => x.InsertAsync(_addBookCommand)).ReturnsAsync(_idDto);

            // Act
            await Controller.InsertAsync(_addBookCommand);

            // Assert
            _userServiceMock.Verify(x => x.InsertAsync(_addBookCommand), Times.Once);
        }


        #endregion
     
        #region UpdateAsync

        [Fact]
        public async Task UpdateAsync_ReturnsOk()
        {
            //Arrange
            _userServiceMock.Setup(x => x.UpdateAsync(It.IsAny<IdDto>(), _updateBookCommand)).ReturnsAsync(1);

            //Act
            var result = await Controller.UpdateAsync(_dto.Id, _updateBookCommand);

            //Assert
            Assert.NotNull(result);

            var objectResult = Assert.IsAssignableFrom<OkResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsNoContent()
        {
            //Arrange

            _userServiceMock.Setup(x => x.UpdateAsync(_idDto, _updateBookCommand)).ReturnsAsync(0);

            //Act
            var result = await Controller.UpdateAsync(_dto.Id, _updateBookCommand);

            //Assert
            Assert.NotNull(result);

            var objectResult = Assert.IsAssignableFrom<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);
        }
        [Fact]
        public async Task UpdateAsync_WithException_ReturnInternalServerError()
        {
            //Arrange
            _userServiceMock.Setup(x => x.UpdateAsync(It.IsAny<IdDto>(), It.IsAny<UpdateBookCommand>())).Throws(new Exception());

            //Act
            var result = await Controller.UpdateAsync(_dto.Id, _updateBookCommand);

            //Assert
            Assert.NotNull(result);

            var objectResult = Assert.IsAssignableFrom<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }

        [Fact]
        public async Task UpdateAsync_Call_UpdateAsync_FromService()
        {
            //Arrange
            _userServiceMock.Setup(x => x.UpdateAsync(It.IsAny<IdDto>(), It.IsAny<UpdateBookCommand>())).ReturnsAsync(0);

            // Act
           await Controller.UpdateAsync(_dto.Id, _updateBookCommand);

            // Assert
            _userServiceMock.Verify(x => x.UpdateAsync(It.IsAny<IdDto>(), It.IsAny<UpdateBookCommand>()), Times.Once);
        }


        #endregion

        #region DeleteAsync

        [Fact]
        public async Task DeleteAsync_ReturnsOk()
        {
            //Arrange
            _userServiceMock.Setup(x => x.DeleteAsync(It.IsAny<IdDto>())).ReturnsAsync(1);

            //Act
            var result = await Controller.DeleteAsync(_dto.Id);

            //Assert
            Assert.NotNull(result);

            var objectResult = Assert.IsAssignableFrom<OkResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsNoContent()
        {
            //Arrange

            _userServiceMock.Setup(x => x.DeleteAsync(It.IsAny<IdDto>())).ReturnsAsync(0);

            //Act
            var result = await Controller.DeleteAsync(_dto.Id);

            //Assert
            Assert.NotNull(result);

            var objectResult = Assert.IsAssignableFrom<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);
        }
        [Fact]
        public async Task DeleteAsync_WithException_ReturnInternalServerError()
        {
            //Arrange
            _userServiceMock.Setup(x => x.DeleteAsync(It.IsAny<IdDto>())).Throws(new Exception()); //For example db problems.

            //Act
            var result = await Controller.DeleteAsync(_dto.Id);

            //Assert
            Assert.NotNull(result);

            var objectResult = Assert.IsAssignableFrom<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }

        [Fact]
        public async Task DeleteAsync_Call_DeleteAsync_FromService()
        {
            //Arrange
            _userServiceMock.Setup(x => x.DeleteAsync(It.IsAny<IdDto>())).ReturnsAsync(0);

            // Act
            await Controller.DeleteAsync(_dto.Id);

            // Assert
            _userServiceMock.Verify(x => x.DeleteAsync(It.IsAny<IdDto>()), Times.Once);
        }


        #endregion
    }
}
