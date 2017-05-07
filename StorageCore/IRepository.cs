using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore
{
    public interface IRepository
    {
        List<T> Get<T>() where T : TextPaper;
        void Put<T>(List<T> list) where T : TextPaper;
    }
}
