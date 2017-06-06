using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;

namespace StorageView
{
    public class AddNewJornalView : CreativeView
    {
        public override void Show()
        {
            Jornal jornal = new Jornal();
            Console.WriteLine("Enter jornal name:");
            jornal.Name = Console.ReadLine();
            Console.WriteLine("Enter name of human on label:");
            jornal.LabelName = Console.ReadLine();

            while (true)
            {
                jornal.Articles.Add(ConsoleIO.CreateStringArticle());
                int userChoice = ConsoleIO.GetChoice("add one more article", "end creating this jornal");

                if (userChoice == 1)
                {
                    continue;
                }

                if (userChoice == 2)
                {
                    break;
                }
            }
            base.ActivateCreateEvent(jornal);
        }
    }
}
