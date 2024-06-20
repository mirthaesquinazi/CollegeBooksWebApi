using CollegeBooks.Logic.Dtos;

namespace CollegeBooks.Logic.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();

    }
}
