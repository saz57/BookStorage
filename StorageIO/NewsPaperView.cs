using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;

namespace StorageView
{
    public class NewsPaperView : BaseView
    {
        private NewsPaper _newsPaper;

        public override void Show()
        {
            if (_newsPaper != null)
            {
                Console.WriteLine(_newsPaper.Name + "\n");
                foreach (Article article in _newsPaper.Articles)
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
            _newsPaper = data;
        }
    }
}
