using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StorageModel;

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
            List<T> items = new List<T>();
            if(!System.IO.File.Exists(_fileName))
            {
                System.IO.File.CreateText(_fileName);
            }
            string[] lines = System.IO.File.ReadAllLines(_fileName);

            foreach (string line in lines)
            {
                T textPaper;
                TxtConverter.ReadFromString<T>(line, out textPaper);
                items.Add(textPaper);
            }

            return items;
        }

        public void Put<T>(List<T> items) where T : TextPaper
        {
            List<string> lines = new List<string>();

            foreach (T item in items)
            {
                lines.Add(TxtConverter.ToWritebleTxt(item));
            }

            File.WriteAllLines(_fileName, lines);
        }
    }
}