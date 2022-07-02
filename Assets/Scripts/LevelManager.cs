using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LevelManager
    {
        public const int LEVELS_COUNT = 2;

        private int _currentLevel = 1;

        public async void LoadNextLevel()
        {
            if (_currentLevel >= LEVELS_COUNT)
                _currentLevel = 0;

            if (SceneManager.sceneCount > 0 && SceneManager.GetActiveScene().isLoaded)
            {
                await Task.Delay(2000);
                SceneManager.LoadScene("Level" + ++_currentLevel, LoadSceneMode.Single);
            }
            else
                _currentLevel = 1;
        }

        public void ReloadCurrentLevel()
        {
            if (SceneManager.sceneCount > 0 && SceneManager.GetActiveScene().isLoaded)
                SceneManager.LoadScene("Level" + _currentLevel, LoadSceneMode.Single);
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            _currentLevel = 1;
        }

        public void OpenMenu()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }
    }
}
