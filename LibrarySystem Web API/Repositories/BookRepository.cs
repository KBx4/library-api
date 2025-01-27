using System.Collections.Generic;
using LibrarySystem.Books;

namespace LibrarySystem.Repositories
{
    public class BookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        public bool AddBook(Book book)
        {
            foreach (Book curBook in _books)
            {
                if (curBook.ISBN == book.ISBN)
                {
                    return false;
                }
            }

            _books.Add(book);
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBook(int index)
        {
            return _books[index];
        }

        public int GetBookByTitle(string title)
        {
            int i = 0;
            foreach(Book curBook in _books)
            {
                if(curBook.Title == title)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _books.Find(b => b.ISBN == isbn);
        }

        public bool DeleteBook(string isbn)
        {
            var book = _books.Find(b => b.ISBN == isbn);
            if (book != null)
            {
                _books.Remove(book);
                return true;
            }
            return false;
        }

        public bool UpdateBook(string isbn, Book updatedBook)
        {
            var book = _books.Find(b => b.ISBN == isbn);
            if (book == null)
            {
                return false;
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.IsAvailable = updatedBook.IsAvailable;

            return true;
        }
    }
}