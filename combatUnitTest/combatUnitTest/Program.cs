using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing...");
            int playerHP = 100; // starting player HP
            int enemyHP = 100;  // starting enemy HP

            // Calling the method with initial player and enemy HP
            playerHP = EnemyVsPlayer(playerHP, ref enemyHP);

            // Final state after combat
            Console.WriteLine($"Combat finished. Final player HP: {playerHP}, enemy HP: {enemyHP}");
        }

        // Method that handles the combat between the player and the enemy
        static int EnemyVsPlayer(int playerHP, ref int enemyHP)
        {
            Random rand = new Random();

            do
            {
                Console.Write("Press 'A' to strike or 'I' to check your inventory: ");
                string input = Console.ReadLine();

                char choice = ' '; // Declare choice outside of the input check. This is to avoid a crash. 

                if (input.Length > 0) // Checks if the input has at least one character
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
                    int playerDamage = rand.Next(10, 20);
                    enemyHP -= playerDamage;

                    Console.ForegroundColor = ConsoleColor.Green; // Set text color for player
                    Console.WriteLine($"You attack the enemy for {playerDamage} damage!");
                    Console.ResetColor(); // Reset to default color
                }

                // Enemy Attack (if still alive)
                if (enemyHP > 0)
                {
                    int enemyDamage = rand.Next(5, 15);
                    playerHP -= enemyDamage;

                    Console.ForegroundColor = ConsoleColor.Red; // Set text color for enemy
                    Console.WriteLine($"The enemy attacks you for {enemyDamage} damage!");
                    Console.ResetColor(); // Reset to default color
                }

                // Display updated HP
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Your HP: {playerHP}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Enemy HP: {enemyHP}");
                Console.ResetColor(); // Reset to default color

            } while (playerHP > 0 && enemyHP > 0);

            return playerHP; // Return the player's HP after combat ends
        }
        //removed the contanst need to press enter between attacks. 

        // Method to print player's inventory (just a placeholder here)
        static void PrintInventory()
        {
            Console.WriteLine("This method will print the player's inventory.");
        }
    }
}
