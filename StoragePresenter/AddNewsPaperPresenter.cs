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
    public class AddNewsPaperPresenter : IPresenter
    {
        private CreativeView _view;

        public AddNewsPaperPresenter()
        {
            _view = new AddNewNewsPaperView();
            _view.AddListenerToCreate(CreativeListener);
        }

        public void MainAction()
        {
            _view.Show();
            new MainMenuPresenter().MainAction();
        }

        public void CreativeListener(TextPaper textPaper)
        {
            if(textPaper.GetType() == typeof(NewsPaper))
            {
                StorageManager.NewsPaperStorage.AddItem(textPaper as NewsPaper);
            }
        }
    }
}
