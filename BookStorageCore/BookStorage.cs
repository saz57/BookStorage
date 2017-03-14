using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorageCore
{
    public class BookStorage
    {
        private List<Book> _bookStorage;
        private IBookRepository _bookRepository;


        public BookStorage()
        {
            _bookStorage = new List<Book>();
            _bookRepository = new XMLBookRepository();
            LoadFromRepository();
        }

        public List<Book> GetStorage()
        {
            return _bookStorage;
        }

        public void AddBook(Book book)
        {
            _bookStorage.Add(book);
        }

        public Book GetBookById(int bookId)
        {
            return _bookStorage[bookId];
        }

        public void DeleteBookById(int bookId)
        {
            _bookStorage.RemoveAt(bookId);
        }

        public void SaveToRepository()
        {
            _bookRepository.Put(_bookStorage);
        }

        public void LoadFromRepository()
        {
            _bookStorage = _bookRepository.Get();
        }
    }
}
