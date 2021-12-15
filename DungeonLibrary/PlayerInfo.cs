using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class PlayerInfo : Character
    {
        public Race PlayerRace { get; set; }
        public Weapon OnHandWeapon { get; set; }

        public PlayerInfo(string name, int hitChance, int armor, int life,
            int maxLife, Race playerRace, Weapon onHandWeapon)
        {
            MaxLife = maxLife;
            Life = life;
            Name = name;
            HitChance = hitChance;
            Armor = armor;
            OnHandWeapon = onHandWeapon;
            PlayerRace = playerRace;
            

            switch(PlayerRace)
            {
                case Race.Human:
                    MaxLife += 5;
                    Life += 5;
                    HitChance += 5;
                    Armor += 5;
                    break;

                case Race.Dwarf:
                    MaxLife += 15;
                    Life += 15;
                    Armor += 5;
                    break;

                case Race.Orc:
                    Armor += 10;
                    HitChance += 5;
                    MaxLife += 10;
                    Life += 10;
                    break;

                case Race.Elf:
                    HitChance += 15;
                    MaxLife += 5;
                    Life += 5;
                    break;
            }           
        }//end FQ CTOR

        public override string ToString()
        {
            string description = "";
        
            switch(PlayerRace)
            {
                case Race.Human:
                    description = "A basic human! Good at a little of everything!";
                    break;

                case Race.Dwarf:
                    description = "The dwarf! A sturdy fighter with better Defences than most.";
                    break;

                case Race.Orc:
                    description = "The mighty Orc! Built for battle and battlefield Domination!";
                    break;

                case Race.Elf:
                    description = "A Wood Elf with sharp eyes, allowing for critical hits.";
                    break;

                case Race.Gnome:
                    description = "Nobody likes a gnomie";
                    break;

            }//end swtich

            return $"===============\n" +
                     $"Name: {Name}\n" +
                   $"Max Life: {MaxLife} --- Remaining Life: {Life}\n" +
                   $"Armor: {Armor} \n"+
                   $"Weapon: {OnHandWeapon}\n" +
                   $"Description: {description}";
        }//end CTOR

        public override int CalcDamage()
        {
            Random r = new Random();

            int damage = r.Next(OnHandWeapon.MinDamage, OnHandWeapon.MaxDamage + 1);
            return damage;
        }// end CalcDamage

        public override int CalcHitChance()
        {
            return base.CalcHitChance();
        }

        public override int CalcArmor()
        {
            return base.CalcArmor();
        }
    }//end class
}//end namespace
