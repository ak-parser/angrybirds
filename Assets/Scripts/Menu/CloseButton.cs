using Assets.Scripts.Menu;
using Assets.Scripts.Menu.CloseGameState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{
    private ICommand _command;

    private void Start()
    {
        _command = new CloseGame(SceneManager.sceneCount > 1 ? new PlayingState() : new MenuState());
    }

    private void OnMouseDown()
    {
        _command.Execute();
    }
}
