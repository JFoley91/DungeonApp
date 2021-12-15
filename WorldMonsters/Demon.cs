using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMonsters
{
    public class Demon : Monster
    {

        public Demon()
        {
            MaxLife = 5;
            MaxDamage = 5;
            Name = "Imp";
            HitChance = 15;
            Armor = 5;
            MinDamage = 5;
            Description = "A small red Imp. Careful  or it might flee!";
        }

        public Demon(string name, int life, int maxLife, int hitChance, int armor, int minDamage, int maxDamage, string description)
                : base(name, life, maxLife, hitChance, armor, minDamage, maxDamage, description)
        { }



        public override string ToString()
        {
            return base.ToString();
        }
    }
}
