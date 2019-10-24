using System;
using System.Collections.Generic;
using System.IO;

namespace DungeonsAndDragons
{
    class Program
    {
        static bool hasOtherRoadBeenTaken;

        static void Main(string[] args)
        {
            WriteOutArt();

            // INTRODUCTION
            Console.WriteLine("DUNGEON CRAWLER GAME\n");
            DateTime start = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("In this game your input needs to be written out in CAPTITAL LETTERS.");
            Console.Write("What is your name?: ");
            string inputName = Console.ReadLine();

            // HERE IS THE ONLY PLACE ONE NEEDS TO WRITE NEW CODE IF A NEW CLASS IS IMPLEMENTED IN THE PROGRAM
            // (EXCLUDING MAKING A NEW SUBCLASS FOR IT, AND IF ONE WANTS PERSONALZED TEXT DO THAT AS WELL IN THE SUBCLASS)
            SortedList<string, Player> professions = new SortedList<string, Player>();
            professions.Add("MAGE", new Mage(inputName));
            professions.Add("WARRIOR", new Warrior(inputName));
            professions.Add("RANGER", new Ranger(inputName));

            Console.Write("Are you a ");
            int amountOfProfs = -1;
            List<string> allProfessions = new List<string>();
            foreach (var p in professions) {
                allProfessions.Add(p.Key);
                amountOfProfs++;
            }
            for (int i = 0; i < allProfessions.Count -1; i++) {
                Console.Write(allProfessions[i] + ", ");
            }
            Console.Write("or " + allProfessions[amountOfProfs]);
            Console.Write(": ");

            string inputProfession = Console.ReadLine();
            while (!professions.ContainsKey(inputProfession))
            {
                Console.Write("You can't be that, choose from what's avaliable: ");
                inputProfession = Console.ReadLine();
            }

            professions.TryGetValue(inputProfession, out Player value);
            Player player1 = value;

            Console.WriteLine("Welcome to your first adventure " + player1.PlayerName + "! You are a " + player1.Profession + " that lives in the land of Åland!");
            Console.WriteLine("You start at level 1 with " + player1.hp + "HP, and you currently deal " + player1.Attack + " damage.");
            Console.WriteLine("The castle is in danger, let's get started!");
            PressToContinue();

            // START STORY
            Console.WriteLine("********* THE JOURNEY BEGINS **********\n");
            Console.WriteLine("You walk along the small dirt road in the forest. You hear something in the bushes.. ");

            new Combat().GoInCombat(player1);

            // FOREST SCENARIO WITH EITHER FIGHT OR EXIT FOREST
            Console.WriteLine("After taking a deep breath you continue on your road towards the castle.");
            Console.WriteLine("You get to a crossroad and you can't remember which way you're supposed to take.");
            Console.WriteLine("Do you go to LEFT, where the forest gets a bit darker, or RIGHT, where you at least can hear some birds chirp?");
            string path = Console.ReadLine();

            while (path != "RIGHT" && path != "LEFT")
            {
                Console.Write("You can only go RIGHT or LEFT. Which way do you choose?: ");
                path = Console.ReadLine();
            }

            while (path == "LEFT")
            {
                PathChosen(path);
                new Combat().GoInCombat(player1);
                Console.WriteLine("You see that the road doesn't go any further and turn around and go back to the crossroad.");
                Console.WriteLine("You go to the right this time.");
                path = "RIGHT";
                PressToContinue();
                hasOtherRoadBeenTaken = true;
            }

            // FARM SCENARIO WITH EITHER VISITING OR CONTINUING ON ROAD AND FIGHT
            PathChosen(path);
            Console.WriteLine("After walking for a while you see the sky a bit more above the trees, and soon you get out of the forest.");
            Console.WriteLine("You get to a little farm and wonders if the people living there are nice. Do you KNOCK on the door, or WALK past it?");
            path = Console.ReadLine();

            while (path != "KNOCK" && path != "WALK")
            {
                Console.Write("You can only KNOCK on door or WALK past the house. What do you choose?: ");
                path = Console.ReadLine();
            }

            while (path == "KNOCK")
            {
                PathChosen(path);
                Console.Write("You knock on the door and two old farmers open the door.");
                Console.WriteLine("They offer you a gift for you to bring on your journey.");
                new Treasure().FindTreasure(player1);
                Console.WriteLine("You thank them and go out to continue on the road towards the castle.");
                path = "WALK";
                PressToContinue();
                hasOtherRoadBeenTaken = true;
            }

            PathChosen(path);
            Console.Write("While walking on the road you hear someone screaming behind you.");
            Console.WriteLine("The little farm is burning and a monster is approaching you!");
            new Combat().GoInCombat(player1);

            // CASTLE TOWN SCENARIO WITH EITHER GOING THROUGH TOWN OR THROUGH SEWERS
            Console.WriteLine("You mourn for the farm people and wonder why there are so many monsters nearby.");
            Console.WriteLine("You pick up the pace and soon you get near the castle town.");
            Console.WriteLine("From where you are the town seems lively and ordinary, but you are unsure how you should approach.");
            Console.WriteLine("Do you go through the castle town SEWERS or through the TOWN in hope of finding some potions or weapons?");
            path = Console.ReadLine();

            while (path != "TOWN" && path != "SEWERS")
            {
                Console.Write("You can only go through the TOWN or go through the SEWERS. What do you choose?: ");
                path = Console.ReadLine();
            }

            while (path == "TOWN")
            {
                PathChosen(path);
                Console.WriteLine("You slowly approach the town and sees it being overrun by monsters!");
                Console.WriteLine("You try to turn around and leave the town.");
                new Combat().GoInCombat(player1);
                Console.WriteLine("You run out through the town gates and decide that the sewers probably is the best chance now.");
                path = "WALK";
                hasOtherRoadBeenTaken = true;
                PressToContinue();
            }

            PathChosen(path);
            Console.WriteLine("While walking through the sewers you see something floating in the murky waters.");
            new Treasure().FindTreasure(player1);
            Console.WriteLine("You feel confident and walk through the sewers without any problems.");

            // CASTLE GROUND SCNEARIO WITH EITHER GOING UP THE RIGHT TOWER STAIRS OR THE LEFT TOWER STAIRS
            Console.WriteLine("When you come out of the sewers you notice that you're inside the castle grounds.");
            Console.WriteLine("No monsters are nearby. You walk past a burnt down patio and ash is covering the ground and air.");
            Console.WriteLine("You hear a loud scream from the top of the castle.");
            Console.Write("Do you take the RIGHT tower stairs or the LEFT tower stairs?: ");
            path = Console.ReadLine();

            while (path != "RIGHT" && path != "LEFT")
            {
                Console.Write("You can only go RIGHT or LEFT. What do you choose?: ");
                path = Console.ReadLine();
            }

            while (path == "RIGHT")
            {
                PathChosen(path);
                Console.WriteLine("You find a corpse that has been burnt to ashes, and find something behind it.");
                new Treasure().FindTreasure(player1);
                Console.WriteLine("You continue up the stairs and you prepare yourself mentally for what's to come.");
                path = "LEFT";
                PressToContinue();
                hasOtherRoadBeenTaken = true;
            }

            // BOSS SCENARIO
            PathChosen(path);
            Console.WriteLine("You're climbing the stairs, and the screams from the top of the castle gets louder.");
            Console.WriteLine("When getting to the top, you take a deep breath and run out of the tower door.");
            new Combat().GoInCombatwithBoss(player1);

            //ENDING
            Console.WriteLine("Congratulations " + player1.PlayerName + "!");
            Console.WriteLine("You slayed the monster that has been terrorizing the land of Åland!");
            Console.WriteLine("But you know that this is just the beginning, and you need to slay the other two giants.");
            Console.WriteLine("After taking a short rest, you look at the horizon from the castle tower you're standing on.");
            Console.WriteLine("-*-* TO BE CONTINUED *-*-");
            DateTime end = DateTime.Now;

            PressToContinue();
            TimeSpan varTime = end - start;
            int minutesRounded = (int)Math.Round(varTime.TotalMinutes);
            Console.WriteLine("Stats for this playthrough:");
            Console.WriteLine("You played as a " + player1.Profession + " named " + player1.PlayerName);
            Console.WriteLine("You killed " + player1.totalMonstersKilled + " monsters");
            Console.WriteLine("You collected " + player1.goldCoins + "G");
            Console.WriteLine("Time played: " + minutesRounded + " minutes");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-*- OTHER PLAYTHROUGHS -*-");

            string filePath = @"playerInfo.txt";

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(player1.PlayerName + ", class: " + player1.Profession);
                sw.WriteLine(player1.goldCoins + "G collected, and " + player1.totalMonstersKilled + " monsters killed");
                sw.WriteLine("Played: " + start);
                sw.WriteLine("");
                sw.Flush();
                sw.Close();
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                string infoLine;
                do {
                    infoLine = sr.ReadLine();
                    Console.WriteLine(infoLine);
                } while (infoLine != null);
            }
            Console.ResetColor();
            Console.ReadKey();
        }

        static void PressToContinue()
        {
            Console.WriteLine("\n* press any key to continue.. *\n");
            Console.ReadKey();
            Console.ResetColor();
        }

        static void PathChosen(string path)
        {
            if (hasOtherRoadBeenTaken == false) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("--- YOU CHOSE " + path + " ---");
                Console.ResetColor();

            } else {
                hasOtherRoadBeenTaken = false;
            }
        }

        static void WriteOutArt()
        {
            var art = new[] {
@"                                   |>>>                                         ",
@"                                   |                                            ",
@"                     |>>>      _  _|_  _         |>>>                           ",
@"                     |        |;| |;| |;|        |                              ",
@"                 _  _|_  _    \\.    .  /    _  _|_  _                          ",
@"                |;|_|;|_|;|    \\:. ,  /    |;|_|;|_|;|                         ",
@"                \\..      /    ||;   . |    \\.    .  /                         ",
@"                 \\.  ,  /     ||:  .  |     \\:  .  /                          ",
@"                  ||:   |_   _ ||_ . _ | _   _||:   |                           ",
@"                  ||:  .|||_|;|_|;|_|;|_|;|_|;||:.  |                           ",
@"                  ||:   ||.    .     .      . ||:  .|                           ",
@"                  ||: . || .     . .   .  ,   ||:   |       \,/                 ",
@"                  ||:   ||:  ,  _______   .   ||: , |            /`\            ",
@"                  ||:   || .   /+++++++\    . ||:   |                           ",
@"                  ||:   ||.    |+++++++| .    ||: . |                           ",
@"               __ ||: . ||: ,  |+++++++|.  . _||_   |                           ",
@"      ____--`~    '--~~__|.    |+++++__|----~    ~`---,              ___        ",
@"- ~--~                   ~---__|,--~'                  ~~----_____-~'   `~----~~",
};

            foreach (string line in art)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("");
        }
    }
}
