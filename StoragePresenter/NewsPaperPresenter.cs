using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageView;
using StorageCore;

namespace StoragePresenter
{
    public class NewsPaperPresenter : IPresenter
    {
        
        private IView _view;

        public NewsPaperPresenter()
        {
            _view = new NewsPaperView();
            _view.AddListener(ChoiceHandler);
        }

        public void MainAction()
        {
            int i = ConsoleIO.GetID(StorageManager.NewsPaperStorage.GetStorage().Count);

            if (i == -1)
            {
                new MainMenuPresenter().MainAction();
                return;
            }

            _view.SetData(StorageManager.NewsPaperStorage.GetStorage()[i]);
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
