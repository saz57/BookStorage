using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;

namespace StorageView
{
    public static class ConsoleIO
    {
        public static int SubMenu()
        {
            return GetChoice("go to main menu", "Exit");
        }

        public static int GetChoice(params string[] options)
        {
            int choice;
            int choiseCount;
            string input = "";

            while (true)
            {
                choiseCount = 0;
                Console.WriteLine("");
                foreach (string option in options)
                {
                    choiseCount++;
                    Console.WriteLine("Enter " + choiseCount.ToString() + " to " + option);
                }

                input = Console.ReadLine();

                if (Int32.TryParse(input, out choice))
                {
                    if (choice > 0 && choice < options.Length + 1)
                    {
                        Console.Clear();
                        return choice;
                    }
                }

                Console.WriteLine("Invalid input. Please try again");
            }
        }

        public static int GetID(int storageLeight)
        {
            int Id;

            if (storageLeight == 0)
            {
                Console.WriteLine("Sorry, but storage is empty");
                return -1;
            }

            while (true)
            {
                Console.Write("Enter id : ");
                if (Int32.TryParse(Console.ReadLine(), out Id) && Id > 0 && Id <= storageLeight)
                {
                    return Id - 1;
                }

                Console.WriteLine("Invalid input");
                if (Id <= 0 || Id > storageLeight)
                {
                    Console.WriteLine("Please enter id between 1 and " + storageLeight.ToString());
                }
            }
        }

        public static Article CreateStringArticle()
        {
            Article article;
            article = new Article();
            Console.WriteLine("Enter article name:");
            article.Name = Console.ReadLine();
            Console.WriteLine("Enter article autor:");
            article.Autor = Console.ReadLine();
            Console.WriteLine("Enter article content:");
            article.Content = Console.ReadLine();
            return article;
        }

    }
}
