using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;

namespace StorageView
{
    public class JornalView: BaseView
    {
        private Jornal _jornal;

        public override void Show()
        {
            if (_jornal != null)
            {
                Console.WriteLine(_jornal.Name + " with " + _jornal.LabelName + "on label \n");
                foreach(Article article in _jornal.Articles)
                {
                    Console.WriteLine(article.Name + "\nby ");
                    Console.WriteLine(article.Autor + "\n");
                    Console.WriteLine(article.Content + "\n");
                }
                
            }
            base.ActivateEvent(ConsoleIO.SubMenu());
        }

        public override void SetData(dynamic data)
        {
            _jornal = data;
        }
    }
}
