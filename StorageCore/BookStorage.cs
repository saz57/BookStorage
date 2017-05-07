//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StorageCore
//{
//    public class BookStorage
//    {
//        private List<TextPaper> _bookStorage;
//        private IRepository _bookRepository;


//        public BookStorage()
//        {
//            _bookStorage = new List<TextPaper>();
//            _bookRepository = new TxtRepository();
//            LoadFromRepository();
//        }

//        public List<TextPaper> GetStorage()
//        {
//            return _bookStorage;
//        }

//        public void AddBook(TextPaper textPaper)
//        {
//            _bookStorage.Add(textPaper);
//        }

//        public TextPaper GetBookById(int bookId)
//        {
//            return _bookStorage[bookId];
//        }

//        public void DeleteBookById(int bookId)
//        {
//            _bookStorage.RemoveAt(bookId);
//        }

//        public void SaveToRepository()
//        {
//            _bookRepository.Put<TextPaper>(_bookStorage);
//        }

//        public void LoadFromRepository()
//        {
//            _bookStorage = _bookRepository.Get<TextPaper>();
//        }
//    }
//}
