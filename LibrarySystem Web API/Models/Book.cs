using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Books
{
    public class Book
    {
        #region Private Fields
        private string _title;
        private string _author;
        private string _isbn;
        private bool _isAvailable;
        #endregion

        #region Public Properties
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string ISBN
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }
        #endregion

        #region c`tor
        public Book() { }
        public Book(string title, string author, string isbn, bool avail)
        {
            _title = title;
            _author = author;
            _isbn = isbn;
            _isAvailable = avail;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"The current book is: {Title} written by {Author}. " +
                $"ISBN is {ISBN}. Available: {IsAvailable}";
        }
        #endregion
    }

    public class EBook: Book
    {
        #region Private Fields
        private int _fileSize;
        #endregion

        #region Public Properties
        public int FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; }
        }
        #endregion

        #region c`tor
        public EBook(string title, string author, string isbn, bool avail, int size)
            : base(title, author, isbn, avail)
        {
            FileSize = size;
        }
        #endregion

        #region Methods
        public override string ToString()
        {

            return $"The current book is: {Title} written by {Author}. " +
                $"ISBN is {ISBN}. Available: {IsAvailable}. File Size: {FileSize}";
        }
        #endregion

    }

}