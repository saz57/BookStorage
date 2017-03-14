using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorageCore;

namespace BookStorageViev
{
    public static class UserIO
    {
        public static void ShowBookStorage(BookStorage bookStorage)
        {
            int booksCount = 0;
            List<Book> storage = bookStorage.GetStorage();
            foreach(Book book in storage)
            {
                booksCount++;
                Console.WriteLine(booksCount.ToString() + " " + book.Name + " by " + book.Autor);
            }
        }

        public static void ShowBookToRead(Book book)
        {
            Console.WriteLine(book.Name + " by " + book.Autor + "\n");
            Console.WriteLine(book.Content.ToString() + "\n");
        }

        public static int MainMenu()
        {
            return GetChoise("open list of books", "read book by id", "add book", "delete book by id", "exit");
        }

        public static int StorageMenu()
        {
            return GetChoise("read book by id", "delete book by id", "go to start menu", "exit");
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

        public static int GetID(int storageLeight)
        {
            int bookId;
            while (true)
            {
                Console.Write("Enter book id : ");
                if (Int32.TryParse(Console.ReadLine(), out bookId) && bookId > 0 && bookId <= storageLeight )
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
            
            while(true)
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
