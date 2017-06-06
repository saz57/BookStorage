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
    public class AddBookPresenter : IPresenter
    {
        private CreativeView _view;

        public AddBookPresenter()
        {
            _view = new AddNewBookView();
            _view.AddListenerToCreate(CreativeListener);
        }

        public void MainAction()
        {
            _view.Show();
            new MainMenuPresenter().MainAction();
        }

        public void CreativeListener(TextPaper textPaper)
        {
            if(textPaper.GetType() == typeof(Book))
            {
                StorageManager.BookStorage.AddItem(textPaper as Book);
            }
        }

    }
}
