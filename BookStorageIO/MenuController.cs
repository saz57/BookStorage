using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorageCore;
namespace BookStorageViev
{
    class MenuController
    {
        private static BookStorage _bookStorage;

        public MenuController()
        {
            _bookStorage = new BookStorage();
            MainMenu();
        }

        private void MainMenu()
        {
            switch (UserIO.MainMenu()) // "open list of books", "read book by id", "add book", "delete book by id", "exit"
            {
                case 1:
                    StorageMenu();
                    break;

                case 2:
                    ReadBook();
                    break;

                case 3:
                    AddBook();
                    break;

                case 4:
                    DeleteBook();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;
            } 
        }

        private void StorageMenu()
        {
            UserIO.ShowBookStorage(_bookStorage);

            switch (UserIO.StorageMenu()) //"read book by id", "delete book by id", "go to start menu", "exit"
            {
                case 1: 
                    ReadBook(); 
                    break;
                case 2:
                    DeleteBook();
                    break;
                case 3:
                    MainMenu();
                    break;
                case 4:
                    Exit();
                    break;
            }
        }

        private void AddBook()
        {
            _bookStorage.AddBook(UserIO.CreateStringBook());
            MainMenu();
        }

        private void DeleteBook()
        {
            if (_bookStorage.GetStorage().Count < 1)
            {
                MainMenu();
                return;
            }
           int bookId = UserIO.GetID(_bookStorage.GetStorage().Count);
           _bookStorage.DeleteBookById(bookId);
           MainMenu();
        }

        private void ReadBook()
        {
            UserIO.ShowBookToRead(_bookStorage.GetBookById(UserIO.GetID(_bookStorage.GetStorage().Count)));
            int userChoise = UserIO.SubMenu();

            if (userChoise == 1)
            {
                MainMenu();
            }

            if (userChoise == 2)
            {
                Exit();
            }
        }

        private void Exit()
        {
            _bookStorage.SaveToRepository();
            Environment.Exit(0);
        }
    }
}
