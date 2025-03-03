using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCNR
{
    public class Town
    {



        public Town() { }
        public static void EnteringTownAnimation()
        {
            //array with text 
            string[] animationFrames = new string[]
            {
                        "Narrator: Walking down the path...",
                        "\n\tThe town gates appear on the horizon...",
                        "\n\tYou approach the gates...",
                        "\n\tThe gates slowly creak open...",
                        "\n\tYou step into the town, greeted by the sights and sounds of life."
            };

            foreach (string frame in animationFrames)
            {
                Console.WriteLine(frame);   // Display the current frame
                Thread.Sleep(1500);         // Pause for 1.5 seconds before showing the next frame
            }

            Console.Clear();
        }
        //*****TOWN METHOD*****//
        public static void TutorialTownEntrance()
        {
            string title = "You have entered the Town of Eldoria";
            string next = "Hit <enter to continue>";
            int borderWidth1 = next.Length + 6;
            int borderWidth = title.Length + 6;

            //border + title

            Console.WriteLine("╔" + new string('═', borderWidth) + "╗");
            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");
            Console.WriteLine($"║   {title}   ║");
            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");
            Console.WriteLine("╚" + new string('═', borderWidth) + "╝");
            Console.WriteLine($"\n{next}");



            //hit enter to clear screen
            Console.WriteLine();
            string input = Console.ReadLine();
            if (input != null)
            {
                Console.Clear();
                Thread.Sleep(1500);
            }

            //game dialogue
            string[] gameDialogue = new string[]
            {
                "Narrator: After your training...",
                "\n\tYou make your way to the bustling town centre...",
                "\n\tA townsfolk informs you about the Blacksmith and Potion Maker...",
                "\nStranger: 'The Blacksmith in town crafts the finest weapons in the realm' says the stranger...",
                "\n\t'The Potion Maker will provide with the best elixirs you will ever consume' he also tells you...",
                "\nNarrator: You thank the stranger and head on your way...",
                "\n\tNow, which shall we visit first?..."
            };

            foreach (string words in gameDialogue)
            {
                Console.WriteLine(words);
                Thread.Sleep(1500);
            }
            Console.Clear();

            //loop until the player chooses to leave
            bool continueInTown = true;

            while (continueInTown)
            {
                //ask user if they want to visit blacksmith or potion maker
                Console.WriteLine("\nNarrator: Now that you are in Eldoria. What would you like to do?:");
                Console.WriteLine("\n\t1. The Blacksmith");
                Console.WriteLine("\n\t2. The Potion Maker");
                Console.WriteLine("\n\t3. Set forth on your quest");
                Console.WriteLine("\n\t4. View your inventory");
                Console.Write("\nEnter 1, 2, 3 or 4: ");

                //read player input
                string choice = Console.ReadLine();
                Console.Clear();

                //process the players choice
                switch (choice)
                {
                    case "1":
                        //VisitBlackSmith();
                        break;

                    case "2":
                        //VisitPotionMaker();
                        break;

                    case "3":
                        //EldrinDialogue();
                        break;

                    case "4":
                        //PrintInventory();
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
            Console.WriteLine("\nReturn to town? Y/N: ");
            string continueChoice = Console.ReadLine().ToLower();

            if (continueChoice == "y")
            {
                continueInTown = false; //exit the loop if the player does not want to return to town (unlikely)
            }

            Console.Clear();
        }
        //**************************************************//
        //*****TOWN METHOD*****//
        public static void ReEnterTown()
        {
            string title = "You have entered the Town of Eldoria";
            string next = "Hit <enter to continue>";
            int borderWidth1 = next.Length + 6;
            int borderWidth = title.Length + 6;

            //border + title

            Console.WriteLine("╔" + new string('═', borderWidth) + "╗");
            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");
            Console.WriteLine($"║   {title}   ║");
            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");
            Console.WriteLine("╚" + new string('═', borderWidth) + "╝");
            Console.WriteLine($"\n{next}");



            //hit enter to clear screen
            Console.WriteLine();
            string input = Console.ReadLine();
            if (input != null)
            {
                Console.Clear();
                Thread.Sleep(500);
            }

            //loop until the player chooses to leave
            bool continueInTown = true;

            while (continueInTown)
            {
                //ask user if they want to visit blacksmith or potion maker
                Console.WriteLine("\nNarrator: Welcome back to Eldoria! What would you like to do?:");
                Console.WriteLine("\n\t1. The Blacksmith");
                Console.WriteLine("\n\t2. The Potion Maker");
                Console.WriteLine("\n\t3. Set forth on your quest");
                Console.WriteLine("\n\t4. View your inventory");
                Console.Write("\nEnter 1, 2, 3 or 4: ");

                //read player input
                string choice = Console.ReadLine();
                Console.Clear();

                //process the players choice
                switch (choice)
                {
                    case "1":
                        //VisitBlackSmith();
                        break;

                    case "2":
                        //VisitPotionMaker();
                        break;

                    case "3":
                        //EldrinDialogue();
                        break;

                    case "4":
                        //PrintInventory();
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
            Console.WriteLine("\nReturn to town? Y/N: ");
            string continueChoice = Console.ReadLine().ToLower();

            if (continueChoice == "y")
            {
                continueInTown = false; //exit the loop if the player does not want to return to town (unlikely)
            }

            Console.Clear();
        }
    }
}
