
using CollegeBooks.Logic.Dtos;

namespace CollegeBooks.CommonTests.Builders.Dtos
{

    public class BookDtoBuilder
    {
        protected BookDtoBuilder() { }

        public static BookDto BuildInstance()
        {

            var defaultInstance = new BookDto
            {
                Id = 21,
                Title="Test Title",
                CreatedAt = DateTime.Now,  
                UpdatedAt = DateTime.Now
            };

            return defaultInstance;
        }
    }
}
