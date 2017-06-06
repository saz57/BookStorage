using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;
namespace StorageView
{
    public class AddNewNewsPaperView : CreativeView
    {
        public override void Show()
        {
            NewsPaper newsPaper = new NewsPaper();
            Console.WriteLine("Enter newspaper name:");
            newsPaper.Name = Console.ReadLine();

            while (true)
            {
                newsPaper.Articles.Add(ConsoleIO.CreateStringArticle());
                int userChoice = ConsoleIO.GetChoice("add one more article", "end creating this newspaper");

                if (userChoice == 1)
                {
                    continue;
                }

                if (userChoice == 2)
                {
                    break;
                }
            }
            base.ActivateCreateEvent(newsPaper);
        }
    }
}
