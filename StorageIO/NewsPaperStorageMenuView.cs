using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageCore;
using StorageModel;

namespace StorageView
{
    public class NewsPaperStorageMenuView : BaseView
    {
        private List<NewsPaper> _storage;

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

        private void ShowStorage(List<NewsPaper> storage)
        {
            int count = 0;
            foreach (NewsPaper item in storage)
            {
                if (item != null)
                {
                    count++;
                    Console.WriteLine(count.ToString() + " " + item.Name);
                }
            }
        }

        private void StorageMenu()
        {
            base.ActivateEvent(ConsoleIO.GetChoice("read newspaper by id", "delete newspaper by id", "go to main menu", "exit"));
        }
    }
}
