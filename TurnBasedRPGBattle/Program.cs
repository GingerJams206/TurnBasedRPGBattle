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
            while (player.Health > 0 && enemy.Health > 0)
            {
                player.PlayerTurn = true;
                Console.WriteLine("Select Your Command: Attack, Spells, Items, Check Stats, Run");
                var userInput = Console.ReadLine();

                if (userInput.Trim().ToLower().Equals("attack"))
                {
                    Console.WriteLine(" ");
                    player.Attack(player, enemy, rnd);
                    Console.WriteLine(" ");
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
                        }
                        else
                        {
                            Console.WriteLine("Not enough mana...");
                        }
                    }
                }
                else if (userInput.Trim().ToLower().Equals("check stats"))
                {
                    player.CheckStats(player, enemy);

                }
                else if (userInput.Trim().ToLower().Equals("items"))
                {
                    var itemReadout = new List<string>();
                    player.Items.ForEach(item => itemReadout.Add($"Name: {item.Name} - Qty: {item.Quantity}"));
                    Console.WriteLine("Select an item: ");
                    Console.WriteLine(string.Join(", ", itemReadout));
                    Console.WriteLine(" ");
                    var itemInput = Console.ReadLine();
                    var selectedItem = player.Items.Where(item => item.Name.Trim().ToLower().Equals(itemInput.Trim().ToLower()));

                    if (selectedItem.Any())
                    {
                        var item = selectedItem.First();
                        if (item.Classification.Equals("Aid"))
                        {
                            player.UseItem(player, item);
                        }
                        else
                        {
                            Console.WriteLine("This isn't the time to use that!");
                        }
                    }
                }
                if (player.PlayerTurn == false)
                {
                    Console.WriteLine(" ");
                    enemy.EnemyAttack(player, enemy, rnd);
                }

            }
        }
    }
}
