using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using WorldMonsters;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.Title = "[]++++||=======> Teleport Madness <=======||++++[]";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the portal room! Before we let you go we need you to answer a question.....");
            Console.WriteLine(@"What is your race? 
1) Human
2) Dwarf
3) Orc
4) Elf");

            int score = 0;
            int raceInt = 0;
            bool playerChoice = int.TryParse(Console.ReadLine(), out raceInt);

            Race playerRace;

            if (playerChoice && raceInt > 0 && raceInt < 5)
            {
                playerRace = (Race)(raceInt - 1);
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
                playerRace = Race.Gnome;
            }

            Console.WriteLine($"You are now a {playerRace}\n");
            Console.WriteLine("Now what is your name?");
            string playerName = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine($"\n{playerName} is it? A Fine name indeed!\n");
            Console.Write("Takes these runes to teleportation to begin your quest. It should be but a simple few teleports to" +
                "reach the few locations we need to map out, Good luck!\n");

            Weapon bronzeScimitar = new Weapon(1, 6, "Bronze Scimitar");
            Weapon steelScimitar = new Weapon(1, 8, "Steel Scimitar");
            Weapon mithrilScimitar = new Weapon(1, 10, "Mithril Scimitar");
            Weapon runeScimitar = new Weapon(1, 12, "Rune Scimitar");
            Weapon dragonScimitar = new Weapon(1, 15, "Dragon Scimitar");

            PlayerInfo player = new PlayerInfo(playerName, 50, 10, 30, 30, playerRace, bronzeScimitar);

            Goblin g1 = new Goblin();
            Goblin g2 = new Goblin("HobGoblin", 25, 25, 35, 20, 1, 7, "A bigger and badder goblin!");
            Goblin g3 = new Goblin("Goblin", 15, 15, 25, 15, 1, 6, "A Goblin with a spear! Slightly more deadly...");

            Demon d1 = new Demon();
            Demon d2 = new Demon("Lesser Demon", 40, 40, 45, 30, 1, 12, "Not the worse bust certainly not the best demon to encounter...");
            Demon d3 = new Demon("Greater Demon", 60, 60, 55, 40, 1, 15, "A Powerful Demon with wings, might be best to run...");

            Human h1 = new Human();
            Human h2 = new Human("Barbarian", 20, 20, 30, 20, 1, 8, "A Raging Barbarian");

            bool exit = false;
            do
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkBlue;



                Console.WriteLine(TeleportLocations());
                Console.ResetColor();


                Monster[] monsters = { g1, g2, g1, g2, g1, g3, g2, d2, d1, d1, d1, d1, d3, h1, h1, h1, h2 };

                int randomIndex = new Random().Next(monsters.Length);
                Monster monster = monsters[randomIndex];

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nThe creature that attacked is a " + monster.Name);
                Console.ResetColor();

                bool menu = false;
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(@"
=========================
|                       |
| A) Attack             |          
| S) Stats              |
| M) Monster            |
| T) Teleport           |   
| X) Exit               |
=========================");
                    Console.ResetColor();
                    string userInput = Console.ReadKey(true).Key.ToString();

                    Console.Clear();

                    switch (userInput)
                    {
                        case "A":
                            Combat.LetsAttack(player, monster);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The {0} is dead!\n", monster.Name);
                                Console.ResetColor();
                                menu = true;
                                score++;

                            }//end IF
                            Combat.LetsAttack(monster, player);
                            break;

                        case "S":
                            Console.WriteLine("Your Stat Page:");
                            Console.WriteLine(player);
                            Console.WriteLine("\nCurrent Score: " + score);
                            break;

                        case "M":
                            Console.WriteLine("Monster Stat Page:");
                            Console.WriteLine(monster);
                            break;

                        case "T":
                            Console.WriteLine("You cast Teleport to try again but get attacked in the process!");
                            Console.WriteLine($"{monster.Name} attacks as you ready the runes!");
                            Combat.LetsAttack(monster, player);
                            Console.WriteLine();
                            menu = true;
                            break;

                        case "X":
                        case "E":
                            Console.WriteLine($"Thanks for Player {player.Name}! Until next time");
                            exit = true;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Please enter a valid command");
                            Console.ResetColor();
                            break;
                    }//end switch (userInput)

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Well we lost another one....OH WELL! We can always find new adventures!");
                        exit = true;
                    }



                } while (!menu && !exit);//end inner/Menu Do

            } while (!exit);//End Do

            Console.WriteLine($"Final Score: {score:n0}");


        }//end SVM



        private static string TeleportLocations()
        {
            string[] locations =
            {
                "You cast teleport but something goes wrong...You appear in the middle of a dense jungle. The air sharpwith the smell of the salty sense of the nearby ocean. Vines grow rampent across the ground, leaving onlya roughly treked pathway that runs from East to West. A number of thick bushes are scattered about, somegiving off the sounds of russleing. Suddenly something jumps out at you!",

                "You cast teleport but something goes wrong...A sudden heat overtakes you as your vision unblurrs. You havebeen transported to the inside of the Karamja Volcano Cave network. Large Bats and a few spiders are all yousee roaming freely within the large room you find yourself in. The sound of screeching mixed with the bubblingsounds of the magma residing in a large pool just to your left. A large cave entrance rests to your right sideas the large room seems to contiune on for a good while.Suddenly a beast comes out of the cave entrance!",


                "You cast teleport but something goes wrong... As your vision of the land slowly reforms you feel a chill inthe air. At a brief glance you can tell you have ended up in the Deep Wilderness! The ground is littered withcharred bones and random bits of rusted gear, the air filled with the smell of decaying flesh. A suddenly chillruns up your spine as you turn around to see a beast behind you!",


                "You cast teleport but something goes wrong... You have arrived in the starter area of Lumbridge! Nothing outof the ordinary here! Except for the creature that now stands before you!",

                "You cast teleport but something goes wrong...The air reeks of sewage as you appear in the Varrock Sewers!The area looks fimiliar to you as the spot you are standing in normally is filled with Moss Giants... Howeverthey all seem to be missing. In there place you spot a different creature that appears to become hostile as itnotices your arrival!",

                "You cast teleport but something goes wrong...The roar of a crowd fills your ears as the magic particales clear.Warmth from the sun hits your face as your eyes adjust to the bright light as you find yourself in the Fight Arena!A large gate suddenly begins to creek open before you as eyes glow from the darkness behind it...Suddenly a creature rushes out at you!",

                "You cast teleport but something goes wrong...You arrived in the Void! Prepare for a fight!",

                "You cast teleport but something goes wrong...The crisp smell of salt and ash fill the air as you find yourself onthe shores of Relleka! Just to the east you see the wooden barricades that make up the town walls, so you aren'tto far from civilization! However something to the northwest catches your eye, a cart that looks to be broken downwith a few crates lying around. You go to investiage when a monster suddenly walks around from the other side ofthe cart and attacks!"
            };//end location TODO: Add more Locations
            return locations[new Random().Next(locations.Length)];
        }


    }//end class
}//end namespace
