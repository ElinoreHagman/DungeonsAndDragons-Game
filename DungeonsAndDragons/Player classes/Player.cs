using System;

namespace DungeonsAndDragons
{
    public class Player
    {
        protected string playerName;
        protected string profession;
        protected int attack;
        private int level = 1;
        protected int maxHp;
        public int hp;
        public int monstersKilled;
        public int totalMonstersKilled;
        public bool isDead;
        public int goldCoins;

        public Player(string aName)
        {
            PlayerName = aName;
        }

        public string PlayerName
        {
            get { return playerName; }
            set {
                if (value.Length == 0) {
                    playerName = "Anonymous";
                } else {
                    playerName = "Hero " + value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
                }
            }
        }

        public int Attack {
            get { return attack; }
            set
            {
                if (value > 0) {
                    attack = value;
                } else {
                    attack = 1;
                }
            }
        }

        public string Profession
        {
            get { return profession.Substring(0).ToLower(); }
        }

        public int MaxHp
        {
            get { return maxHp; }
        }

        #region Player checking methods
        // RUNS AFTER EVERY BATTLE
        public void CheckIfChangeLevel()
        {
            if (monstersKilled == 2)
            {
                level++;
                totalMonstersKilled += monstersKilled;
                monstersKilled = 0;
                Console.WriteLine("You leveled up! You are now level " + level + ".");
                Console.WriteLine("Your MAX HP goes up by 2 and your attack by 2. Your HP is also restored.");
                maxHp += 2;
                attack += 2;
                hp = maxHp;
            }
        }

        // RUNS WHEN DAMAGE IS TAKEN FROM MONSTER FROM MULTIPLE OTHER METHODS
        public void ChangeHp(int damageTaken)
        {
            hp -= damageTaken;
            Console.Write("You take " + damageTaken + "HP in damage. ");
            if (hp > 0)
            {
                Console.WriteLine("You now have " + hp + "HP left.");
            }
            CheckIfDead();
        }

        // RUNS EVERY TIME THE PLAYER IS HURT
        public void CheckIfDead()
        {
            if (hp < 1)
            {
                isDead = true;
                Console.WriteLine("* YOU DIED *");
                Console.WriteLine("-*-*- GAME OVER -*-*-");
                Environment.Exit(0);
            }
        }
        #endregion

        #region Player combat methods
        // RUNS IF PLAYER CHOOSES TO ATTACK MONSTER
        public virtual void AttackMonster(Player player, Enemy enemy)
        {
            int winOrFail = RandomNumber(1, 4);
            int scenario;

            if (winOrFail < 3)
            {
                scenario = 1;
                AttackSpeechEnemy(enemy, scenario);
                enemy.ChangeEnemyHp(player.attack);
                enemy.CheckIfDead(player);

            } else {
                scenario = 2;
                AttackSpeechEnemy(enemy, scenario);
            }
        }

        // RUNS IF PLAYER CHOOSES TO DEFEND AGAINST MONSTER
        public void DefendAgainstMonster(Player player, Enemy enemy)
        {
            int winOrFail = RandomNumber(1, 3);
            if (winOrFail == 1)
            {
                // CHECKS IF MAXHP IS REACHED AND IN THAT CASE AVOIDS REGISTRATION OF HIGHER HP
                int howMuchHp = RandomNumber(4, 10);
                if ( (howMuchHp + hp) > maxHp) {
                    hp = maxHp;
                    int hpLeft = (howMuchHp + hp) - maxHp;
                    Console.WriteLine("The " + enemy.MonsterName + " attacks you! But you block and regain " + hpLeft + "HP. (You are at full health)");

                } else {
                    hp += howMuchHp;
                    Console.WriteLine("The " + enemy.MonsterName + " attacks you! But you block and regain " + howMuchHp + "HP. (You have " + player.hp + "HP left)");
                }

            } else {
                Console.WriteLine("The " + enemy.MonsterName + " attacks and does half damage because you flinched!");
                player.ChangeHp(enemy.AttackDamage / 2);
                player.CheckIfDead();
            }
        }

        // RUNS IF PLAYER CHOOSES TO ATTACK BOSS
        public void AttackBoss(Player player, Boss boss)
        {
            int winOrFail = RandomNumber(1, 5);
            int scenario;

            if (winOrFail < 3)
            {
                scenario = 1;
                AttackSpeechBoss(boss, player, scenario);
                boss.ChangeEnemyHp(player.attack);
                boss.CheckIfDead(player);

            } else if (winOrFail == 3) {
                scenario = 2;
                AttackSpeechBoss(boss, player, scenario);
                player.hp -= 2;
                player.CheckIfDead();

            } else {
                scenario = 3;
                AttackSpeechBoss(boss, player, scenario);
            }
        }

        // RUNS IF PLAYER CHOOSES TO DEFEND AGAINST BOSS
        public void DefendAgainstBoss(Player player, Boss boss)
        {
            int winOrFail = RandomNumber(1, 4);
            if (winOrFail < 3)
            {
                // CHECKS IF MAXHP IS REACHED AND IN THAT CASE AVOIDS REGISTRATION OF HIGHER HP
                int howMuchHp = RandomNumber(6, 12);
                if ((howMuchHp + hp) > maxHp)
                {
                    hp = maxHp;
                    int hpLeft = (howMuchHp + hp) - maxHp;
                    Console.WriteLine("The " + boss.MonsterName + " attacks you! But you block and regain " + hpLeft + "HP. (You are at full health)");

                } else {
                    hp += howMuchHp;
                    Console.WriteLine("The " + boss.MonsterName + " attacks you! But you block and regain " + howMuchHp + "HP. (You have " + player.hp + "HP left)");
                }

            } else {
                Console.WriteLine("The " + boss.MonsterName + " attacks and does half damage because you flinched!");
                player.ChangeHp(boss.AttackDamage / 2);
                player.CheckIfDead();
            }
        }
        #endregion

        #region Player speech in combat
        public virtual void AttackSpeechBoss(Boss boss, Player player, int scenario)
        {
            switch (scenario)
            {
                case 1: Console.Write("You attack! ");
                    break;

                case 2: Console.WriteLine("You attack but the " + boss.MonsterName + " blocks! You take 2HP damage in recoil. (You have " + player.hp + "HP left)");
                    break;

                case 3: Console.WriteLine("You attack but the " + boss.MonsterName + " blocks!");
                    break;
            }
        }

        public virtual void AttackSpeechEnemy(Enemy enemy, int scenario)
        {
            switch (scenario)
            {
                case 1:
                    Console.Write("You attack! ");
                    break;

                case 2:
                    Console.WriteLine("You attack but the " + enemy.MonsterName + " blocks!");
                    break;
            }
        }
        #endregion

        // CREATES A RANDOMIZER AND GIVES A RANDOM NUMBER TO USE
        public int RandomNumber(int startNumber, int endNumber)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(startNumber, endNumber);
            return randomNumber;
        }
    }
}
