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

        public async Task<Book?> GetByIdAsync(int id)
        {
            var query = _context.GetTable<Book>().Where(x =>x.Id == id);
            
            var result = await query.FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<Book?>> GetAllAsync()
        {
            var query = _context.GetTable<Book>();

            IEnumerable<Book>? result = await query.ToListAsync();

            return result;
        }

        public async Task<int> InsertAsync(Book entity)
        {
            var query = await _context.InsertWithIdentityAsync(entity);

            var newId = Convert.ToInt32(query);

            return newId;
        }

        public async Task<int> UpdateAsync(Book entity)
        {
            var affectedRows = await _context.UpdateAsync(entity);
            return affectedRows;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var affectedRows = await _context.DeleteAsync(id);

            return affectedRows;
        }
    }
}
