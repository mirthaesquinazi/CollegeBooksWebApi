using CollegeBooks.CommonTests.Builders.Dtos;
using CollegeBooks.Data.Sql.Repositories;
using CollegeBooks.Logic.Commands;
using CollegeBooks.Logic.Dtos;
using CollegeBooks.Logic.Services;
using DataModel;
using Moq;
using Moq.AutoMock;
using FluentAssertions;


namespace CollegeBooks.UnitTests.Data.Repositories
{
    public class BookRepositoryTests
    {
        private readonly Book entity;
        private readonly IEnumerable<Book> entities;

        private readonly Mock<IBookRepository> mockRepository;
        private readonly IBookService sut;
        protected readonly AutoMocker Mocker;

        public BookRepositoryTests()
        {
            // Here we can use builders, or fixture or Autofix test types too.
            entity = BookBuilder.BuildInstance();
            entities = [entity];

            Mocker = new AutoMocker();
            mockRepository = Mocker.GetMock<IBookRepository>();
            sut = new BookService(mockRepository.Object);

        }
        [Fact]
        public async Task GetAllAsync_ReturnsAllEntities()
        {
            // Arrange 
            mockRepository
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(entities);

            // Act
            var result = await sut.GetAllAsync();

            // Assert
            result.Should().BeEquivalentTo(entities);
        }

        [Fact]
        public async Task GetByIdAsync_WithExistingEntity_ReturnsEntity()
        {
            // Arrange
            mockRepository
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(entity);

            // Act
            var result = await sut.GetByIdAsync(1);

            // Assert
            result.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task GetByIdAsync_WithNonExistingEntity_ReturnsNull()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByIdAsync(1));

            // Act
            var result = await sut.GetByIdAsync(1);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task InsertAsync_InsertsEntity()
        {
            // Arrange
  
            // Act
            await sut.InsertAsync(new AddBookCommand());

            // Assert
            mockRepository.Verify(
                x => x.InsertAsync(It.IsAny<Book>()),
                Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_UpdatesEntity()
        {
            // Arrange

            // Act
            await sut.UpdateAsync(new IdDto(),new UpdateBookCommand());

            // Assert
            mockRepository.Verify(
                x => x.UpdateAsync(It.IsAny<Book>()),
                Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_DeletesEntity()
        {
            // Arrange

            // Act
            await sut.DeleteAsync(new IdDto());

            // Assert
            mockRepository.Verify(
                x => x.DeleteAsync(It.IsAny<int>()),
                Times.Once());
        }
    }
}
