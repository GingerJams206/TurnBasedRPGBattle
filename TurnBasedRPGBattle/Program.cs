using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPGBattle
{
    class Program
    {

        
        static void Main(string[] args)
        {
            GameCharacter enemy = new GameCharacter("Bat", 10, 10, 3, 3, 5, new List<Spell> { new Spell { Name = "Screech", Description = "A loud piercing shriek", Damage = 4, Cost = 2 } });
            Player player = new Player();
            Random rnd = new Random();
            bool playerTurn = false;
            while (player.Health > 0 && enemy.Health > 0)
            {
                playerTurn = true;
                Console.WriteLine("Select Your Command: Attack, Spells, Items, Run");
                var userInput = Console.ReadLine();

                if (userInput.Trim().ToLower().Equals("attack"))
                {
                    Console.WriteLine(" ");
                    player.Attack(player, enemy, rnd);
                    Console.WriteLine(" ");
                    playerTurn = false;
                }
                else if (userInput.Trim().ToLower().Equals("spells"))
                {
                    var spellReadout = new List<string>();
                    player.Spells.ForEach(spell => spellReadout.Add($"Name: {spell.Name} - MP: {spell.Cost}"));
                    Console.WriteLine("Select a spell: ");
                    Console.WriteLine(string.Join(", ", spellReadout));
                    Console.WriteLine(" ");
                    var spellInput = Console.ReadLine();
                    var selectedSpell = player.Spells.Where(spell => spell.Name.Trim().ToLower().Equals(spellInput.Trim().ToLower()));

                    if (selectedSpell.Any())
                    {
                        var spell = selectedSpell.First();
                        if (player.Mana - spell.Cost > 0)
                        {
                            player.CastSpell(player, enemy, rnd, spell);
                            playerTurn = false;
                        } else
                        {
                            Console.WriteLine("Not enough mana...");
                        }
                    }
                }

                if (playerTurn == false)
                {
                    Console.WriteLine(" ");
                    enemy.EnemyAttack(player, enemy, rnd);
                }
                
            }
        }
    }
}
