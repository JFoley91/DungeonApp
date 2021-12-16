using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMonsters
{
    public class Human : Monster
    {
        public Human()
        {
            MaxLife = 10;
            MaxDamage = 5;
            Name = "Man";
            Life = 10;
            HitChance = 20;
            Armor = 10;
            MinDamage = 1;
            Description = "A normal person, what are you a bully?";
        }

        public Human(string name, int life, int maxLife, int hitChance, int armor, int minDamage, int maxDamage, string description)
        : base(name, life, maxLife, hitChance, armor, minDamage, maxDamage, description) { }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
