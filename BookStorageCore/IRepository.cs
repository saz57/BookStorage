using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorageCore
{
    public interface IBookRepository
    {
        List<Book> Get();
        void Put(List<Book> list);
    }
}
