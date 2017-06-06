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
    class NewsPaperStorageMenuPresenter : IPresenter
    {
        
        private static List<NewsPaper> _storage;
        private IView _view;

        static NewsPaperStorageMenuPresenter()
        {
            _storage = StorageManager.NewsPaperStorage.GetStorage();
        }

        public NewsPaperStorageMenuPresenter()
        {
            _view = new NewsPaperStorageMenuView();
            _view.SetData(_storage);
            _view.AddListener(ChoiceHandler);
        }

        public void MainAction()
        {
            _view.Show();
        }

        public void ChoiceHandler(int choice)
        {
            switch (choice) 
            {
                case 1:
                    new NewsPaperPresenter().MainAction();
                    break;

                case 2:
                    new DeleteNewsPaperPresenter().MainAction();
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
