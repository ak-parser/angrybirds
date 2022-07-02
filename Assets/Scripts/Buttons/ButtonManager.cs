using Assets.Scripts;
using Assets.Scripts.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private bool _clicked;

    private void Start()
    {
        _clicked = false;
        GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction((OnClick)));
    }

    private void Update()
    {
        var button = GetComponent<Button>();
        if (Singleton.Instance.Bird == null || _clicked)
            button.interactable = false;
        else
            button.interactable = true;
    }

    private void OnClick()
    {
        Decorator decorator;

        switch (Random.Range(1, 4))
        {
            case 1:
                decorator = new DoubleDecorator(null);
                break;
            case 2:
                decorator = new FallDecorator(null);
                break;
            case 3:
                decorator = new FallDecorator(new DoubleDecorator(null));
                break;
            default:
                decorator = null;
                break;
        }

        var proxyAction = new ProxyAction(decorator);
        proxyAction.Action();

        _clicked = true;
    }
}
