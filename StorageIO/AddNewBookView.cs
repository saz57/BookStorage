using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;

namespace StorageView
{
    public class AddNewBookView : CreativeView
    {
        public override void Show()
        {
            Book book = new Book();
            Console.WriteLine("Enter book name:");
            book.Name = Console.ReadLine();
            Console.WriteLine("Enter autor:");
            book.Autor = Console.ReadLine();
            Console.WriteLine("Enter content");
            book.Content = Console.ReadLine();
            base.ActivateCreateEvent(book);
        }
    }
}
