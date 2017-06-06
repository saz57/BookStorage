using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageModel;

namespace StorageView
{
    public abstract class CreativeView :BaseView
    {
        public delegate void CreateNewItem(TextPaper textPaper);
        private event CreateNewItem CreateEvent;

        public void AddListenerToCreate(CreateNewItem listener)
        {
            CreateEvent += listener;
        }

        public void ActivateCreateEvent(TextPaper textPaper)
        {
            CreateEvent(textPaper);
        }
    }
}
