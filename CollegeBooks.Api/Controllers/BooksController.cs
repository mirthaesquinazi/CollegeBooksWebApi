using CollegeBooks.Logic.Dtos;
using CollegeBooks.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollegeBooks.Api.Controllers
{
    public class BooksController : ApiBaseController
    {
        private readonly IBookService _service;

        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger, IBookService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllAsync()
        {
            try
            {
                var entities = await _service.GetAllAsync();

                if (entities == null || !entities.Any())
                {
                    return NoContent();
                }

                return Ok(entities);

            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, "GetAllAsync Error: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

    }
}
