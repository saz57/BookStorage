using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore
{
    public abstract class TextPaper
    {
        public string Name {get; set;}

        public virtual string ToWritebleTxt()
        {
            return "";
        }

        public virtual string ToWritebleSql()
        {
            return "";
        }

        public virtual void ReadFromString(string input)
        {

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
