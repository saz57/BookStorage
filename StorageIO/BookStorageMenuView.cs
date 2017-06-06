using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageCore;
using StorageModel;

namespace StorageView
{
    public class BookStorageMenuView: BaseView
    {
        private List<Book> _storage;
        
        public override void Show()
        {
            if (_storage != null)
            {
                ShowStorage(_storage);
            }

            StorageMenu();
        }

        public override void SetData(dynamic data)
        {
            _storage = data;
        }

        private void ShowStorage(List<Book> storage)
        {
            int count = 0;
            foreach (Book item in storage)
            {
                if (item != null)
                {
                    count++;
                    Console.WriteLine(count.ToString() + " " + item.Name + " by " + item.Autor);
                }
            }
        }

        private void StorageMenu()
        {
            base.ActivateEvent(ConsoleIO.GetChoice("read book by id", "delete book by id", "go to main menu", "exit"));
        }
    }
}
