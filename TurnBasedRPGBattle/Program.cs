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
            GameCharacter enemy = new GameCharacter("Bat", 10, 10, 3, 3);
            Player player = new Player();

            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("Select Your Command: Attack, Spells, Items, Run");
                var userInput = Console.ReadLine();

                if (userInput.Trim().ToLower().Equals("attack"))
                {
                    Console.WriteLine(" ");
                    player.Attack(player, enemy);
                    Console.WriteLine(" ");
                    enemy.Attack(enemy, player);
                    Console.WriteLine(" ");
                }
                
            }
        }
    }
}
