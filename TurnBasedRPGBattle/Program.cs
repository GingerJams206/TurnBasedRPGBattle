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
                player.Attack(player, enemy);
                enemy.Attack(enemy, player);
                
            }
            Console.ReadLine();
        }
    }
}
