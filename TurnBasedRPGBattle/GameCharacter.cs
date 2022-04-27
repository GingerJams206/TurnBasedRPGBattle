using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPGBattle
{
    class GameCharacter
    {
        public string Name { get; set; }

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
