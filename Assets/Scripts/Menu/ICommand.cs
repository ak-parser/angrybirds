using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Menu.CloseGameState;

namespace Assets.Scripts.Menu
{
    public interface ICommand
    {
        public void Execute();
    }
}
