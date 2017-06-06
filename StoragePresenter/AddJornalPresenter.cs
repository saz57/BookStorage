using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageView;
using StorageModel;
using StorageCore;

namespace StoragePresenter
{
    public class AddJornalPresenter: IPresenter
    {
        private CreativeView _view;

        public AddJornalPresenter()
        {
            _view = new AddNewJornalView();
            _view.AddListenerToCreate(CreativeListener);
        }

        public void MainAction()
        {
            _view.Show();
            new MainMenuPresenter().MainAction();
        }

        public void CreativeListener(TextPaper textPaper)
        {
            if(textPaper.GetType() == typeof(Jornal))
            {
                StorageManager.JornalStorage.AddItem(textPaper as Jornal);
            }
        }
    }
}
