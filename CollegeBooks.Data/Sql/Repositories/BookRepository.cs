using DataModel;
using LinqToDB;

namespace CollegeBooks.Data.Sql.Repositories
{
    public class BookRepository : IBookRepository
    {
        
        private readonly CollegeBooksDb _context;

        public BookRepository(CollegeBooksDb context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            IEnumerable<Book>? result = from book in _context.GetTable<Book>() select book;
            
            return result;
        }
    }
}
