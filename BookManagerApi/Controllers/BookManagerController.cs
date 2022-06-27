using Microsoft.AspNetCore.Mvc;
using BookManagerApi.Models;
using BookManagerApi.Services;

namespace BookManagerApi.Controllers
{
    [Route("api/v1/book")]
    [ApiController]
    public class BookManagerController : ControllerBase
    {
        private readonly IBookManagementService _bookManagementService;

        public BookManagerController(IBookManagementService bookManagementService)
        {
            _bookManagementService = bookManagementService;
        }

        // GET: api/v1/book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _bookManagementService.GetAllBooks();
        }

        // GET: api/v1/book/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(long id)
        {
            if (_bookManagementService.BookExists(id))
            {
                var book = _bookManagementService.FindBookById(id);
                return book;
            }

           return NotFound();
        }

        // PUT: api/v1/book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateBookById(long id, Book book)
        {
            if (_bookManagementService.BookExists(id))
            {
                _bookManagementService.Update(id, book);
                return NoContent();
            }

           return NotFound();

            
        }

        // POST: api/v1/book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            if (!_bookManagementService.BookExists(book.Id))
            {
                _bookManagementService.Create(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }

            return BadRequest();
        }

        // DELETE: api/v1/book/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(long id)
        {
            if (_bookManagementService.BookExists(id))
            {
                _bookManagementService.DeleteBookById(id);
                return NoContent();
            }

            return NotFound();
        }

    }
}
