using Gladiator.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.WeaponSelectionStrategy
{
    public class HighestDamageStrategy : IWeaponStrategy
    {
        private IWeapon? _cachedWeapon;

        public IWeapon? SelectWeapon(List<IWeapon> inventory)
        {
            return _cachedWeapon ?? inventory.OrderByDescending(w => w.DamageRange.Max).FirstOrDefault();
        }

        public void OnInventoryChanged(List<IWeapon> inventory)
        {
            _cachedWeapon = inventory.OrderByDescending(w => w.DamageRange.Max).FirstOrDefault();
        }
    }
}
