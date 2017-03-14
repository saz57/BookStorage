using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace BookStorageCore
{
    public class XMLBookRepository: IBookRepository
    {
        private XmlSerializer _formatter;

        public XMLBookRepository()
        {
            //XmlRootAttribute xRoot;

            _formatter = new XmlSerializer(typeof(List<Book>));
        }

        public List<Book> Get()
        {
            List<Book> books;


            using (FileStream fileStream = new FileStream("storage.xml", FileMode.OpenOrCreate))
            {
                if(fileStream.Length == 0)
                { 
                    return new List<Book>(); 
                }
                books =  (List<Book>)_formatter.Deserialize(fileStream);
            }

            return books;
        }

        public void Put(List<Book> books)
        {
            using (FileStream fileStream = new FileStream("storage.xml", FileMode.OpenOrCreate,FileAccess.Write))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                _formatter.Serialize(fileStream, books);
            }
        }
    }
}

  