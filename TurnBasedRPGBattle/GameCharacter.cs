using System;
using System.Collections.Generic;

namespace TurnBasedRPGBattle
{
    class GameCharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public List<Spell> Spells { get; set; }

        public GameCharacter(string _name, int _health, int _level, int _strength, int _defense, int _mana, List<Spell> _spells)
        {
            Name = _name;
            Health = _health;
            MaxHealth = _health;
            Level = _level;
            Strength = _strength;
            Defense = _defense;
            Mana = _mana;
            MaxMana = _mana;
            Spells = _spells;
        }

        public GameCharacter()
        {
            Name = "Bobby";
            Health = 1;
            MaxHealth = 1;
            Level = 1;
            Strength = 1;
            Defense = 1;
            Mana = 1;
            MaxMana = 1;
            Spells = new List<Spell> {  };
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

        
        public void CastSpell(GameCharacter attackingCharacterObj, GameCharacter defendingCharacterObj, Random rnd, Spell spell)
        {
            int hitPercentage = rnd.Next(0, 101);
            if (hitPercentage <= 25)
            {
                Console.WriteLine($"{attackingCharacterObj.Name} misses");
            }
            else if (hitPercentage > 25 && hitPercentage <= 85)
            {
                NormalCast(attackingCharacterObj, defendingCharacterObj, spell);
            }
            else
            {
                CriticalCast(attackingCharacterObj, defendingCharacterObj, spell);
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
            Console.WriteLine($"{defendingCharacterObj.Name} has {defendingCharacterObj.Health} point{(defendingCharacterObj.Health == 1 ? null : "s")} of health remaining");
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
            Console.WriteLine($"{defendingCharacterObj.Name} has {defendingCharacterObj.Health} point{(defendingCharacterObj.Health == 1 ? null : "s")} of health remaining");
        }


        public void NormalCast(GameCharacter attackingCharacterObj, GameCharacter defendingCharacterObj, Spell spell)
        {
            attackingCharacterObj.Mana -= spell.Cost;
            Console.WriteLine($"{this.Name} recites an incantation...");
            Console.WriteLine($"{this.Name} casts {spell.Name}");
            var attackerStrength = spell.Damage;

            var defenderHealth = defendingCharacterObj.Health;
            var defenderDefense = defendingCharacterObj.Defense;

            var damage = Math.Max(0, attackerStrength - defenderDefense);

            defendingCharacterObj.Health = defenderHealth - damage;
            Console.WriteLine($"{this.Name} has dealt {damage} point{(damage == 1 ? null : "s")} of damage");
            Console.WriteLine($"{defendingCharacterObj.Name} has {defendingCharacterObj.Health} point{(defendingCharacterObj.Health == 1 ? null : "s")} of health remaining");
        }

        public void CriticalCast(GameCharacter attackingCharacterObj, GameCharacter defendingCharacterObj, Spell spell)
        {
            attackingCharacterObj.Mana -= spell.Cost;
            Console.WriteLine($"{this.Name} recites an incantation...The skies darken and the ground shakes.");
            Console.WriteLine($"{this.Name} casts {spell.Name}");
            var attackerStrength = spell.Damage * 2;

            var defenderHealth = defendingCharacterObj.Health;
            var defenderDefense = defendingCharacterObj.Defense;

            var damage = Math.Max(0, attackerStrength - defenderDefense);

            defendingCharacterObj.Health = defenderHealth - damage;
            Console.WriteLine($"{this.Name} has dealt {damage} point{(damage == 1 ? null : "s")} of damage");
            Console.WriteLine($"{defendingCharacterObj.Name} has {defendingCharacterObj.Health} point{(defendingCharacterObj.Health == 1 ? null : "s")} of health remaining");
        }

        public void CheckStats(GameCharacter player, GameCharacter enemy)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press the 'Enter' key to return");
            Console.WriteLine(" ");
            Console.WriteLine($"Player Health: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Player Mana: {player.Mana}/{player.MaxMana}");
            Console.WriteLine($"Enemy Name: {enemy.Name}");
            Console.WriteLine($"Enemy Health: {enemy.Health}/{enemy.MaxHealth}");

            var keyInput = Console.ReadKey(true).Key;
            if (keyInput == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
            } else
            {
                CheckStats(player, enemy);
            }
        }


        public void EnemyAttack(GameCharacter player, GameCharacter enemy, Random rnd)
        {
            Random enemyAI = new Random();
            int enemyChoice = enemyAI.Next(0, 101);

            if (enemyChoice < 61)
            {
                enemy.Attack(enemy, player, rnd);
            }
            else
            {
                Random enemySpell = new Random();
                int index = enemySpell.Next(enemy.Spells.Count);
                var spell = enemy.Spells[index];
                enemy.CastSpell(enemy, player, rnd, spell);
            }
        }
    }
}
