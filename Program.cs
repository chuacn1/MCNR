namespace MCNR
{
    internal class Program
    {

        static void Introduction()
        {
            string title = "Quest for the Lost Kingdom";
            int borderWidth = title.Length + 6;

            //border + title

            Console.WriteLine("╔" + new string('═', borderWidth) + "╗");
            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");
            Console.WriteLine($"║   {title}   ║");
            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");
            Console.WriteLine("╚" + new string('═', borderWidth) + "╝");
            Console.WriteLine();


            //storyline intro
            Console.WriteLine("Please Enter Your Name: ");
            string playersName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("In the tranquil realm of Eldoria, shadows have begun to creep into the lands, threatening the harmony of its inhabitants.");
            Console.ReadLine();
            Console.WriteLine($"As a fledgling hero named {playersName}, you awaken to the call of adventure, armed only with your courage and a weathered sword.");
            Console.ReadLine();
            Console.WriteLine("Your journey begins at the outskirts of your village, where whispers of a fearsome foe—the Shadow Lord—fill the air with dread.");
            Console.ReadLine();
            Console.Clear();
        }

        static void TutorialControl()
        {
            Console.WriteLine("You step into the realm, ready to prove your mettle.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("A training dummy stands before you, your first test. You must master the art of combat by pressing 'A' to strike.");
            Console.Clear();

            //enemy and player's hp
            int enemy1HP = 20;
            int playerHP = 50;
            Random rand = new Random();

            do
            {
                Console.WriteLine("Press 'A' to strike");
                char attack = Convert.ToChar(Console.ReadLine());
                attack = char.ToLower(attack);
                Console.WriteLine();

                // Player Attack
                if (attack == 'a')
                {
                    Console.Beep(1000, 300);
                    int hitmiss = rand.Next(1, 5);
                    switch (hitmiss)
                    {
                        case 1:
                            Console.WriteLine($"Enemy HP: {enemy1HP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("Your swing goes wide, missing the enemy entirely!");
                            Console.WriteLine("0 damage\n");
                            Console.WriteLine("The enemy retaliates!\n");
                            Thread.Sleep(1000);
                            enemy1HP = 20;
                            break;
                        case 2:
                            Console.WriteLine($"Enemy HP: {enemy1HP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("You strike true!");
                            Console.WriteLine("5 damage dealt!\n");
                            Console.WriteLine("The enemy retaliates!\n");
                            Thread.Sleep(1000);
                            enemy1HP -= 5;
                            break;
                        case 3:
                            Console.WriteLine($"Enemy HP: {enemy1HP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("A fierce blow!");
                            Console.WriteLine("10 damage dealt!\n");
                            Console.WriteLine("The enemy retaliates!\n");
                            Thread.Sleep(1000);
                            enemy1HP -= 10;
                            break;
                        default:
                            Console.WriteLine($"Enemy HP: {enemy1HP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("You landed a glancing blow.");
                            Console.WriteLine("2 damage dealt!\n");
                            Console.WriteLine("The enemy retaliates!\n");
                            Thread.Sleep(1000);
                            enemy1HP -= 2;
                            break;
                    }
                }
                else //if user did not press 'a'
                {
                    Console.WriteLine("That action is not valid.");
                }

                // Enemy Attack
                Console.Beep(800, 300);
                int misshit = rand.Next(1, 5);
                switch (misshit)
                {
                    case 1:
                        Console.WriteLine($"Enemy HP: {enemy1HP}");
                        Console.WriteLine($"Your HP: {playerHP}");
                        Console.WriteLine("The enemy missed their strike!");
                        Console.WriteLine("0 damage");
                        Console.WriteLine("\nPress Enter for your turn");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        playerHP -= 5;
                        Console.WriteLine($"Enemy HP: {enemy1HP}");
                        Console.WriteLine($"Your HP: {playerHP}");
                        Console.WriteLine("The enemy lands a blow!");
                        Console.WriteLine("5 damage taken");
                        Console.WriteLine("\nPress Enter for your turn");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        playerHP -= 10;
                        Console.WriteLine($"Enemy HP: {enemy1HP}");
                        Console.WriteLine($"Your HP: {playerHP}");
                        Console.WriteLine("The enemy strikes fiercely!");
                        Console.WriteLine("10 damage taken");
                        Console.WriteLine("\nPress Enter for your turn");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        playerHP -= 2;
                        Console.WriteLine($"Enemy HP: {enemy1HP}");
                        Console.WriteLine($"Your HP: {playerHP}");
                        Console.WriteLine("The enemy lands a glancing blow.");
                        Console.WriteLine("2 damage taken");
                        Console.WriteLine("\nPress Enter for your turn");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }

            }

            //once enemy or player dies, stops loop
            while (enemy1HP > 0 && playerHP > 0);

            if (enemy1HP <= 0) //enemy dies
            {
                Console.Beep(1000, 500);
                Console.WriteLine("You have triumphed over the foe!");
                Console.ReadLine();
            }
            if (playerHP <= 0) //player dies
            {
                Console.Beep(400, 500);
                Console.WriteLine("You have fallen in battle.");
                Console.ReadLine();
                return;  //stop program
            }
        }

        static void TutorialInventory()
        {
            TutorialControl();     // will do later 

        }

        static void Town()
        {
            //declare all variables

            //ints
            int blacksmith = 1, healthCentre = 2;

            //string
            string border = new string('=', 100);


            //title and border
            //****************************************************************************************//
            Console.WriteLine(border);
            //title text
            //this title will be centered
            string title = "You have entered the Town of Eldoria"; 
            int totalWidth1 = 100;

            //leftpadding
            int leftPadding1 = (totalWidth1 - title.Length) / 2;

            //padding text with spaces to center it
            string centeredText1 = title.PadLeft(leftPadding1 + title.Length).PadRight(totalWidth1);

            //print title text
            Console.WriteLine(centeredText1);

            //bottom text
            //text that is going to be centered
            string next = "Hit <enter> to continue";
            int totalWidth2 = 100;

            //left padding
            int leftPadding2 = (totalWidth2 - next.Length) / 2;

            //padding text with spaces to center it
            string centeredText2 = next.PadLeft(leftPadding2 + next.Length).PadRight(totalWidth2);

            //print bottom text
            Console.WriteLine(centeredText2);
            Console.WriteLine(border);
            //****************************************************************************************//
            
            //hit enter to clear screen
            Console.WriteLine();
            string input = Console.ReadLine();
            if (input != null)
            {
                Console.Clear();
                Thread.Sleep(500);
            }

            static void TutorialInventory()
            {
                TutorialControl();

            }


            //game dialogue
            string[] gameDialogue = new string[]
            {
                "After your training...",
                "You make your way to the bustling town centre...",
                "A townsfolk informs you about the Blacksmith and Potion Maker...",
                "Your adventure begins!"
            };

            foreach (string words in gameDialogue)
            {
                Console.Clear();
                Console.WriteLine(words);
                Thread.Sleep(1500);
            }
        }

        static void EnteringTownAnimation()
        {
            //array with text 
            string[] animationFrames = new string[]
            {
                    "Walking down the path...",
                    "The town gates appear on the horizon...",
                    "You approach the gates...",
                    "The gates slowly creak open...",
                    "You step into the town, greeted by the sights and sounds of life."
            };

            foreach (string frame in animationFrames)
            {
                Console.Clear();            // Clear the console to simulate movement
                Console.WriteLine(frame);   // Display the current frame
                Thread.Sleep(1500);         // Pause for 1.5 seconds before showing the next frame
            }

            Console.Clear();
        }

        static void CaveOrForest() //player will choose where he want to go cave or forest
        {
            int choose;




            Console.WriteLine("Press 1 for cave or Press 2 for forest: ");
            string decision = Console.ReadLine();

            // Validate input to prevent exceptions
            if (!int.TryParse(decision, out choose) || (choose != 1 && choose != 2))
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2.");
                return; // Exit if invalid
            }

            // Additional border design for output
            Console.WriteLine(new string('-', 30));

            if (choose == 1)
            {
                Console.WriteLine("Entering the cave...");
            }
            else
            {
                Console.WriteLine("Entering the forest...");
            }

            Console.WriteLine(new string('-', 30));
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Introduction();
            TutorialControl();
            EnteringTownAnimation();
            Town();
            CaveOrForest();
            Console.ReadLine();
        }
    }
}
