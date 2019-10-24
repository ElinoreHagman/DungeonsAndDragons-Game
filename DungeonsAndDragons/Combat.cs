using System;
namespace DungeonsAndDragons
{
    public class Combat
    {
        // CREATES A NEW BATTLE WITH A NEW MONSTER
        public void GoInCombat(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Enemy enemy = new Enemy();
            Console.WriteLine("You encounter a " + enemy.MonsterName + "!");
            SystemWait();
            do
            {
                // CHECKS IF THE MONSTER GETS TO START THE TURN
                int enemyStart = RandomNumber(1, 4);
                if (enemyStart == 1)
                {
                    Console.WriteLine("");
                    player.hp -= enemy.AttackDamage;
                    Console.WriteLine(enemy.MonsterName + " attacks and does " + enemy.AttackDamage + "HP damage! (You have " + player.hp + "HP left)");
                    player.CheckIfDead();
                }

                // GIVES THE PLAYER THE OPTIONS TO ATTACK OR DEFEND THE MONSTER
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nDo you ATTACK or DEFEND? ");
                string action = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Gray;
                while (action != "DEFEND" && action != "ATTACK")
                {
                    Console.Write("You can only ATTACK or DEFEND. What do you do?: ");
                    action = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                SystemWait();

                if (action == "DEFEND")
                {
                    player.DefendAgainstMonster(player, enemy);
                }

                else if (action == "ATTACK")
                {
                    player.AttackMonster(player, enemy);
                }

            } while (enemy.isDead == false && player.isDead == false);

            // IF ENEMY OR PLAYER DIES THE COMBAT ENDS
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Combat is over.");
            new Treasure().MaybeFindCoins(player);
            player.CheckIfChangeLevel();
            Console.WriteLine("");
        }

        // CREATES A NEW BATTLE WITH A NEW BOSS
        public void GoInCombatwithBoss(Player player)
        {
            Boss boss = new Boss();
            Console.WriteLine("A big " + boss.MonsterName + " looks down on you!");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("'I will not let you kill me, you filthy " + player.Profession + "!' the " + boss.MonsterName + " growls.");
            Console.ForegroundColor = ConsoleColor.Red;

            do
            {
                // CHECKS IF THE MONSTER GETS TO START THE TURN
                int enemyStart = RandomNumber(1, 4);
                if (enemyStart == 1)
                {
                    Console.WriteLine("");
                    player.hp -= boss.AttackDamage;
                    Console.WriteLine(boss.MonsterName + " attacks and does " + boss.AttackDamage + "HP damage! (You have " + player.hp + "HP left)");
                    player.CheckIfDead();
                }

                // GIVES THE PLAYER THE OPTIONS TO ATTACK OR DEFEND THE MONSTER
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nDo you ATTACK or DEFEND? ");
                string action = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;

                Console.ForegroundColor = ConsoleColor.Gray;
                while (action != "DEFEND" && action != "ATTACK")
                {
                    Console.Write("You can only ATTACK or DEFEND. What do you do?: ");
                    action = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                SystemWait();

                if (action == "DEFEND")
                {
                    player.DefendAgainstMonster(player, boss);
                }

                else if (action == "ATTACK")
                {
                    player.AttackMonster(player, boss);
                }

            } while (boss.isDead == false && player.isDead == false);

            // IF ENEMY OR PLAYER DIES THE COMBAT ENDS
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Combat is over.");
            SystemWait();
            new Treasure().MaybeFindCoins(player);
            player.CheckIfChangeLevel();
            Console.WriteLine("");
        }

        // CREATES A RANDOMIZER AND GIVES A RANDOM NUMBER TO USE
        static int RandomNumber(int startNumber, int endNumber)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(startNumber, endNumber);
            return randomNumber;
        }

        public void SystemWait()
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.WriteLine(".");
        }
    }
}
