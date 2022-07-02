using Assets.Scripts.Factory.Birds;
using Assets.Scripts.Factory.Pigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Factory
{
    public interface IAbstractFactory
    {
        public IBird CreateBird();
        public IPig CreatePig();
    }
}
