using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageView
{
    public interface IView
    {
        void Show();
        void SetData(dynamic data);
        void AddListener(BaseView.UserChoise listener);
    }
}
