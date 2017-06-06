using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;

namespace StorageCore
{
    public static class TxtConverter
    {
        #region ToWritebleTxt
        public static string ToWritebleTxt(TextPaper textPaper)
        {
            if (textPaper.GetType() == typeof(Book))
            {
                return ToWritebleTxt(textPaper as Book);
            }

            if (textPaper.GetType() == typeof(Jornal))
            {
                return ToWritebleTxt(textPaper as Jornal);
            }

            if (textPaper.GetType() == typeof(NewsPaper))
            {
                return ToWritebleTxt(textPaper as NewsPaper);
            }

            return "";
        }

        public static string ToWritebleTxt(Book book)
        {
            string result;
            result = "<Book><Name>" + book.Name + "</Name><Autor>" + book.Autor + "</Autor><Content>" + book.Content + "</Content></Book>";
            return result;
        }

        public static string ToWritebleTxt(Jornal jornal)
        {
            string result = "<Jornal><Name>" + jornal.Name + "</Name><LabelName>" + jornal.LabelName + "</LabelName>";

            foreach (Article article in jornal.Articles)
            {
                result += ToWritebleTxt(article);
            }

            result += "</Jornal>";
            return result;
        }

        public static string ToWritebleTxt(NewsPaper newsPaper)
        {
            string result = "<NewsPaper><Name>" + newsPaper.Name + "</Name>";

            foreach (Article article in newsPaper.Articles)
            {
                result += ToWritebleTxt(article);
            }
            result += "</NewsPaper>";
            return result;
        }

        public static string ToWritebleTxt(Article article)
        {
            return "<Article><Name>" + article.Name + "</Name><Autor>" + article.Autor + "</Autor><Content>" + article.Content.ToString() + "</Content></Article>";
        }
        #endregion

        #region ReadFromString
        public static void ReadFromString<T>(string input, out T textPaper) where T : TextPaper
        {
            int index;
            char[] typeIdentity;
            textPaper = null;
            index = input.IndexOf('>');
            typeIdentity = new char[index + 1];
            input.CopyTo(0, typeIdentity, 0, index + 1);

            switch (new string(typeIdentity))
            {
                case "<Book>":
                    Book book = new Book();
                    ReadFromString(input, out book);
                    textPaper = book as T;
                    break;

                case "<NewsPaper>":
                    NewsPaper newsPaper = new NewsPaper();
                    ReadFromString(input, out newsPaper);
                    textPaper = newsPaper as T;
                    break;

                case "<Jornal>":
                    Jornal jornal = new Jornal();
                    ReadFromString(input, out jornal);
                    textPaper = jornal as T;
                    break;
            }
        }

        private static void ReadFromString(string input, out Book book)
        {
            book = new Book();
            book.Name = ReadContext("Name", input);
            book.Autor = ReadContext("Autor", input);
            book.Content = ReadContext("Content", input);
        }

        private static void ReadFromString(string input, out Jornal jornal)
        {
            jornal = new Jornal();
            List<Article> articles;
            jornal.Name = ReadContext("Name", input);
            jornal.LabelName = ReadContext("LabelName", input);
            ArticleReader(input, out articles);
            jornal.Articles = new List<Article>(articles);

        }

        private static void ReadFromString(string input, out NewsPaper newspaper)
        {
            newspaper = new NewsPaper();
            List<Article> articles;
            newspaper.Name = ReadContext("Name", input);
            ArticleReader(input, out articles);
            newspaper.Articles = new List<Article>(articles);
        }

        private static void ReadFromString(string input, out Article article)
        {
            article = new Article();
            article.Name = ReadContext("Name", input);
            article.Autor = ReadContext("Autor", input);
            article.Content = ReadContext("Content", input);
        }
        #endregion


        private static void ArticleReader(string input, out List<Article> articles)
        {

            int articleStart = 0;
            int articleEnd = 0;
            articles = new List<Article>();

            while (true)
            {
                articleStart = input.IndexOf("<Article>", articleStart);

                if (articleStart == (-1))
                {
                    break;
                }

                if (articleStart != (-1))
                {
                    Article article;
                    articleEnd = input.IndexOf("</Article>", articleStart);
                    ReadFromString(input.Substring(articleStart, articleEnd - articleStart), out article);
                    articles.Add(article);
                    articleStart = articleEnd;
                }
            }
        }



        public static string ReadContext(string contextWord, string sourseString)
        {
            int startIndex = 0;
            int endIndex = 0;
            char[] buffer;
            startIndex = sourseString.IndexOf("<" + contextWord + ">") + (contextWord.Length + 2);
            endIndex = sourseString.IndexOf("</" + contextWord + ">");
            buffer = new char[endIndex - startIndex];
            sourseString.CopyTo(startIndex, buffer, 0, endIndex - startIndex);
            return new string(buffer);
        }
    }
}
