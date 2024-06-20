using CollegeBooks.Logic.Commands;
using CollegeBooks.Logic.Dtos;

namespace CollegeBooks.Logic.Services
{
    public interface IBookService
    {
        Task<BookDto?> GetByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<IdDto> InsertAsync(AddBookCommand entity);
        Task<int> UpdateAsync(IdDto idToUpdate, UpdateBookCommand entity);
        Task<int> DeleteAsync(IdDto idToDelete);
    }
}
