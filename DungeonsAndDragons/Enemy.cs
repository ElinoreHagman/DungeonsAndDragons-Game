using System;

namespace DungeonsAndDragons
{
    public class Enemy
    {
        protected string monsterName;
        protected int attackDamage;
        protected int monsterHp;
        public bool isDead;

        public Enemy()
        {
            // CHOOSES A RANDOM MONSTER NAME AND GIVES IT RANDOM HP AND ATTACK
            string[] monsterNames = { "Goblin", "Dark orc", "Slime", "Troll", "Evil wizard", "Skeleton" };
            string chosenMonsterName = monsterNames[RandomNumber(0, 6)];
            int randomHp = RandomNumber(8, 14);
            int randomDamage = RandomNumber(2, 5);

            monsterName = chosenMonsterName;
            monsterHp = randomHp;
            attackDamage = randomDamage;
        }

        public string MonsterName {
            get { return monsterName; }
        }

        public int AttackDamage
        {
            get { return attackDamage; }
        }

        // RUNS WHEN THE ENEMY ATTACKS THE PLAYER
        public void EnemyAttack(Player player)
        {
            player.ChangeHp(attackDamage);
        }

        // CHECKS IF THE MONSTER IS DEAD
        public virtual void CheckIfDead(Player player)
        {
            if (monsterHp < 1)
            {
                Console.WriteLine("* THE " + monsterName.ToUpper() + " DIES *");
                player.monstersKilled++;
                isDead = true;
            }
        }

        // RUNS WHEN THE PLAYER HURTS THE MONSTER
        public void ChangeEnemyHp(int damageTaken)
        {
            monsterHp -= damageTaken;
            Console.WriteLine("The " + monsterName + " takes " + damageTaken + "HP in damage.");
        }

        // CREATES A RANDOMIZER AND GIVES A RANDOM NUMBER TO USE
        public int RandomNumber(int startNumber, int endNumber)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(startNumber, endNumber);
            return randomNumber;
        }
    }

    // CREATES A BOSS SUBCLASS
    public class Boss : Enemy
    {
        public Boss()
        {
            string[] bossNames = { "Dragon", "Skeleton King", "Demon beast" };

            string chosenBossName = bossNames[RandomNumber(0, 3)];
            int randomHp = RandomNumber(17, 24);
            int randomDamage = RandomNumber(6, 9);

            monsterName = chosenBossName;
            monsterHp = randomHp;
            attackDamage = randomDamage;
        }

        // CHECKS IF THE BOSS IS DEAD
        public override void CheckIfDead(Player player)
        {
            if (monsterHp < 1)
            {
                Console.WriteLine("* THE " + monsterName.ToUpper() + " SCREAMS IN AGONY AND TURNS INTO ASHES *");
                player.totalMonstersKilled++;
                isDead = true;
            }
        }
    }
}