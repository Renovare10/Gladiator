using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Weapons
{
    public class Knife : IWeapon
    {
        public string Name { get; set; } = "Knife";

        public DamageRange DamageRange { get; } = new DamageRange(4, 6);
}
}
