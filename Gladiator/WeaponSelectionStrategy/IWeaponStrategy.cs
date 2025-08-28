using Gladiator.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.WeaponSelectionStrategy
{
    public interface IWeaponStrategy
    {
        IWeapon? SelectWeapon(List<IWeapon> inventory);
        void OnInventoryChanged(List<IWeapon> inventory);
    }
}
