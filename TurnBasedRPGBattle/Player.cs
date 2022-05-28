using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPGBattle
{
    class Player : GameCharacter
    {
        
        public Player(string _name, int _health, int _level, int _strength, int _defense, int _mana, List<Spell> _spells) : base(_name, _health, _level, _strength, _defense, _mana, _spells)
        {
            Name = _name;
            Health = _health;
            Level = _level;
            Strength = _strength;
            Defense = _defense;
            Mana = _mana;
            Spells = _spells;
        }

        public Player()
        {
            Name = "Link";
            Health = 10;
            Level = 5;
            Strength = 4;
            Defense = 2;
            Mana = 10;
            Spells = new List<Spell> { 
                new Spell { Name = "Fire", Description = "A small bright flame", Damage = 6, Cost = 4 },
                new Spell { Name = "Bolt", Description = "A bolt of lightning", Damage = 6, Cost = 4 },
            };
        }

        public void Attack(GameCharacter playerObj, GameCharacter enemyObj, Random rnd)
        {
            base.Attack(playerObj, enemyObj, rnd);
        }

        public void CastSpell(GameCharacter playerObj, GameCharacter enemyObj, Random rnd, Spell spell)
        {
            base.CastSpell(playerObj, enemyObj, rnd, spell);
        }
    }
}
