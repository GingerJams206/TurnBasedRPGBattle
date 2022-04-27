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
            GameCharacter gc = new GameCharacter();
            gc.Attack(gc.Name);

            Player player = new Player();
            player.Attack(player.Name);
        }
    }
}
