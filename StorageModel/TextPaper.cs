using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageModel
{
    public abstract class TextPaper
    {
        public string Name {get; set;}

        public virtual string ToWritebleSql()
        {
            return "";
        }
    }
}
