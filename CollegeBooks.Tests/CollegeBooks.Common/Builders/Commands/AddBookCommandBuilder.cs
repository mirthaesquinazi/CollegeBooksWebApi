using CollegeBooks.Logic.Commands;

namespace CollegeBooks.CommonTests.Builders.Commands
{
    public class AddBookCommandBuilder
    {
        protected AddBookCommandBuilder() { }

        public static AddBookCommand BuildInstance()
        {

            var defaultInstance = new AddBookCommand
            {
                Title = "Test Title",
                PublishingHouseEmail = "testemail@server.com",
            };

            return defaultInstance;
        }
    }
}
