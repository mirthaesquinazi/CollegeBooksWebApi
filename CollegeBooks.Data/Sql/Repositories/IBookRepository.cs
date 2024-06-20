using DataModel;

namespace CollegeBooks.Data.Sql.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<int> InsertAsync(Book entity);
        Task<int> UpdateAsync(Book entity);
        Task<int> DeleteAsync(int id);
    }
}
