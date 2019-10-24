using System;
namespace DungeonsAndDragons
{
    public class Treasure
    {
        public void FindTreasure(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int randomTreasure = RandomNumber(1, 4);

            // CHOOSES WHAT TREASURE THE PLAYER GETS, THROUGH A RANDOMIZER 
            switch (randomTreasure)
            {
                case 1:
                    Console.WriteLine("You get a potion and heal yourself to full health!");
                    player.hp = player.MaxHp;
                    break;

                case 2:
                    switch (player.Profession)
                    {
                        case "mage":
                            Console.WriteLine("You get a new spellbook that makes your spells do 1+ in damage!");
                            break;

                        case "warrior":
                            Console.WriteLine("You get a one-time wetstone that gives your sword 1+ in damage!");
                            break;

                        case "ranger":
                            Console.WriteLine("You get some magic infused arrows that do 1+ in damage!");
                            break;

                        default:
                            Console.WriteLine("You get a new weapon with 1+ in damage!");
                            break;
                    }
                    player.Attack += 1;
                    break;

                case 3:
                    Console.WriteLine("You get a potion and heal yourself to full health!");
                    switch (player.Profession)
                    {
                        case "mage":
                            Console.WriteLine("You also get a new spellbook that makes your spells do 1+ in damage!");
                            break;

                        case "warrior":
                            Console.WriteLine("You also get a one-time wetstone that gives your sword 1+ in damage!");
                            break;

                        case "ranger":
                            Console.WriteLine("You also get some magic infused arrows that do 1+ in damage!");
                            break;

                        default:
                            Console.WriteLine("You also get a new weapon with 1+ in damage!");
                            break;
                    }
                    player.hp = player.MaxHp;
                    player.Attack += 1;
                    break;

            }

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MaybeFindCoins(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int findCoins = RandomNumber(1, 4);

            if (findCoins == 1)
            {
                int goldAmount = RandomNumber(10, 200);
                Console.WriteLine("You find " + goldAmount + " gold!");
                player.goldCoins += goldAmount;
            } 
            Console.ResetColor();
        }

        // CREATES A RANDOMIZER AND GIVES A RANDOM NUMBER TO USE
        static int RandomNumber(int startNumber, int endNumber)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(startNumber, endNumber);
            return randomNumber;
        }
    }
}
