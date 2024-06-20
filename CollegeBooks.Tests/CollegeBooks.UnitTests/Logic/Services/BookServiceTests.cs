using CollegeBooks.CommonTests.Builders.Dtos;
using CollegeBooks.Data.Sql.Repositories;
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
        private readonly Book _model;
        private readonly IEnumerable<Book> _modelList;

        private readonly Mock<IBookRepository> _repositoryMock;
        private readonly IBookService _service;
        protected readonly AutoMocker Mocker;

        public BookServiceTests()
        {
            Mocker = new AutoMocker();
            _model = BookBuilder.BuildInstance();
            _modelList = [_model];

            _repositoryMock = Mocker.GetMock<IBookRepository>();
            _service = new BookService(_repositoryMock.Object);
        }

        #region GetAllAsync

        [Fact]
        public async Task GetAllAsync_With_ValidRequest_ReturnOk()
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

    }
}
