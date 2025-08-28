using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Weapons
{
    public struct DamageRange
    {
        public int Min { get; }
        public int Max { get; }

        public DamageRange(int min, int max)
        {
            if (min > max)
                throw new ArgumentException("Min cannot be greater than Max");
            Min = min;
            Max = max;
        }
    }
}
