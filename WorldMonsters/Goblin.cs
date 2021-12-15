using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
namespace WorldMonsters
{
    public class Goblin : Monster
    {
        //frugal / fields

        //people / properties

        //collect / constructors (ctors)
        public Goblin()
        {
            MaxLife = 15;
            MaxDamage = 5;
            Name = "Goblin";
            Life = 15;
            HitChance = 20;
            Armor = 15;
            MinDamage = 1;
            Description = "A tiny green goblin! Not overly dangerous.";
        }

        public Goblin(string name, int life, int maxLife, int hitChance, int armor, int minDamage, int maxDamage, string description)
        : base (name, life, maxLife, hitChance, armor, minDamage, maxDamage, description)
            { }
        //money / methods

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
