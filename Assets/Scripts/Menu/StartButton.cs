using Assets.Scripts.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private ICommand _command;

    private void Start()
    {
        _command = new StartGame();
    }

    private void OnMouseDown()
    {
        _command.Execute();
    }
}
