using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageCore;

namespace StorageViev
{
    public static class UserIO
    {
        public static void ShowBookStorage<T>(Storage<T> storage) where T : Book
        {
            int count = 0;
            List<T> localStorage = storage.GetStorage();
            foreach (T item in localStorage)
            {
                if (item != null)
                {
                    count++;
                    Console.WriteLine(count.ToString() + " " + item.Name + " by " + item.Autor);
                }
            }
        }

        public static void ShowJornalStorage<T>(Storage<T> storage) where T : Jornal
        {
            int count = 0;
            List<T> localStorage = storage.GetStorage();
            foreach (T item in localStorage)
            {
                if (item != null)
                {
                    count++;
                    Console.WriteLine(count.ToString() + " " + item.Name);
                }
            }
        }

        public static void ShowNewsPaperStorage<T>(Storage<T> storage) where T : NewsPaper
        {
            int count = 0;
            List<T> localStorage = storage.GetStorage();
            foreach (T item in localStorage)
            {
                if (item != null)
                {
                    count++;
                    Console.WriteLine(count.ToString() + " " + item.Name);
                }
            }
        }

        public static void ShowBookToRead(Book book)
        {
            Console.WriteLine(book.Name + " by " + book.Autor + "\n");
            Console.WriteLine(book.Content.ToString() + "\n");
        }

        public static void ShowJornalToRead(Jornal jornal)
        {
            Console.WriteLine(jornal.Name + " on tile is " + jornal.LabelName);
            foreach (Article article in jornal.articles)
            {
                Console.WriteLine(article.Name + "\n" + article.Content + "\n Autor - " + article.Autor + "\n");
            }

        }

        public static void ShowNewsPaperToRead(NewsPaper newsPaper)
        {
            Console.WriteLine(newsPaper.Name);
            foreach (Article article in newsPaper.articles)
            {
                Console.WriteLine(article.Name + "\n" + article.Content + "\n Autor - " + article.Autor + "\n");
            }

        }


        public static int MainMenu()
        {
            return GetChoise("open list of books", "open list of jornals", "open list of newspapers", "read book by id", "read jornal by id", "read newspaper by id", "add book", "add jornal", "add newspaper", "delete book by id", "delete jornal by id", "delete newspaper by id", "exit");
        }

        public static int BookStorageMenu()
        {
            return GetChoise("read book by id", "delete book by id", "go to main menu", "exit");
        }

        public static int JornalStorageMenu()
        {
            return GetChoise("read jornal by id", "delete jornal by id", "go to main menu", "exit");
        }

        public static int NewsPaperStorageMenu()
        {
            return GetChoise("read newspaper by id", "delete newspaper by id", "go to main menu", "exit");
        }

        public static int SubMenu()
        {
            return GetChoise("go to main menu", "Exit");
        }

        public static Book CreateStringBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter book name:");
            book.Name = Console.ReadLine();
            Console.WriteLine("Enter autor:");
            book.Autor = Console.ReadLine();
            Console.WriteLine("Enter content");
            book.Content = Console.ReadLine();
            return book;
        }

        public static Jornal CreateStringJornal()
        {
            Jornal jornal = new Jornal();
            Console.WriteLine("Enter jornal name:");
            jornal.Name = Console.ReadLine();
            Console.WriteLine("Enter name of human on label:");
            jornal.LabelName = Console.ReadLine();

            while (true)
            {
                jornal.articles.Add(CreateStringArticle());
                int userChoise = UserIO.GetChoise("add one more article", "end creating this jornal");

                if (userChoise == 1)
                {
                    continue;
                }

                if (userChoise == 2)
                {
                    break;
                }
            }
            return jornal;
        }

        public static NewsPaper CreateStringNewsPaper()
        {
            NewsPaper newsPaper = new NewsPaper();
            Console.WriteLine("Enter newspaper name:");
            newsPaper.Name = Console.ReadLine();
            
            while (true)
            {
                newsPaper.articles.Add(CreateStringArticle());
                int userChoise = UserIO.GetChoise("add one more article", "end creating this newspaper");

                if (userChoise == 1)
                {
                    continue;
                }

                if (userChoise == 2)
                {
                    break;
                }
            }
            return newsPaper;
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


        public static int GetID(int storageLeight)
        {
            int bookId;

            if (storageLeight == 0)
            {
                Console.WriteLine("Sorry, but storage is empty");
                return -1;
            }

            while (true)
            {
                Console.Write("Enter id : ");
                if (Int32.TryParse(Console.ReadLine(), out bookId) && bookId > 0 && bookId <= storageLeight)
                {
                    return bookId - 1;
                }

                Console.WriteLine("Invalid input");
                if (bookId <= 0 || bookId > storageLeight)
                {
                    Console.WriteLine("Please enter id between 1 and " + storageLeight.ToString());
                }
            }
        }



        public static int GetChoise(params string[] options)
        {
            int choise;
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

                if (Int32.TryParse(input, out choise))
                {
                    if (choise > 0 && choise < options.Length + 1)
                    {
                        Console.Clear();
                        return choise;
                    }
                }

                Console.WriteLine("Invalid input. Please try again");
            }

        }

    }
}
