using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Buttons
{
    public class ProxyAction : ISpecialAction
    {
        private Decorator _decorator;

        public ProxyAction(Decorator decorator)
        {
            _decorator = decorator;
        }

        public void Action()
        {
            if (_decorator != null)
            {
                _decorator.Action();
                File.AppendAllTextAsync("./Logs/Internal/SpecialButton.log", $"[{DateTime.Now.ToUniversalTime()}] Clicked special action\n");
            }
            else
                File.AppendAllTextAsync("./Logs/Internal/SpecialButton.log", $"[{DateTime.Now.ToUniversalTime()}] Special action wasn`t set\n");
        }
    }
}
