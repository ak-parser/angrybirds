using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction((OnClick)));
    }

    public void OnClick()
    {
        Singleton.Instance.LevelManager.OpenMenu();
    }
}
