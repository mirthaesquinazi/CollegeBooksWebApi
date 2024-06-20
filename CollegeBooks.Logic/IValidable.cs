namespace CollegeBooks.Logic
{
    public interface IValidable
    {
        Task<string> Validate();
    }
}
