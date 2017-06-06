using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageView;
using StorageCore;
using StorageModel;

namespace StoragePresenter
{
    class JornalStorageMenuPresenter : IPresenter
    {
        private static List<Jornal> _storage;
        private IView _view;

        static JornalStorageMenuPresenter()
        {
            _storage = StorageManager.JornalStorage.GetStorage();
        }

        public JornalStorageMenuPresenter()
        {
            _view = new JornalStorageMenuView();
            _view.SetData(_storage);
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
                    new JornalPresenter().MainAction();
                    break;

                case 2:
                    new DeleteJornalPresenter().MainAction();
                    break;

                case 3:
                    new MainMenuPresenter().MainAction();
                    break;

                case 4:
                    new ExitPresenter().MainAction();
                    break;
            }
       }
    }
}
