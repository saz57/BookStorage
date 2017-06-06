using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageView
{
    public abstract class BaseView: IView
    {
        public delegate void UserChoise(int choice);
        private event UserChoise ChoiseEvent;

        public abstract void Show();
        public virtual void SetData(dynamic data)
        { }

        public void AddListener(UserChoise listener)
        {
            ChoiseEvent += listener;
        }

        protected void ActivateEvent(int choice)
        {
            ChoiseEvent(choice);
        }
    }
}
