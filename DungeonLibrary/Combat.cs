using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //frugal / fields

        //people / properties

        //collect / constructors (ctors)

        //money / methods
        public static void LetsAttack(Character attacker, Character defender)
        {
            int diceRoll = new Random().Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= (attacker.CalcHitChance()- defender.CalcArmor()))
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
            }//end if
            else
            {
                Console.WriteLine($"{attacker.Name} didn't breach the Armor!");
            }//end else
        }//end LetsAttack

        public static void LetsBattle (PlayerInfo player, Monster monster)
        {
            LetsAttack(player, monster);
            if (monster.Life > 0)
            {
                LetsAttack(monster, player);
            }
        }

    }//end class
}//end namespace
