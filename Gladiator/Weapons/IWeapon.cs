using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Weapons
{
    public interface IWeapon
    {
        string Name { set; get; }
        DamageRange DamageRange { get; }
        int GetRandomDamage()
        {
            return new Random().Next(DamageRange.Min, DamageRange.Max + 1);
        }

    }
}
