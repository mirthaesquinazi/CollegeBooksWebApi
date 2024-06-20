using CollegeBooks.Data.Sql.Repositories;
using CollegeBooks.Logic.Dtos;
using DataModel;
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

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var dbResponse = await _repository.GetByIdAsync(id);

            var result = dbResponse.Adapt<BookDto>();

            return result;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var dbResponse = await _repository.GetAllAsync();
            
            var result = new List<BookDto>();
           
            foreach (var item in dbResponse)
            {
                var dto = item.Adapt<BookDto>();
                result.Add(dto);
            }

            return result;
        }

        public async Task<IdDto> InsertAsync(AddBookCommand entity)
        {
            Book newBook = entity.Adapt<Book>();

            var result = await _repository.InsertAsync(newBook);

            var newId = new IdDto
            {
                Id = result
            };

            return newId;
        }

        public async Task<int> UpdateAsync(IdDto idToUpdate,UpdateBookCommand entity)
        {

            Book newBook = entity.Adapt<Book>();
            newBook.Id = idToUpdate.Id;
            newBook.UpdatedAt = DateTime.Now;
            //Todo : Here is pendient review how to get the old CreatedAt value or avoid override it with the default value.

            var dbResponse = await _repository.UpdateAsync(newBook);

            return dbResponse;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var dbResponse = await _repository.DeleteAsync(id);

            return dbResponse;
        }
    }
}
