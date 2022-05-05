using System;
using System.Collections.Generic;

namespace TurnBasedRPGBattle
{
    class GameCharacter
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Strength { get; set; }
        public int Defense { get; set; }

        public int Mana { get; set; }

        public List<Spell> Spells { get; set; }

        public GameCharacter(string _name)
        {
            Name = _name;
        }

        public GameCharacter()
        {
            Name = "Bobby";
        }

        public void Attack(string objName)
        {
            Console.WriteLine($"Go {objName}!");
        }
    }
}
