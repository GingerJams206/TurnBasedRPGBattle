using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPGBattle
{
    class Player : GameCharacter
    {
        
        public Player(string _name, int _health, int _level, int _strength, int _defense) : base(_name, _health, _level, _strength, _defense)
        {
            Name = _name;
            Health = _health;
            Level = _level;
            Strength = _strength;
            Defense = _defense;
        }

        public Player()
        {
            Name = "Link";
            Health = 10;
            Level = 5;
            Strength = 5;
            Defense = 2;
        }

        public void Attack(GameCharacter playerObj, GameCharacter enemyObj)
        {
            base.Attack(playerObj, enemyObj);
        }
    }
}
