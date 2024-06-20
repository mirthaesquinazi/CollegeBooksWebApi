using DataModel;

namespace CollegeBooks.Data.Sql.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();

    }
}
