using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private IBookServices _bookServices;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookServices bookServices, ILogger<BookController> logger)
        {
            _bookServices = bookServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get() 
        {
            _logger.LogInformation("Fetching all books");
            return Ok(_bookServices.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id) 
        {
            _logger.LogInformation("Fetching book with ID {id}", id);
            var book = _bookServices.FindById(id);

            if (book == null)
            {
                _logger.LogWarning("Fetching person with ID {id} não encontrado", id);
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult Post([FromBody] BookDTO book) 
        {
            _logger.LogInformation("Creating new Book: {title},{id}", book.Title, book.Id);
            var CreateBook = _bookServices.Create(book);
            if (CreateBook == null)
            {
                _logger.LogInformation("Failed to create book with title: {title} and id: {id}", book.Title, book.Id);
                return NotFound();
            }

            return Ok(CreateBook);
        }

        [HttpPut]
        public ActionResult Put([FromBody] BookDTO book)
        {
            _logger.LogInformation("Updating book with ID: {id}", book.Id);
            var UpdateBook = _bookServices.Update(book);

            if (UpdateBook == null)
            {
                _logger.LogError("Failed updating book with ID {id}", book.Id);
                return NotFound();
            }
            _logger.LogDebug("Person updated succesfully: {firstName}", UpdateBook.Title);
            return Ok(UpdateBook);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Fetching book with ID {id}", id);
            _bookServices.Delete(id);
            return NoContent();
        }
    }
}
