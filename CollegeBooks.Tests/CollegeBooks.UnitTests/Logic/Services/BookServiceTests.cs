using CollegeBooks.CommonTests.Builders.Commands;
using CollegeBooks.CommonTests.Builders.Dtos;
using CollegeBooks.Data.Sql.Repositories;
using CollegeBooks.Logic.Commands;
using CollegeBooks.Logic.Dtos;
using CollegeBooks.Logic.Services;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeBooks.UnitTests.Logic.Services
{
    public class BookServiceTests
    {
        private readonly IdDto _idDto;
        private readonly BookDto _dto;

        private readonly Book _model;
        private readonly IEnumerable<Book> _modelList;

        private readonly AddBookCommand _addBookCommand;
        private readonly UpdateBookCommand _updateBookCommand;

        private readonly Mock<IBookRepository> _repositoryMock;
        private readonly IBookService _service;
        protected readonly AutoMocker Mocker;

        public BookServiceTests()
        {
            Mocker = new AutoMocker();
            _model = BookBuilder.BuildInstance();
            _modelList = [_model];

            _dto = BookDtoBuilder.BuildInstance();
            _idDto = new IdDto { Id = _dto.Id };

            _addBookCommand = AddBookCommandBuilder.BuildInstance();
            _updateBookCommand = UpdateBookCommandBuilder.BuildInstance();

            _repositoryMock = Mocker.GetMock<IBookRepository>();
            _service = new BookService(_repositoryMock.Object);
        }

        #region GetByIdAsync

        [Fact]
        public async Task GetByIdAsync_With_ValidValues_ReturnCorrectTypeResult()
        {
            //Arrange
            _repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_model);

            //Act
            var result = await _service.GetByIdAsync(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<BookDto>(result);
        }

        #endregion

        #region GetAllAsync

        [Fact]
        public async Task GetAllAsync_With_ValidValues_ReturnCorrectTypeResult()
        {
            //Arrange
            _repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(_modelList);

            //Act
            var result = await _service.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.IsAssignableFrom<IEnumerable<BookDto>>(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnEmptyListCorrectly()
        {
            //Arrange
            _repositoryMock.Setup(x => x.GetAllAsync());

            //Act
            var result = await _service.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsAssignableFrom<IEnumerable<BookDto>>(result);
        }

        #endregion

        #region InsertAsync

        [Fact]
        public async Task InsertAsync_With_ValidValues_ReturnCorrectTypeResult()
        {
            //Arrange
            _repositoryMock.Setup(x => x.InsertAsync(It.IsAny<Book>())).ReturnsAsync(1);

            //Act
            var result = await _service.InsertAsync(_addBookCommand);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IdDto>(result);
        }

        #endregion

        #region UpdateAsync

        [Fact]
        public async Task UpdateAsync_With_ValidValues_ReturnCorrectTypeResult()
        {
            //Arrange
            _repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Book>())).ReturnsAsync(1);

            //Act
            var result = await _service.UpdateAsync(_idDto, _updateBookCommand);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<int>(result);
        }

        #endregion

        #region UpdateAsync

        [Fact]
        public async Task DeleteAsync_With_ValidValues_ReturnCorrectTypeResult()
        {
            //Arrange
            _repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync(1);

            //Act
            var result = await _service.DeleteAsync(_idDto);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<int>(result);
        }

        #endregion
    }
}
