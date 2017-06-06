using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageView;
using StorageCore;

namespace StoragePresenter
{
    public class DeleteBookPresenter : IPresenter
    {
        public void MainAction()
        {
            int i = ConsoleIO.GetID(StorageManager.BookStorage.GetStorage().Count);
            
            if(i != -1)
            {
                StorageManager.BookStorage.GetStorage().RemoveAt(i);
               
            } 
            new MainMenuPresenter().MainAction();
        }
    }
}
