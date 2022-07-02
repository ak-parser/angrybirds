using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Buttons
{
    public abstract class Decorator: ISpecialAction
    {
        protected ISpecialAction _action;

        public Decorator(ISpecialAction action)
        {
            _action = action;
        }

        public virtual void Action()
        {
            if (_action != null)
                _action.Action();
        }
    }
}
