using System;
using System.Collections.Generic;

namespace TurnBasedRPGBattle
{
    class GameCharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Mana { get; set; }
        public List<Spell> Spells { get; set; }

        public GameCharacter(string _name, int _health, int _level, int _strength, int _defense)
        {
            Name = _name;
            Health = _health;
            Level = _level;
            Strength = _strength;
            Defense = _defense;
        }

        public GameCharacter()
        {
            Name = "Bobby";
            Health = 1;
            Level = 1;
            Strength = 1;
            Defense = 1;
        }

        public void Attack(GameCharacter attackingCharacterObj, GameCharacter defendingCharacterObj, Random rnd)
        {
            int hitPercentage = rnd.Next(0, 101);
            if (hitPercentage <= 25)
            {
                Console.WriteLine($"{attackingCharacterObj.Name} misses");
            }
            else if (hitPercentage > 25 && hitPercentage <= 85)
            {
                NormalAttack(attackingCharacterObj, defendingCharacterObj);
            }
            else
            {
                CriticalAttack(attackingCharacterObj, defendingCharacterObj);
            }
           

            if (defendingCharacterObj.Health == 0)
            {
                Console.WriteLine($"{defendingCharacterObj.Name} has been defeated!");
                System.Threading.Thread.Sleep(3000);
            }
        }

        public void NormalAttack(GameCharacter attackingCharacterObj, GameCharacter defendingCharacterObj)
        {
            
            Console.WriteLine($"{this.Name} attacks!");
            var attackerStrength = attackingCharacterObj.Strength;

            var defenderHealth = defendingCharacterObj.Health;
            var defenderDefense = defendingCharacterObj.Defense;

            var damage = Math.Max(0, attackerStrength - defenderDefense);

            defendingCharacterObj.Health = defenderHealth - damage;
            Console.WriteLine($"{this.Name} has dealt {damage} point{(damage == 1 ? null : "s")} of damage");
            Console.WriteLine($"{defendingCharacterObj.Name} has {defendingCharacterObj.Health} points of health remaining");
        }

        public void CriticalAttack(GameCharacter attackingCharacterObj, GameCharacter defendingCharacterObj)
        {

            Console.WriteLine($"{this.Name} lands a mighty blow!");
            var attackerStrength = attackingCharacterObj.Strength * 2;

            var defenderHealth = defendingCharacterObj.Health;
            var defenderDefense = defendingCharacterObj.Defense;

            var damage = Math.Max(0, attackerStrength - defenderDefense);

            defendingCharacterObj.Health = defenderHealth - damage;
            Console.WriteLine($"{this.Name} has dealt {damage} point{(damage == 1 ? null : "s")} of damage");
            Console.WriteLine($"{defendingCharacterObj.Name} has {defendingCharacterObj.Health} points of health remaining");
        }
   
        public void CastSpell(GameCharacter attackingCharacterObj, GameCharacter defendingCharacterObj, Random rnd)
        {
            int hitPercentage = rnd.Next(0, 101);
            if (hitPercentage <= 25)
            {
                Console.WriteLine($"{attackingCharacterObj.Name} misses");
            }
            else if (hitPercentage > 25 && hitPercentage <= 85)
            {
                Console.WriteLine($"{this.Name} recites an encantation...");
                var attackerStrength = attackingCharacterObj.Strength;

                var defenderHealth = defendingCharacterObj.Health;
                var defenderDefense = defendingCharacterObj.Defense;

                var damage = Math.Max(0, attackerStrength - defenderDefense);

                defendingCharacterObj.Health = defenderHealth - damage;
            }
            else
            {
             
            }


            if (defendingCharacterObj.Health == 0)
            {
                Console.WriteLine($"{defendingCharacterObj.Name} has been defeated!");
                System.Threading.Thread.Sleep(3000);
            }
        }
    
    
    }
}
