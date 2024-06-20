namespace CollegeBooks.Logic.Dtos
{
    public class BookDto
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string PublishingHouseEmail { get; set; }
        public int NumberOfReadings { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }

    }
}
