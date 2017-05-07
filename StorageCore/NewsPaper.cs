using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore
{
    [Serializable]
    public class NewsPaper :TextPaper
    {
        public List<Article> articles { get; set; }

        public NewsPaper()
        {
            articles = new List<Article>();
        }

        public NewsPaper(string input)
        {
            articles = new List<Article>();
            ReadFromString(input);
        }

        public override string ToWritebleTxt()
        {
            string result = "<NewsPaper><Name>" + Name + "</Name>";

            foreach (Article article in articles)
            {
                result += article.ToWritable();
            }
            result += "</NewsPaper>";
            return result;
        }

        public override void ReadFromString(string input)
        {
            int articleStart = 0;
            int articleEnd = 0;
            Name = TextPaper.ReadContext("Name", input);
            while(true)
            {
                articleStart = input.IndexOf("<Article>", articleStart);
                if (articleStart == (-1))
                {
                    break;
                }

                if (articleStart != (-1))
                {
                    articleEnd = input.IndexOf("</Article>", articleStart);
                    articles.Add(new Article(input.Substring(articleStart,articleEnd - articleStart)));
                    articleStart = articleEnd;
                }
            }
        }
    }
}
