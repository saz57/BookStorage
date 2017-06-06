using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using StorageModel;

namespace StorageCore
{
    public class XMLRepository : IRepository
    {
        private XmlSerializer _formatter;

        public XMLRepository(Type type)
        {
            if (type == typeof(Book))
            {
                _formatter = new XmlSerializer(typeof(List<Book>));
            }

            if (type == typeof(Jornal))
            {
                _formatter = new XmlSerializer(typeof(List<Jornal>));
            }

            if (type == typeof(NewsPaper))
            {
                _formatter = new XmlSerializer(typeof(List<NewsPaper>));
            }
        }

        public List<T> Get<T>() where T : TextPaper
        {
            List<T> books;


            using (FileStream fileStream = new FileStream("storage.xml", FileMode.OpenOrCreate))
            {
                if (fileStream.Length == 0)
                {
                    return new List<T>();
                }
                books = (List<T>)_formatter.Deserialize(fileStream);
            }

            return books;
        }

        public void Put<T>(List<T> item) where T : TextPaper
        {
            using (FileStream fileStream = new FileStream("storage.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                _formatter.Serialize(fileStream, item);
            }
        }
    }
}

