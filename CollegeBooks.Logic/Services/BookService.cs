using CollegeBooks.Data.Sql.Repositories;
using CollegeBooks.Logic.Dtos;
using Mapster;

namespace CollegeBooks.Logic.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var databaseResult = await _repository.GetAllAsync();
            
            var dtosResult = new List<BookDto>();
           
            foreach (var item in databaseResult)
            {
                var dto = item.Adapt<BookDto>();
                dtosResult.Add(dto);
            }

            return dtosResult;
        }
    }
}
