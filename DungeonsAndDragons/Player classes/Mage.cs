using System;

namespace DungeonsAndDragons
{
    // CREATES A MAGE SUBCLASS
    public class Mage : Player
    {
        public Mage(string aName) : base(aName)
        {
            profession = "mage";
            maxHp = 20;
            hp = maxHp;
            attack = 5;
        }

        public override void AttackSpeechBoss(Boss boss, Player player, int scenario)
        {
            switch (scenario)
            {
                case 1:
                    Console.Write("You throw fireballs at the " + boss.MonsterName + "! ");
                    break;

                case 2:
                    Console.WriteLine("You throw fireballs but the " + boss.MonsterName + " deflects them! You take 2HP damage in recoil. (You have " + player.hp + "HP left)");
                    break;

                case 3:
                    Console.WriteLine("You throw fireballs but the " + boss.MonsterName + " avoids them!");
                    break;
            }
        }

        public override void AttackSpeechEnemy(Enemy enemy, int scenario)
        {
            switch (scenario)
            {
                case 1:
                    Console.Write("You throw fireballs at the " + enemy.MonsterName + "! ");
                    break;

                case 2:
                    Console.WriteLine("You throw fireballs but the " + enemy.MonsterName + " avoids them!");
                    break;
            }
        }
    }
}
