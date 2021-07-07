using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using UnityEngine;

namespace Moonlight
{
    class Math
    {
        public static double PythagoreanV3(Vector3 v3a, Vector3 v3b) 
        {
            double d = Sqrt(Pow((v3a.x - v3b.x), 2) + Pow((v3a.y - v3b.y), 2) + Pow((v3a.z - v3b.z), 2));
            return d;
        }
        public static double PythagoreanV2(Vector2 v3a, Vector2 v3b)
        {
            double d = Sqrt(Pow((v3a.x - v3b.x), 2) + Pow((v3a.y - v3b.y), 2));
            return d;
        }
    }
}
