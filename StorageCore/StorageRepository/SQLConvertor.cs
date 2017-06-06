using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;

namespace StorageCore
{
    public static class SQLConvertor
    {
        public static string ToWritebleSql<T>(T textPaper) where T : TextPaper
        {
            if (typeof(T) == typeof(Book))
            {
                return ToWritebleSql(textPaper as Book);
            }

            if (typeof(T) == typeof (Jornal))
            {
            }

            if (typeof(T) == typeof(NewsPaper))
            {
            }
            
            return "";
        }

        public static string ToWritebleSql(Book book)
        {
            string result;
            result = "('" + book.Name + "','" + book.Autor + "','" + book.Content + "')";
            return result;
        }

       /* public static string ToWritebleSql(Jornal jornal)
        {
            string result;
            result = "('" + jornal.Name + "','" + jornal.LabelName;
            
            foreach (Article article in jornal.Articles)
            {
                retult += ",'" + ToWritebleSql(article) + "',";
            }

            result += "')";
            return result;
        }

        public static string ToWritebleSql(NewsPaper newspaper)
        {
            string result;
            result = "('" + newspaper.Name + "','" + book.Autor + "','" + book.Content + "')";
            return result;
        }

        private static string ToWritebleSql(Article article)
        {
            return article.Name + "','" + article.Autor + "','" + article.Content;
        }*/
    }
}
