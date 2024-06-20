using CollegeBooks.Logic.Commands;
using CollegeBooks.Logic.Dtos;
using CollegeBooks.Logic.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<ActionResult<BookDto>> GetByIdAsync([Required]int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, "GetByIdAsync Error: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IdDto>> InsertAsync(AddBookCommand command)
        {
            try
            {
                var newIdDto = await _service.InsertAsync(command);

                return StatusCode(StatusCodes.Status201Created, newIdDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, "InsertAsync Error: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateAsync([FromRoute] int id, UpdateBookCommand command)
        {
            try
            {
                var newIdDto = new IdDto
                {
                    Id = id
                };

                var affectedRows = await _service.UpdateAsync(newIdDto, command);
                if (affectedRows == 1)
                {
                    return Ok();
                }
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, "UpdateAsync Error: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var newIdDto = new IdDto
                {
                    Id = id
                };

                var affectedRows = await _service.DeleteAsync(newIdDto);

                if (affectedRows == 1)
                {
                    return Ok();
                }
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, "DeleteAsync Error: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
