using CollegeBooks.Logic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeBooks.CommonTests.Builders.Commands
{
    public class UpdateBookCommandBuilder
    {
        protected UpdateBookCommandBuilder() { }

        public static UpdateBookCommand BuildInstance()
        {

            var defaultInstance = new UpdateBookCommand
            {
                NumberOfReadings = 1,
            };

            return defaultInstance;
        }
    }
}
