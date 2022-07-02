using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Buttons
{
    internal class FallDecorator: Decorator
    {
        public FallDecorator(ISpecialAction action)
            : base(action)
        {

        }

        public override void Action()
        {
            Singleton.Instance.Bird.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3();
            base.Action();
        }
    }
}
