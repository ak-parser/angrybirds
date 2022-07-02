using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Factory.Birds
{
    public interface IBird
    {
        public GameObject gameObject { get; }
        public void Release();

        public IBird Clone();
    }
}
