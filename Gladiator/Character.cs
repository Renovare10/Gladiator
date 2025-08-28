using Gladiator.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    public class Character
    {
        public int Health { get; set; }
        public bool Alive => Health > 0;
        public IWeapon weapon { get; set; } = new Weapons.Fist();

        public void Attact(Character p1)
        {
            p1.Damage(this.weapon.Damage);
        }

        public void Damage(int damage)
        {
            this.Health -= damage;
        }
    }
}
