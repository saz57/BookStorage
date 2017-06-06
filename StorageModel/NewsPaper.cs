using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageModel
{
    [Serializable]
    public class NewsPaper : TextPaper
    {
        public List<Article> Articles { get; set; }

        public NewsPaper()
        {
            Articles = new List<Article>();
        }   
    }
}
