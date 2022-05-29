using System;
using System.Collections.Generic;

namespace TurnBasedRPGBattle
{
    class Player : GameCharacter
    {

        public List<Item> Items { get; set; }

        public bool PlayerTurn { get; set; }

        public Player(string _name, int _health, int _level, int _strength, int _defense, int _mana, List<Spell> _spells, List<Item> _items) : base(_name, _health, _level, _strength, _defense, _mana, _spells)
        {
            Name = _name;
            Health = _health;
            Level = _level;
            Strength = _strength;
            Defense = _defense;
            Mana = _mana;
            Spells = _spells;
            Items = _items;
            PlayerTurn = false;
        }

        public Player()
        {
            Name = "Link";
            Health = 10;
            MaxHealth = 10;
            Level = 5;
            Strength = 4;
            Defense = 2;
            Mana = 10;
            MaxMana = 10;
            PlayerTurn = false;
            Spells = new List<Spell>
            {
                new Spell { Name = "Fire", Description = "A small bright flame", Damage = 6, Cost = 4 },
                new Spell { Name = "Bolt", Description = "A bolt of lightning", Damage = 6, Cost = 4 },
            };
            Items = new List<Item>
            {
                new Item {Name = "Potion", Classification = "Aid", Type = "Potion", Description = "A basic potion", HealFor = "Health", ReplenishPoints = 5, Quantity = 2 },
                new Item {Name = "Elixir", Classification = "Aid", Type = "Elixir", Description = "A basic elixir", HealFor = "Mana", ReplenishPoints = 5, Quantity = 1 },
                new Item {Name = "Great Potion", Classification = "Aid", Type = "Potion", Description = "A strong potion", HealFor = "Health", ReplenishPoints = 10, Quantity = 2 },
                new Item {Name = "Fishing Rod", Classification = "Key-Item", Type = "Key", Description = "An old sturdy rod", HealFor = null, ReplenishPoints = null, Quantity = 1}
            };
        }

        public void Attack(Player playerObj, GameCharacter enemyObj, Random rnd)
        {
            base.Attack(playerObj, enemyObj, rnd);
            playerObj.PlayerTurn = false;
        }

        public void CastSpell(Player playerObj, GameCharacter enemyObj, Random rnd, Spell spell)
        {
            base.CastSpell(playerObj, enemyObj, rnd, spell);
            playerObj.PlayerTurn = false;
        }

        public void CheckStats(GameCharacter playerObj, GameCharacter enemyObj)
        {
            base.CheckStats(playerObj, enemyObj);
        }

        public void UseItem(Player player, Item item)
        {

            switch (item.HealFor)
            {
                case "Health":
                    if (player.Health < player.MaxHealth)
                    {
                        item.Quantity -= 1;
                        Console.WriteLine($"{player.Name} uses a {item.Name}.");
                        player.Health = Math.Min(player.MaxHealth, player.Health + (int)item.ReplenishPoints);
                        player.PlayerTurn = false;
                    }
                    break;
                case "Mana":
                    if (player.Mana < player.MaxMana)
                    {
                        item.Quantity -= 1;
                        Console.WriteLine($"{player.Name} uses a {item.Name}.");
                        player.Mana = Math.Min(player.MaxMana, player.Mana = (int)item.ReplenishPoints);
                        player.PlayerTurn = false;
                    }
                    break;
                case "Status":
                    break;
                default:
                    break;
            }

            if (item.Quantity == 0)
            {
                player.Items.Remove(item);
            }
            Console.WriteLine(" ");
        }
    }
}
