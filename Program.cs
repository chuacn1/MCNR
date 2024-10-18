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
        static void Main(string[] args)
        {
            //Introduction();
            //TutorialControl();
            EnteringTownAnimation();
            Town();
            Console.ReadLine();
        }
    }
}
