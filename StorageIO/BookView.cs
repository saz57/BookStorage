using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;

namespace StorageView
{
    public class BookView : BaseView
    {
        private Book _book;

        public override void Show()
        {
            if (_book != null)
            {
                Console.WriteLine(_book.Name + " by " + _book.Autor + "\n");
                Console.WriteLine(_book.Content.ToString() + "\n");
            }
            base.ActivateEvent(ConsoleIO.SubMenu());
        }

        public override void SetData(dynamic data)
        {
            _book = data;
        }
    }
}
