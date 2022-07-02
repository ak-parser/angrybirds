using Assets.Scripts.Factory.Birds;
using Assets.Scripts.Factory.Pigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Factory
{
    public class ModernFactory: IAbstractFactory
    {
        public IBird CreateBird()
        {
            return GameObject.Instantiate(Singleton.Instance.Game.chuckBird).GetComponent<ChuckBird>();
        }

        public IPig CreatePig()
        {
            return GameObject.Instantiate(Singleton.Instance.Game.bombPig).GetComponent<BombPig>();
        }
    }
}
