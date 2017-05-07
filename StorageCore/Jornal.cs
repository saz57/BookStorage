using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore
{
    [Serializable]
    public class Jornal : NewsPaper
    {
        public string LabelName { get; set; }

        public Jornal()
        { }

        public Jornal(string input)
        {
            ReadFromString(input);
        }

        public override string ToWritebleTxt()
        {
            string result = "<Jornal><Name>" + Name + "</Name><LabelName>" + LabelName + "</LabelName>";

            foreach (Article article in articles)
            {
                result += article.ToWritable(); // not ToString() - write somesing else
            }
            result += "</Jornal>";
            return result;
        }
        public override void ReadFromString(string input)
        {
            LabelName = TextPaper.ReadContext("LabelName", input);
            base.ReadFromString(input);
        }

    }
}
