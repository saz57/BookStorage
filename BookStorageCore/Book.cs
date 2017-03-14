using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookStorageCore
{
    [Serializable]
    public class Book
    {
        public string Name  { get; set;}
        public string Autor { get; set; }
        public object Content { get; set; }
    }
}
