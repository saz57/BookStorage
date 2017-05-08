using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StorageCore
{
    [Serializable]
    public class Book : TextPaper
    {
        public string Autor { get; set; }
        public object Content { get; set; }

        public Book()
        { }

        public Book(string input)
        {
            ReadFromString(input);
        }

        public override string ToWritebleTxt()
        {
            string result;

            result = "<Book><Name>" + Name + "</Name><Autor>" + Autor + "</Autor><Content>" + Content + "</Content></Book>";

            return result;
        }

        public override string ToWritebleSql()
        {
            string result;
            result = "('" + Name + "','" + Autor + "','" + Content + "')";
            return result;

        }

        public override void ReadFromString(string input)
        {
            Name = TextPaper.ReadContext("Name", input);
            Autor = TextPaper.ReadContext("Autor", input);
            Content = TextPaper.ReadContext("Content", input);
        }

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
