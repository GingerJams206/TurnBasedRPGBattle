using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPGBattle
{
    class Player : GameCharacter
    {
        public int Level { get; set; }

        public Player(string _name, int _level) : base(_name)
        {
            
            Level = _level;
        }

        public Player()
        {
            Name = "Joe";
            Level = 5;
        }

        public void Attack()
        {
            base.Attack(this.Name);
        }
    }
}
