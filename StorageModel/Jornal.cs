using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageModel
{
    [Serializable]
    public class Jornal : NewsPaper
    {
        public string LabelName { get; set; }

        public Jornal()
        {
            
        }
    }
}
