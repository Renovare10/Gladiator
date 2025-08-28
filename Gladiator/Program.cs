using Gladiator;

Character hero = new Character { Health = 100 };
Character goblin = new Character { Health = 30 };

while (hero.Alive)
{
    Helper.PrintStatus(hero, goblin);
    
    hero.Attact(goblin);
    goblin.Attact(hero);

    Console.WriteLine("Press Enter to continue");
    Console.ReadLine();
}