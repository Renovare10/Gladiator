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
        public IWeapon Weapon { get; set; } = new Weapons.Fist();

        // Events for attack and death
        public event Action<Character, Character, int>? OnAttack;
        public event Action<Character>? OnDeath;

        public void Attact(Character target)
        {
            int damage = Weapon.GetRandomDamage();
            target.Damage(damage);
            OnAttack?.Invoke(this, target, damage);
        }

        public void Damage(int damage)
        {
            Health = Math.Max(0, Health - damage);
            if (!Alive)
            {
                OnDeath?.Invoke(this);
            }
        }
    }
}
