using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Menu.CloseGameState
{
    public abstract class State
    {
        protected CloseGame _command;

        public void SetCommand(CloseGame command)
        {
            _command = command;
        }

        public abstract void Execute();
    }
}
