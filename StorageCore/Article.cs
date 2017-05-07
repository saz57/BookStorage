using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore
{
    public class Article
    {
        public string Name { get; set; }
        public string Autor { get; set; }
        public string Content { get; set; }

        public Article()
        { }

        public Article(string input)
        {
            ReadFromString(input);
        }

        public string ToWritable()
        {
            return "<Article><Name>" + Name + "</Name><Autor>" + Autor + "</Autor><Content>" + Content.ToString() + "</Content></Article>";
        }

        public void ReadFromString(string input)
        {
            Name = TextPaper.ReadContext("Name", input);
            Autor = TextPaper.ReadContext("Autor", input);
            Content = TextPaper.ReadContext("Content", input);
        }
    }
}
