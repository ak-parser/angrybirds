using Assets.Scripts.Menu.CloseGameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Menu
{
    public class CloseGame : ICommand
    {
        private State _state;

        public CloseGame(State state)
        {
            _state = state;
            _state.SetCommand(this);
        }

        public void Execute()
        {
            _state.Execute();
        }

        public void ChangeState(State state)
        {
            _state = state;
            _state.SetCommand(this);
        }
    }
}
