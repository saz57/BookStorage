using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StorageCore
{
    public class TxtRepository : IRepository
    {
        private string _fileName = "TxtStorage.txt";

        public TxtRepository()
        {

        }

        public List<T> Get<T>() where T : TextPaper
        {
            int index;
            char[] typeIdentity;
            T bufferItem;

            List<T> items = new List<T>();
            string[] lines = System.IO.File.ReadAllLines(_fileName);

            foreach (string line in lines)
            {
                index = line.IndexOf('>');
                typeIdentity = new char[index + 1];
                line.CopyTo(0, typeIdentity, 0, index + 1);
                switch (new string(typeIdentity))
                {
                    case "<Book>":
                        bufferItem = new Book(line) as T;
                        items.Add(bufferItem);
                        break;

                    case "<NewsPaper>":
                        bufferItem = new NewsPaper(line) as T;
                        items.Add(bufferItem);
                        break;

                    case "<Jornal>":
                        bufferItem = new Jornal(line) as T;
                        items.Add(bufferItem);
                        break;
                }
            }

            return items;
        }

        public void Put<T>(List<T> items) where T : TextPaper
        {
            List<string> lines = new List<string>();

            foreach (T item in items)
            {
                lines.Add(item.ToWritebleTxt());
            }

            File.WriteAllLines(_fileName, lines);
        }
    }
}