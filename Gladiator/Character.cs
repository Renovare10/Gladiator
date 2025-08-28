using Gladiator.Weapons;
using Gladiator.WeaponSelectionStrategy;
using System;
using System.Collections.Generic;

namespace Gladiator
{
    public class Character
    {
        public int Health { get; set; }
        public bool Alive => Health > 0;
        public List<IWeapon> Inventory { get; } = [];
        private readonly IWeaponStrategy _weaponStrategy;

        // Events for attack and death, nullable to allow unassigned state
        public event Action<Character, Character, int>? OnAttack;
        public event Action<Character>? OnDeath;

        public Character(IWeaponStrategy? weaponStrategy = null)
        {
            _weaponStrategy = weaponStrategy ?? new HighestDamageStrategy();
            Inventory.Add(new Weapons.Fist()); // Ensure non-empty inventory
            _weaponStrategy.OnInventoryChanged(Inventory); // Initialize weapon
        }

        // Attacks target with strategy-selected weapon
        public void Attact(Character target)
        {
            var weapon = _weaponStrategy.SelectWeapon(Inventory);
            if (weapon == null)
                return; // No weapon available
            int damage = weapon.GetRandomDamage();
            target.Damage(damage);
            OnAttack?.Invoke(this, target, damage);
        }

        // Reduces health, fires death event if dead
        public void Damage(int damage)
        {
            Health = Math.Max(0, Health - damage);
            if (!Alive)
                OnDeath?.Invoke(this);
        }

        // Adds weapon and updates strategy
        public void AddWeapon(IWeapon newWeapon)
        {
            Inventory.Add(newWeapon);
            _weaponStrategy.OnInventoryChanged(Inventory);
        }

        // Removes weapon and updates strategy
        public void RemoveWeapon(IWeapon weaponToRemove)
        {
            Inventory.Remove(weaponToRemove);
            _weaponStrategy.OnInventoryChanged(Inventory);
        }

        // Gets the current weapon selected by strategy
        public IWeapon? GetCurrentWeapon()
        {
            return _weaponStrategy.SelectWeapon(Inventory);
        }
    }
}