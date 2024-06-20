using DataModel;

namespace CollegeBooks.CommonTests.Builders.Dtos
{

    public class BookBuilder
    {
        protected BookBuilder() { }

        public static Book BuildInstance()
        {

            var defaultInstance = new Book
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
