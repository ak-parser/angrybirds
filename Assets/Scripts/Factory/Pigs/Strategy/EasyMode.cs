using Assets.Scripts.Factory.Pigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Pigs.Strategy
{
    public class EasyMode : IStrategy
    {
        private float _stamina = 3f;

        public bool CheckDestructiveColision(Collision2D collision)
        {
            return (collision.relativeVelocity.magnitude > _stamina) ? true : false;
        }
    }
}
