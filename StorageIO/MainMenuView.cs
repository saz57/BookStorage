using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageView
{
    public class MainMenuView : BaseView
    {
        public override void Show()
        {
            ActivateEvent(ConsoleIO.GetChoice("open list of books", "open list of jornals", "open list of newspapers",
                "read book by id", "read jornal by id", "read newspaper by id", "add book", "add jornal", "add newspaper",
                "delete book by id", "delete jornal by id", "delete newspaper by id", "exit"));
        }

    }
}
