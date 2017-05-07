using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageCore;
using StorageCore.Enums;

namespace StorageViev
{
    class MenuController
    {
        private static Storage<Book> _bookStorage;
        private static Storage<NewsPaper> _newsPaperStorage;
        private static Storage<Jornal> _jornalStorage;
        public MenuController()
        {
            
            _bookStorage = new Storage<Book>(RepositoryTypeEnum.SQLRepository);
            _newsPaperStorage = new Storage<NewsPaper>(RepositoryTypeEnum.TxtRepository);
            _jornalStorage = new Storage<Jornal>(RepositoryTypeEnum.XMLRepository);
            MainMenu();
        }

        private void MainMenu()
        {
            switch (UserIO.MainMenu()) // "open list of books", "open list of jornals", "open list of newspapers", "read book by id", "read jornal by id", "read newspaper by id", "add book", "add jornal", "add newspaper", "delete book by id", "delete jornal by id", "delete newspaper by id", "exit");
            {
                case 1:
                    BookStorageMenu();
                    break;

                case 2:
                    JornalStorageMenu();
                    break;

                case 3:
                    NewsPaperStorageMenu();
                    break;

                case 4:
                    Read(PaperType.Book);
                    break;

                case 5:
                    Read(PaperType.Jornal);
                    break;

                case 6:
                    Read(PaperType.NewsPaper);
                    break;

                case 7:
                    Add(PaperType.Book);
                    break;

                case 8:
                    Add(PaperType.Jornal);
                    break;

                case 9:
                    Add(PaperType.NewsPaper);
                    break;

                case 10:
                    Delete(PaperType.Book);
                    break;

                case 11:
                    Delete(PaperType.Jornal);
                    break;

                case 12:
                    Delete(PaperType.NewsPaper);
                    break;

                case 13:
                    Exit();
                    break;
            }
        }

        private void BookStorageMenu()
        {
            UserIO.ShowBookStorage(_bookStorage);

            switch (UserIO.BookStorageMenu()) //"read book by id", "delete book by id", "go to start menu", "exit"
            {
                case 1:
                    Read(PaperType.Book);
                    break;
                case 2:
                    Delete(PaperType.Book);
                    break;
                case 3:
                    MainMenu();
                    break;
                case 4:
                    Exit();
                    break;
            }
        }

        private void JornalStorageMenu()
        {
            UserIO.ShowJornalStorage(_jornalStorage);

            switch (UserIO.JornalStorageMenu()) //"read book by id", "delete book by id", "go to start menu", "exit"
            {
                case 1:
                    Read(PaperType.Jornal);
                    break;
                case 2:
                    Delete(PaperType.Jornal);
                    break;
                case 3:
                    MainMenu();
                    break;
                case 4:
                    Exit();
                    break;
            }
        }

        private void NewsPaperStorageMenu()
        {
            UserIO.ShowNewsPaperStorage(_newsPaperStorage);

            switch (UserIO.NewsPaperStorageMenu()) //"read newspaper by id", "delete newspaper by id", "go to start menu", "exit"
            {
                case 1:
                    Read(PaperType.NewsPaper);
                    break;
                case 2:
                    Delete(PaperType.NewsPaper);
                    break;
                case 3:
                    MainMenu();
                    break;
                case 4:
                    Exit();
                    break;
            }
        }

        private void Add(PaperType paperType)
        {
            switch (paperType)
            {
                case PaperType.Book:
                    _bookStorage.AddItem(UserIO.CreateStringBook());
                    break;

                case PaperType.Jornal:
                    _jornalStorage.AddItem(UserIO.CreateStringJornal());
                    break;

                case PaperType.NewsPaper:
                    _newsPaperStorage.AddItem(UserIO.CreateStringNewsPaper());
                    break;
            }

            MainMenu();
        }

        private void Delete(PaperType paperType)
        {
            int id;
            switch (paperType)
            {
                case PaperType.Book:
                    if (_bookStorage.GetStorage().Count < 1)
                    {
                        MainMenu();
                        return;
                    }
                    id = UserIO.GetID(_bookStorage.GetStorage().Count);
                    _bookStorage.DeleteById(id);
                    break;

                case PaperType.Jornal:
                    if (_jornalStorage.GetStorage().Count < 1)
                    {
                        MainMenu();
                        return;
                    }
                    id = UserIO.GetID(_jornalStorage.GetStorage().Count);
                    _jornalStorage.DeleteById(id);
                    break;

                case PaperType.NewsPaper:
                    if (_newsPaperStorage.GetStorage().Count < 1)
                    {
                        MainMenu();
                        return;
                    }
                    id = UserIO.GetID(_newsPaperStorage.GetStorage().Count);
                    _newsPaperStorage.DeleteById(id);
                    break;
            }

            MainMenu();
        }

        private void Read(PaperType paperType)
        {
            int id;
            switch (paperType)
            {
                case PaperType.Book:
                    id = UserIO.GetID(_bookStorage.GetStorage().Count);
                    UserIO.ShowBookToRead(_bookStorage.GetById(id) as Book);
                    break;

                case PaperType.Jornal:
                    id = UserIO.GetID(_jornalStorage.GetStorage().Count);
                    UserIO.ShowJornalToRead(_jornalStorage.GetById(id) as Jornal);
                    break;

                case PaperType.NewsPaper:
                    id = UserIO.GetID(_newsPaperStorage.GetStorage().Count);
                    UserIO.ShowNewsPaperToRead(_newsPaperStorage.GetById(id) as NewsPaper);
                    break;
            }


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
            _jornalStorage.SaveToRepository();
            _newsPaperStorage.SaveToRepository();
            Environment.Exit(0);
        }
    }
}
