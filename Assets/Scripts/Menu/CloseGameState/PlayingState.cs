using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Menu.CloseGameState
{
    public class PlayingState : State
    {
        public override void Execute()
        {
            Singleton.Instance.LevelManager.LoadMenu();
            _command.ChangeState(new MenuState());
        }
    }
}
