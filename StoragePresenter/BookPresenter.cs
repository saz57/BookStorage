using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageView;
using StorageCore;

namespace StoragePresenter
{
    public class BookPresenter : IPresenter
    {
        private IView _view;

        public BookPresenter()
        {
            _view = new BookView();
            _view.AddListener(ChoiceHandler);
        }

        public void MainAction()
        {
            int i = ConsoleIO.GetID(StorageManager.BookStorage.GetStorage().Count);

            if (i == -1)
            {
                new MainMenuPresenter().MainAction();
                return;
            }

            _view.SetData(StorageManager.BookStorage.GetStorage()[i]);
            _view.Show();
        }

        public void ChoiceHandler(int choice)
        {
            switch(choice)
            {
                case 1:
                    new MainMenuPresenter().MainAction();
                    break;
                case 2:
                    new ExitPresenter().MainAction();
                    break;
            }
        }
    }
}
