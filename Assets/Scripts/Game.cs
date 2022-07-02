using Assets.Scripts;
using Assets.Scripts.Factory;
using Assets.Scripts.Pigs.Strategy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private int _factoryType;
    [SerializeField] private int _strategyType;

    public GameObject classicBird;
    public GameObject chuckBird;

    public GameObject classicPig;
    public GameObject bombPig;

    void Start()
    {
        Singleton.Instance.Game = this;
        if (_factoryType == 1)
            Singleton.Instance.AbstractFactory = new ClassicFactory();
        else if (_factoryType == 2)
            Singleton.Instance.AbstractFactory = new ModernFactory();

        if (_strategyType == 1)
            Singleton.Instance.Strategy = new EasyMode();
        else if (_strategyType == 2)
            Singleton.Instance.Strategy = new NormalMode();
    }
}
