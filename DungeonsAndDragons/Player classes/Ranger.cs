using System;

namespace DungeonsAndDragons
{
    // CREATES A MAGE SUBCLASS
    public class Ranger : Player
    {
        public Ranger(string aName) : base(aName)
        {
            profession = "ranger";
            maxHp = 26;
            hp = maxHp;
            attack = 3;
        }

        public override void AttackSpeechBoss(Boss boss, Player player, int scenario)
        {
            switch (scenario)
            {
                case 1:
                    Console.Write("You shoot an arrow at " + boss.MonsterName + "! ");
                    break;

                case 2:
                    Console.WriteLine("You shoot an arrow but " + boss.MonsterName + " deflects it! You take 2HP damage in recoil. (You have " + player.hp + "HP left)");
                    break;

                case 3:
                    Console.WriteLine("You shoot an arrow but the " + boss.MonsterName + " avoids them!");
                    break;
            }
        }

        public override void AttackSpeechEnemy(Enemy enemy, int scenario)
        {
            switch (scenario)
            {
                case 1:
                    Console.Write("You shoot an arrow at " + enemy.MonsterName + "! ");
                    break;

                case 2:
                    Console.WriteLine("You shoot an arrow but the " + enemy.MonsterName + " avoids them!");
                    break;
            }
        }
    }
}
