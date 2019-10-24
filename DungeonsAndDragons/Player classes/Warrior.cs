using System;

namespace DungeonsAndDragons
{
    // CREATES A WARRIOR SUBCLASS
    public class Warrior : Player
    {
        public Warrior(string aName) : base(aName)
        {
            profession = "warrior";
            maxHp = 17;
            hp = maxHp;
            attack = 8;
        }

        public override void AttackSpeechBoss(Boss boss, Player player, int scenario)
        {
            switch (scenario)
            {
                case 1:
                    Console.Write("You swing your sword at the " + boss.MonsterName + "! ");
                    break;

                case 2:
                    Console.WriteLine("You do a slice attack but the " + boss.MonsterName + " deflects it! You take 2HP damage in recoil. (You have " + player.hp + "HP left)");
                    break;

                case 3:
                    Console.WriteLine("You do a slice attack but the " + boss.MonsterName + " avoids it!");
                    break;
            }
        }

        public override void AttackSpeechEnemy(Enemy enemy, int scenario)
        {
            switch (scenario)
            {
                case 1:
                    Console.Write("You swing your sword at the " + enemy.MonsterName + "! ");
                    break;

                case 2:
                    Console.WriteLine("You do a slice attack but the " + enemy.MonsterName + " jumps aside!");
                    break;
            }
        }
    }
}
