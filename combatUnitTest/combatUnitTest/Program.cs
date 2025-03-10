using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing...");
            int playerHP = 100; // starting stats
            int enemyHP = 100;  

            // Call HP stats
            playerHP = EnemyVsPlayer(playerHP, ref enemyHP);

            // Stats after combat. 
            Console.WriteLine($"Combat finished. Final player HP: {playerHP}, enemy HP: {enemyHP}");
        }

        // Combat turns 
        static int EnemyVsPlayer(int playerHP, ref int enemyHP)
        {
            Random rand = new Random();

            do
            {
                Console.Write("Press 'A' to strike or 'I' to check your inventory: ");
                string input = Console.ReadLine();

                char choice = ' '; // Declare choice outside of the input check. This is to avoid a crash. Not sure why it was crashing but this does fix it so ¯\_(ツ)_/¯ 

                if (input.Length > 0)  
                {
                    choice = input.ToLower()[0]; 
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue; // Go back to the start of the loop
                }

                // Player Attack
                if (choice == 'a')
                {
                    // Animation
                    string[] swordSwing = { "|", "/", "-", "\\" };
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("\r" + swordSwing[i % swordSwing.Length] + "  ");
                        Thread.Sleep(100);
                    }
                    Console.Write("\r   \r"); // Clear the animation

                    int playerDamage = rand.Next(10, 20);
                    enemyHP -= playerDamage;

                    Console.ForegroundColor = ConsoleColor.Green; // Set text color for player
                    Console.WriteLine($"You attack the enemy for {playerDamage} damage!");
                    Thread.Sleep(1000);
                    Console.ResetColor(); 
                }
                // Secret One-Shot Kill because I'm sick of waiting for this fight to end every time I want to test something. 
                else if (choice == 'x') // Hidden under "h"
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You use the HOLY HAND GRENADE!");
                    Console.ResetColor();
                    Console.WriteLine("The enemy is dead");
                    Console.ReadLine();
                    int playerDamage = enemyHP; 
                    enemyHP = 0;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You deal {playerDamage} damage! The enemy is defeated instantly!");
                    Console.ResetColor();
                }

                // Enemy Attack
                if (enemyHP > 0)
                {
                    int enemyDamage = rand.Next(5, 15);
                    playerHP -= enemyDamage;

                    Console.ForegroundColor = ConsoleColor.Red; // Set text color for enemy
                    Console.WriteLine($"The enemy attacks you for {enemyDamage} damage!");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                }

                // Display updated stats
                Console.WriteLine("***********************************");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Your HP: {playerHP}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Enemy HP: {enemyHP}");
                Console.ResetColor(); // Reset to default color

            } while (playerHP > 0 && enemyHP > 0);

            return playerHP; // Return the player's HP after combat ends
        }

        // Method to print player's inventory (just a placeholder here)
        static void PrintInventory()
        {
            Console.WriteLine("This method will print the player's inventory.");
        }
    }
}
