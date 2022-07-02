using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class StartGame : ICommand
    {
        public void Execute()
        {
            if (SceneManager.sceneCount > 1)
                SceneManager.UnloadSceneAsync("Menu");
            else
                Singleton.Instance.LevelManager.ReloadCurrentLevel();
        }
    }
}
