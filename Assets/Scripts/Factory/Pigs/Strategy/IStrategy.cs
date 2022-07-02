using Assets.Scripts.Factory.Pigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Pigs.Strategy
{
    public interface IStrategy
    {
        public bool CheckDestructiveColision(Collision2D collision);
    }
}
