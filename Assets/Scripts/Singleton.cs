using Assets.Scripts.Factory;
using Assets.Scripts.Factory.Birds;
using Assets.Scripts.Factory.Pigs;
using Assets.Scripts.Pigs.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal sealed class Singleton
    {
        private static Singleton _instance;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public Game Game { get; set; }

        public LevelManager LevelManager { get; private set; }

        public IAbstractFactory AbstractFactory { get; set; }

        public IBird Bird { get; set; }

        public List<IPig> Pigs { get; private set; }

        public IStrategy Strategy { get; set; }
        public float BottomBoundary { get; set; }

        private Singleton()
        {
            Pigs = new List<IPig>();
            LevelManager = new LevelManager();
            Strategy = new NormalMode();
        }
    }
}
