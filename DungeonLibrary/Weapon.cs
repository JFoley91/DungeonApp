using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Name { get; set; }
        //public bool IsUpgradeable { get; set; }
        //public int CounterDamage { get; set; }

        

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
            }//end Set
        }//end MinDamage

        public Weapon (int minDamage, int maxDamage, string name)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
        }//end FQ Ctor

        public override string ToString()
        {
            return $"{Name}\t {MinDamage} - {MaxDamage} Damage\n";
        }//end ToString
    }//end class
}//end namespace
