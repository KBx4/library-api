using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Books;
using LibrarySystem.Repositories;

namespace LibrarySystem_Web_API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {

        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allBooks = _bookRepository.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("{title}")]
        public IActionResult GetBookByTitle(string title)
        {
            int found = _bookRepository.GetBookByTitle(title);
            if (found != -1)
            {
                return Ok($"Book has been found successfully: {_bookRepository.GetBook(found)}");
            }
            
            return NotFound($"No books were found with the given title: `{title}`");

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            bool valid = _bookRepository.AddBook(book);
            if (valid)
            {
                return Ok($"Book `{book.Title}` added succesfully!");
            }
            else
            {
                return BadRequest($"ISBN Conflict: A book with the same isbn: {book.ISBN} already exists");
            }
        }

        [HttpPut("{isbn}")]
        public IActionResult UpdateBook(string isbn, [FromBody] Book updatedBook)
        {
            if (updatedBook == null || string.IsNullOrEmpty(updatedBook.Title) || string.IsNullOrEmpty(updatedBook.ISBN))
            {
                return BadRequest("Book title and ISBN are required.");
            }

            if (isbn != updatedBook.ISBN)
            {
                return BadRequest("ISBN in the URL does not match the ISBN in the request body.");
            }

            bool isUpdated = _bookRepository.UpdateBook(isbn, updatedBook);
            if (!isUpdated)
            {
                return NotFound($"Book with ISBN '{isbn}' not found.");
            }

            return Ok($"Book with ISBN '{isbn}' updated successfully.");
        }

        [HttpDelete("{isbn}")]
        public IActionResult DeleteBook(string isbn)
        {
            bool isDeleted = _bookRepository.DeleteBook(isbn);
            if (!isDeleted)
            {
                return NotFound($"ISBN Not Found: A book with `{isbn}` does not exist");
            }

            return Ok($"Book with ISBN '{isbn}' deleted successfully.");
        }
    }
}
