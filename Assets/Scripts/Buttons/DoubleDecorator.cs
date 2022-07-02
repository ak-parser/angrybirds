using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Buttons
{
    public class DoubleDecorator : Decorator
    {
        public DoubleDecorator(ISpecialAction action)
            : base(action)
        {

        }

        public override void Action()
        {
            Singleton.Instance.Bird.Clone();
            base.Action();
        }
    }
}