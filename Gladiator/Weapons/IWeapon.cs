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
        int Damage { set; get; }
    }
}
