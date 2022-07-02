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
    public class ClassicFactory: IAbstractFactory
    {
        public IBird CreateBird()
        {
            return GameObject.Instantiate(Singleton.Instance.Game.classicBird).GetComponent<Bird>();
        }

        public IPig CreatePig()
        {
            return GameObject.Instantiate(Singleton.Instance.Game.classicPig).GetComponent<Pig>();
        }
    }
}
