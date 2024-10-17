namespace MCNR
{
    internal class Program
    {
        
        static void Introduction() 
        {
            Console.WriteLine("In the peaceful realm of Eldoria, darkness has begun to creep into the lands, threatening the harmony of its inhabitants. <enter>");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("As a young hero named [Enter Name], you awaken to the call of adventure, armed only with your determination and a rusty sword. <enter>");
            string playersName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Your journey begins at the edge of your village, where whispers of a powerful foe—the Shadow Lord—stir fear in every heart. <enter>");
        }

        static void TutorialControl() 
        {
            Console.WriteLine("You step into the world, ready to prove your worth. <enter>");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("A training dummy awaits, your first test. You must learn the art of combat by pressing 'A' to attack.");
            char attack = Convert.ToChar(Console.ReadLine());

            int enemy1HP = 20, enemy1Attack = 20;
            Random hitmiss = new Random();
            hitmiss.Next(0, 2);
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
