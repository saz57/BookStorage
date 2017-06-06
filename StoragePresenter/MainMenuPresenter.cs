using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageView;

namespace StoragePresenter
{
    public class MainMenuPresenter : IPresenter
    {
        private IView _view;

        public MainMenuPresenter()
        {
            _view = new MainMenuView();
            _view.AddListener(ChoiceHandler);
        }

        public void MainAction()
        {
            _view.Show();
        }

        public void ChoiceHandler(int choice)
        {
            switch (choice) // "open list of books", "open list of jornals", "open list of newspapers", "read book by id", "read jornal by id", "read newspaper by id", "add book", "add jornal", "add newspaper", "delete book by id", "delete jornal by id", "delete newspaper by id", "exit");
            {
                case 1:
                    new BookStorageMenuPresenter().MainAction();
                    break;

                case 2:
                    new JornalStorageMenuPresenter().MainAction();
                    break;

                case 3:
                    new NewsPaperStorageMenuPresenter().MainAction();
                    break;

                case 4:
                    new BookPresenter().MainAction();
                    break;

                case 5:
                    new JornalPresenter().MainAction();
                    break;

                case 6:
                    new NewsPaperPresenter().MainAction();
                    break;

                case 7:
                    new AddBookPresenter().MainAction();
                    break;

                case 8:
                    new AddJornalPresenter().MainAction();
                    break;

                case 9:
                    new AddNewsPaperPresenter().MainAction();
                    break;

                case 10:
                    new DeleteBookPresenter().MainAction();
                    break;

                case 11:
                    new DeleteJornalPresenter().MainAction();
                    break;

                case 12:
                    new DeleteNewsPaperPresenter().MainAction();
                    break;

                case 13:
                    new ExitPresenter().MainAction();
                    break;
            }
        }
    }
}
