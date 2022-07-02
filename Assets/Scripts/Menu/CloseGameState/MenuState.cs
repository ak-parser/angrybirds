using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Menu.CloseGameState
{
    public class MenuState : State
    {
        public override void Execute()
        {
            Application.Quit();
            _command.ChangeState(new PlayingState());
        }
    }
}
