using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageCore;
using StorageModel;

namespace StorageView
{
    public class JornalStorageMenuView : BaseView
    {
        private List<Jornal> _storage;

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

        private void ShowStorage(List<Jornal> storage)
        {
            int count = 0;
            foreach (Jornal item in storage)
            {
                if (item != null)
                {
                    count++;
                    Console.WriteLine(count.ToString() + " " + item.Name + " with photo of " + item.LabelName + "on first page");
                }
            }
        }

        private void StorageMenu()
        {
            base.ActivateEvent(ConsoleIO.GetChoice("read jornal by id", "delete jornal by id", "go to main menu", "exit"));
        }

    }
}
