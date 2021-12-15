using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonLibrary
{
    public class Monster : Character
    {
        //frugal / fields
        private int _minDamage;

        //people / properties
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }//end MinDamage

        //collect / constructors (ctors)
        public Monster() { }

        public Monster(string name, int life, int maxLife, int hitChance, int armor,
            int minDamage, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Armor = armor;
            Description = description;
            MinDamage = minDamage;
        }//end CTOR

        //money / methods
        public override string ToString()
        {
            
                return $"------FOE BEFORE YOU------\n" +
                    $"{Name}\n" +
                    $"Life: {Life} of {MaxLife}\n" +
                    $"Armor: {Armor}  Damage: {MinDamage}-{MaxDamage}\n\n" +
                    $"Info: {Description}\n";



            
        } //end ToString

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }//end CalcDamage

    }//end class
}//end name space
