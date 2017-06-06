using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StorageModel
{
    [Serializable]
    public class Book : TextPaper
    {
        public string Autor { get; set; }
        public object Content { get; set; }

        public Book()
        { }

        public override bool Equals(object book)
        {
            if (typeof(Book) == book.GetType())
            {
                Book buffBook = (Book)book;
                return ((this.Name.Equals(buffBook.Name)) && (this.Autor.Equals(buffBook.Autor)) && (this.Content.GetHashCode() == buffBook.Content.GetHashCode()));
            }

            return base.Equals(book);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
