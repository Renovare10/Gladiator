namespace Gladiator.Weapons
{
    internal class Fist : IWeapon
    {
        public string Name { get; set; } = "Fist";
        public DamageRange DamageRange { get; } = new DamageRange(1, 3);
    }
}