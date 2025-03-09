using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCNR
{
    public class Narration
    {
        #region Thread.Sleep Method
        public static void ts500(string[] narration)
        {
            foreach (string words in narration)

            {
                Console.WriteLine(words);
                Thread.Sleep(500);
            }

            Console.ReadLine();

            Console.Clear();

        }
        public static void ts1000(string[] narration)

        {
            foreach (string words in narration)

            {
                Console.WriteLine(words);
                Thread.Sleep(1000);
            }

            Console.ReadLine();

            Console.Clear();

        }
        #endregion

        #region Win or Lose
        public static void PlayerWin()
        {
            Console.WriteLine("You have triumphed over the foe!\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
        }

        public static void PlayerLose() //Console.WriteLine + Console.ReadLine
        {
            Console.WriteLine("You have fallen in battle.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
        }
        #endregion

        #region Invalid Input
        public static void InvalidInput()
        {
            Console.WriteLine("Invalid Input! Please try again \n\n <enter>"); //Console.WriteLine + Console.ReadLine
            Console.ReadLine();
            Console.Clear();
        }
        #endregion

        #region Start 

        public static string PlayersName { get; set; }
        public static void SplashScreen()

        {

            string title = "Quest for the Lost Kingdom";

            int borderWidth = title.Length + 6;

            Console.WriteLine("╔" + new string('═', borderWidth) + "╗");

            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");

            Console.WriteLine($"║   {title}   ║");

            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");

            Console.WriteLine("╚" + new string('═', borderWidth) + "╝");

            Console.WriteLine();

            Console.Write("Enter Name: ");
            PlayersName = Console.ReadLine();


        }




        public static void IntroductionDialogue()
        {

            string[] introDialogue = new string[]

            {

                    "NARRATOR:\n\nIn the serene land of Eldoria, darkness begins to encroach, threatening the peace of its inhabitants.\n",

                    $"You are {PlayersName}, a budding hero!\n",

                    "Awakening to the call of adventure, equipped only with your bravery and a timeworn sword, your quest begins at the edge of your village.",

                    "'The Shadow Lord' cast a pall of fear across the land.\n\n<enter>"
            };

            ts500(introDialogue);


        }
        #endregion

        #region Attack Tutorial

        public static void TutorialControlDialogue()
        {
            string[] tutorialControlDialogue = new string[]

            {
                    "NARRATOR:\n\nYou enter the realm, prepared to showcase your skills",

                    "Before you stands a training dummy — your initial challenge. Hone your combat abilities to begin your journey.\n\n<enter>"
            };

            ts500(tutorialControlDialogue);
        }

        #endregion

        #region Inventory Tutorial
        public static void InventoryInstructionDialogue()
        {
            string[] inventoryInstructionP1 = new string[]
            {
                    "NARRATOR:\n\nGather more flowers to purchase health potions at the Potion Maker",
                    "Collect iron to upgrade your sword at the Blacksmith.\n\n<enter>"
            };
            ts500(inventoryInstructionP1);

            string[] inventoryInstructionP2 = new string[]
            {
                    "NARRATOR:\n\nYou should check your inventory to see if you have items that can aid you during the fight.",
                    "Remember, you earned a Health Potion in the previous battle. You can use that to heal yourself mid-fight if needed!",
                    "You can open your inventory at any time during battle by pressing 'I'. It's crucial to know what items you have available!\n\n"
            };
            ts500(inventoryInstructionP2);
        }

        public static void OpenInventory() //Console.WriteLine , Input Required
        {
            Console.Write("Press 'I' to open up Inventory: ");
        }

        public static void EndOfTutorial()
        {
            string[] endOfTutorial = new string[]
            {
                    "NARRATOR:\n\nGreat! Now you know how to check your inventory.",
                    "Now, let’s head to town and prepare for your next adventure!\n\n<enter>"
            };
            ts500(endOfTutorial);
        }
        #endregion

        #region Dropped Loots
        public static void DroppedCoin() //Console.WriteLine
        {
            Console.WriteLine("Gleaming Coin");
        }
        public static void DroppedIron() //Console.WriteLine
        {
            Console.WriteLine("Sturdy Iron");
        }

        public static void DroppedCrystalFlower() //Console.WriteLine
        {
            Console.WriteLine("Crystal Flower");
        }

        public static void SpecialSword()
        {

        }
        #endregion

        #region Pick Up Loots

        public static void TutorialInventoryDialogue()
        {

            string[] tutorialInventoryDialogue2 = new string[]
            {
                 "NARRATOR:\n\nWith the enemy defeated, you discover a trove of spoils:\n\n",
              };

            ts500(tutorialInventoryDialogue2);
        }

        public static void LootPickedUp() //Console.WriteLine
        {
            Console.WriteLine(" ");
        }

        public static void PickUpLootInstruction() //Console.WriteLine, Input required
        {
            Console.WriteLine("\nPress 'P' to collect your loot!\n");
        }

        #endregion

        #region Enter Town Screen
        public static void EnteredTownScreen()
        {
            string title = "You have entered the Town of Eldoria";

            string next = "Hit <enter to continue>";

            int borderWidth1 = next.Length + 6;

            int borderWidth = title.Length + 6;

            Console.WriteLine("╔" + new string('═', borderWidth) + "╗");

            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");

            Console.WriteLine($"║   {title}   ║");

            Console.WriteLine("║" + new string(' ', borderWidth + 0) + "║");

            Console.WriteLine("╚" + new string('═', borderWidth) + "╝");

            Console.WriteLine($"\n{next}");

            Console.ReadLine();
            Console.Clear();

        }
        #endregion

        #region Town Introduction
        public static void EnteringTownDialogue()
        {

            string[] enteringTown = new string[]

            {
                    "NARRATOR:\n\nWalking down the path, you see the town gates on the horizon.",

                    "As you approach, the gates slowly creak open, welcoming you into the town.",

                    "You step inside, greeted by the bustling sights and sounds of life.\n\n<enter>"
            };
            ts500(enteringTown);
        }

        public static void EnteredTownDialogue()
        {
            string[] enteredTownP1 = new string[]
            {
                    "NARRATOR:\n\nAfter your training, you make your way to the bustling town center.",
                    "As you wander through the lively streets, a townsfolk approaches you with useful information.\n\n<enter>"
            };
            ts500(enteredTownP1);

            string[] enteredTownP2 = new string[]
            {
                "STRANGER:\n\nThe Blacksmith in town crafts the finest weapons in the realm.",
                "The Potion Maker will provide with the best elixirs you will ever consume\n\n<enter>"
            };
            ts500(enteredTownP2);

            Console.WriteLine("NARRATOR:\n\n You thank the stranger and head on your way.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
        }
        #endregion

        #region BSorPM
        public static void VisitBSorPM() //Console.WriteLine, Input Required
        {

            Console.WriteLine("NARRATOR:\n\nNow that you are in Eldoria. What would you like to do?\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("1. Visit The Blacksmith");

            Console.WriteLine("2. Visit The Potion Maker");

            Console.WriteLine("3. Venture into the unknown");

            Console.WriteLine("0. View inventory");

            Console.Write("\nEnter 1, 2, 3 or 0: ");
        }
        #endregion

        #region BlackSmith
        public static void BlackSmithDialogue() //Dialogue for Upgrading Sword, Console.WriteLine, Input Required
        {
            string[] blackSmith = new string[]
            {
                $"THRAIN IRONHAND:\n\n Welcome to my forge, {PlayersName} . The name's Thrain Ironhand, blacksmith around here.",
                "What can I do for you today? \n\n<enter>"
            };
            ts500(blackSmith);

            Console.WriteLine("1. Upgrade Sword");

            Console.WriteLine("2. Return to Town");

            Console.Write("\nEnter 1 or 2: ");
        }

        public static void ExitBlackSmithDialogue()
        {
            string[] exitBS = new string[]
            {
                $"THRAIN IRONHAND:\n\nFair enough, {PlayersName}. Take your time. If you need anything, I'll be here.",
                "Just don’t stand too long, or I might put you to work! \n\n<enter>"
            };
            ts500(exitBS);
        }
        #endregion

        #region PotionMaker
        public static void PotionMakerDialogue() //Are going to do Healing and Strength? , Console.WriteLine, Input Required
        {
            string[] potionMaker = new string[]
            {
                $"ELYISA MOONSHADE:\n\n Welcome to my potion shop, {PlayersName}. The name's Elyisa Moonshade, the finest potion maker around here.",
                "I can provide you with the most powerful concoctions for any need, be it healing or magic.",
                "What may I get you for today? \n\n<enter>"
            };
            ts500(potionMaker);

            Console.WriteLine("1. Healing Potion");

            Console.WriteLine("2. Strength Potion");

            Console.WriteLine("3. Return to Town");

            Console.Write("\nEnter 1, 2 or 3: ");
        }

        public static void ExitPotionMakerDialogue()
        {
            string[] exitPotionMaker = new string[]
            {
                $"ELYISA MOONSHADE:\n\nFair enough, {PlayersName}. Take your time. If you need anything, just let me know.",
                "Don’t be shy, the best potions are just a word away! \n\n<enter>"
            };
            ts500(exitPotionMaker);
        }
        #endregion

        #region CaveForestKorthak
        public static void VeldrosDialogue() //Console.WriteLine, Input Required
        {
            string[] veldrosP1 = new string[]
            {
                 $"VELDROS THE SEER:\n\n Ahh, Hello {PlayersName}.",
                "You have explored the Town of Eldoria, and your next great challenge awaits.",
                "You must choose between continuing your quest to explore the Cave or the Forest, where hidden loot awaits.",
            };
            ts500(veldrosP1);

            string[] veldrosP2 = new string[]
            {
                    "VELDROS THE SEER:\n\nBut know this—should you feel prepared, you may choose to face KORTHAK THE RAVAGER, the mighty beast terrorizing the land.",
                    "The choice is yours, adventurer. Collect more loot, train further, or take on the beast now and claim glory!",
                    "Time will tell if you're ready, but remember—the longer you wait, the more powerful Korthak becomes. \n\n<enter>"
            };
            ts500(veldrosP2);
        }
        public static void PickRoute() //Console.WriteLine, Input Required
        {
            Console.WriteLine($"ELDROS THE SEER:\n\nWhere would you like to venture, {PlayersName}? You can explore the Cave, the Forest, or face Korthak the Ravager directly. What's your choice?");

            Console.WriteLine("1. Cave");

            Console.WriteLine("2. Forest");

            Console.WriteLine("4. Korthak");

            Console.WriteLine("3. Return to Eldoria");

            Console.WriteLine("5. Check inventory");


            Console.Write("\nEnter 1, 2, 3, 4 or 5: ");
        }
        #endregion


        #region Forest
        public static void EnterForest()
        {
            string[] forestMessages = new string[]
            {
                     "Entering the forest.",
                     "Entering the forest..",
                     "Entering the forest..."
            };
            ts1000(forestMessages);
        }

        public static void ExitingForest()
        {
            string[] forestExitMessages = new string[]
            {
                     "Exiting the forest.",
                     "Exiting the forest..",
                     "Exiting the forest..."
            };
            ts1000(forestExitMessages);
        }

        public static int F1orF2()//Console.WriteLine, Input Required
        {
            string[] forestMessages = new string[]
            {
                     "NARRATOR:\n\nYou stand in a peaceful glade deep within the forest, surrounded by towering trees and the soft whisper of leaves in the wind.",
                     "The air smells of earth and moss, and the tranquility of the place seems almost magical.",
                     "Before you, two paths stretch into the shadows, each one promising its own adventure.",
                     "What will you do?\n\n<enter>"
            };
            ts500(forestMessages);

            Console.WriteLine("1. Venture down the first path, where the trees grow thicker and the air feels heavier.");
            Console.WriteLine("2. Take the second path, where the distant sound of rushing water calls you.");
            Console.WriteLine("0. Exit the forest, retreating to the safety of the known.");

            Console.Write("\nEnter 1, 2 or 0: ");
            int choice = Console.Read();
            return choice;
        }

        public static int F3orRetraceorExit() // Console.WriteLine, Input Required
        {
            Console.WriteLine("1. Press on, venturing deeper into the shadowy heart of the forest.");
            Console.WriteLine("2. Turn back, retracing your steps to the safety of the forest’s edge.");
            Console.WriteLine("0. Exit the forest, abandoning your journey for now.");

            Console.Write("\nEnter 1, 2 or 0: ");
            int choice = Console.Read();
            return choice;
        }

        public static int F1BloomingBehemoth() //Console.WriteLine, Input Required
        {
            string[] f1BloomingBehemoth = new string[]
            {
               "NARRATOR:\n\nThe flower fields stretch endlessly, a sea of vibrant blooms swaying gently in the breeze. The air hums with life, petals fluttering like confetti around you.",
               "Without warning, the ground trembles beneath your feet. A colossal figure erupts from the earth, scattering flowers in every direction.\n\n<enter>"
            };
            ts500(f1BloomingBehemoth);

            Console.WriteLine("NARRATOR:\n\nA Blooming Behemoth emerges, its massive form entwined with vines and blossoms, towering over the landscape.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("BLOOMING BEHEMOTH:\n\nYou dare to trespass in my garden? Foolish wanderer, prepare to face my wrath!\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("NARRATOR:\n\nYour heart pounds as you clutch your staff. The creature’s eyes glow with ancient fury. A choice lies before you — stand your ground or make a desperate escape.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("1. Stand your ground and confront the beast beneath the ancient canopy.");
            Console.WriteLine("2. Flee into the shadowy thicket, hoping the dense forest will conceal your escape.");
            Console.Write("\nEnter 1 or 2: ");

            int choice = Console.Read();
            return choice;


        }

        public static int F3CrestFallenWarden()  //Console.WriteLine, Input Required
        {
            string[] f3CrestFallenWarden = new string[]
             {
               "NARRATOR:\n\nThe air in the forest is thick with the scent of wildflowers and damp earth. As you tread carefully through the underbrush, a strange silence falls over the area, the usual sounds of the forest oddly absent.",
               "A rustle from the thicket breaks the quiet. Before you can react, the ground cracks open, and a monstrous figure rises, its form barely visible through a thick fog of petals and leaves.\n\n<enter>"
             };
            ts500(f3CrestFallenWarden);

            Console.WriteLine("NARRATOR:\n\nThis is no ordinary beast. Before you stands a CRESTFALLEN WARDEN, a creature of ancient wood and vine, its body shifting like a living mass of tangled branches and moss-covered bark.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("CRESTFALLEN WARDEN:\n\nThe forest has whispered your arrival, wanderer. But it does not welcome you. Turn back, or become part of the soil you tread upon.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("NARRATOR:\n\nYou feel the ground beneath your feet tremble with the Warden's every movement. The very air seems to thicken, the atmosphere growing charged with an unnatural force. A choice lies before you — fight the ancient guardian, or flee before its wrath consumes you.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("1. Face the ancient Warden, standing tall against the might of the forest.");
            Console.WriteLine("2. Slip into the tangled underbrush, hoping the forest's secrets will hide your retreat.");
            Console.Write("\nEnter 1 or 2: ");
            int choice = Console.Read();
            return choice;

        }

        public static int SpecialFlowerDialogue() ////Console.Write, Input Required
        {
            string[] specialFlowerDialogueP1 = new string[]
            {
                "NARRATOR:\n\nAs you step into the clearing, the air sparkles with golden light, and vibrant flowers bloom all around you.",
                "The warm breeze carries the sweet fragrance of petals, and a soft, otherworldly presence fills the air.",
                "A voice, gentle yet powerful, resonates through the space—its source a being unlike any you have seen.\n\n<enter>"
            };
            ts500(specialFlowerDialogueP1);

            string[] specialFlowerDialogueP2 = new string[]
            {
                $"LIRA:\n\n'Welcome, {PlayersName}. You have entered a sacred space, a sanctuary of nature and light.",
                "Before you may approach the sacred flower, you must prove your worthiness. Answer my riddles, and you shall gain access.\n\n<enter>"
            };
            ts500(specialFlowerDialogueP2);

            string[] specialFlowerDialogueP3 = new string[]
            {
                "NARRATOR:\n\nThe air thickens with a sense of anticipation, as if the very earth is watching your every move.",
                "Lira's wings shimmer, their rainbow-colored feathers casting soft hues across the clearing.",
                "The sacred flower, nestled in the center, seems to glow even brighter as the challenge begins.\n\n<enter>"
            };
            ts500(specialFlowerDialogueP3);

            Console.WriteLine("1. Accept the challenge and answer Lira's riddle to gain access to the sacred flower.");
            Console.WriteLine("2. Turn away from the challenge, choosing to leave the grove and its mysteries behind.");
            Console.Write("\nEnter 1 or 2: ");
            int choice = Console.Read();
            return choice;
        }

        public static string sfRiddle1()  //Console.WriteLine, Input Required
        {
            Console.WriteLine($"LIRA:\n\nVery well, {PlayersName}! Here is your first riddle.'");
            Thread.Sleep(500);
            Console.WriteLine("I greet the dawn and fade with the night, I bring warmth and light, yet I’m not a flame’s might. What am I?");
            Console.Write("\nAnswer: ");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void sfRiddle1Correct()
        {
            Console.WriteLine("NARRATOR:\n\nThe air around you shimmers with approval as Lira, Guardian of the Blooming Grove, smiles warmly.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("LIRA:\n\nYou have proven your worthiness for the first riddle!\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("NARRATOR:\n\nThe path ahead radiates with a soft, golden glow, inviting you to continue on your journey through the sacred grove.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
        }

        public static void sfRiddle1and2Incorrect()
        {
            Console.WriteLine("LIRA:\n\nAlas, brave traveler, your answer is not correct.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("NARRATOR:\n\nA shadow of doubt crosses your mind. But do not be disheartened; every challenge is a lesson.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("LIRA:\n\nTake a moment to reflect. You have one more chance.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
            Console.ReadLine();
        }

        public static void sfRiddle2()  //Console.Write, Input Required
        {
            Console.WriteLine("LIRA:\n\nNow, for your next riddle.");
            Thread.Sleep(500);
            Console.WriteLine("I bloom in the spring, bringing joy to the eye. I can symbolize love, yet I wither and die. What am I?");
            Console.Write("\nAnswer: ");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void sfRiddle2Correct()
        {
            Console.WriteLine("NARRATOR:\n\nThe air around you shimmers with approval as Lira, Guardian of the Blooming Grove, smiles warmly.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("LIRA:\n\nYou have proven your worthiness for the second riddle!\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("NARRATOR:\n\nThe petals around you dance in the breeze, celebrating your success. The grove seems to hum with energy.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
        }

        public static void OneCorrect()
        {
            string[] onecorrect = new string[]
            {
                "LIRA:\n\nAh, you have successfully answered one riddle!",
                "LIRA:\n\nYou shall receive a Crystal Flower, a token of your wisdom.",
                "LIRA:\n\nTake it to the Potion Maker, where you can craft a healing potion that will increase your strength.\n\n<enter>"
            };
            ts500(onecorrect);
        }

        public static void TwoCorrect()
        {
            string[] twocorrect = new string[]
            {
                    "LIRA:\n\nIncredible! You have answered both riddles with grace!",
                    "LIRA:\n\nYou are blessed with 2 Crystal flowers, symbols of your exceptional insight.",
                    "LIRA:\n\nUse them wisely at the Potion Maker to create a powerful potion that will grant you double the strength.\n\n<enter>"
            };
            ts500(twocorrect);

        }

        #endregion

        public static void RetracingSteps()
        {
            string[] retracing = new string[]
     {
                        "Retracing steps.",
                        "Retracing steps..",
                        "Retracing steps..."
     };
            ts1000(retracing);
        }

        #region Cave
        public static void EnterCave()
        {
            string[] caveMessages = new string[]
            {
                        "Entering the cave.",
                        "Entering the cave..",
                        "Entering the cave..."
            };
            ts1000(caveMessages);
        }

        public static void ExitingCave()
        {
            string[] caveExitMessages = new string[]
            {
                      "Exiting the cave.",
                      "Exiting the cave..",
                      "Exiting the cave..."
            };
            ts1000(caveExitMessages);
        }
        public static int C1orC2() //Console.WriteLine, Input Required
        {
            string[] caveMessages = new string[]
            {
                      "NARRATOR:\n\nYou stand at the heart of the cave, the air heavy with the echoes of dripping water and the scent of damp earth.",
                      "Before you, two distinct paths stretch into the shadows, each one promising mystery and danger.",
                      "What will you do?\n\n<enter>"
            };
            ts500(caveMessages);

            Console.WriteLine("1. Venture down the first tunnel, its darkness hiding unknown secrets.");
            Console.WriteLine("2. Choose the second trail, where a faint light flickers in the distance.");
            Console.WriteLine("0. Exit the cave, retreating from whatever lies ahead.");

            Console.Write("\nEnter 1, 2 or 0: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        public static int C3orRetraceorExit() //Console.WriteLine, Input Required
        {
            Console.WriteLine("1. Press on, venturing deeper into the cave’s unknown depths.");
            Console.WriteLine("2. Turn back, retracing your steps to the safety of the entrance.");
            Console.WriteLine("0. Exit the cave, abandoning the journey for now.");

            Console.Write("\nEnter 1, 2 or 0: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        public static int C1GloomBeast() //Console.WriteLine, Input Required
        {
            string[] c1GloomBeastP1 = new string[]
            {
                "NARRATOR:\n\nAs you venture deeper into the cave, the air grows colder and the shadows seem to shift unnaturally around you.",
                "Suddenly, a low growl echoes through the darkness, followed by the heavy thud of footsteps approaching.",
                "A monstrous creature steps forward, its eyes glowing like embers in the dark—it's a Gloombeast, towering and menacing.\n\n<enter>"
            };
            ts500(c1GloomBeastP1);

            Console.WriteLine("GLOOMBEAST:\n\nYou dare disturb my sanctuary?! Prepare to face your doom!/n/n<enter>"); Thread.Sleep(500);
            Console.ReadLine();
            Console.Clear();

            string[] c1GloomBeastP2 = new string[]
            {
                "NARRATOR:\n\nYour heart races as you grip your weapon, knowing the battle is imminent.",
                "Will you stand your ground and fight, or will you flee into the darkened depths?\n\n<enter>"
            };

            Console.WriteLine("1. Stand your ground and face the beast in battle.");
            Console.WriteLine("2. Flee into the darkened depths, hoping to escape its wrath.");
            Console.Write("\nEnter 1 or 2: ");
            ts500(c1GloomBeastP2);

            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;

        }

        public static int C3GemstoneTitan() //Console.Write, Input Required
        {
            string[] c3GemstoneTitanP1 = new string[]
            {
                "NARRATOR:\n\nAs you carefully make your way through the winding corridors of the cave, the air grows colder, and the walls seem to pulse with an eerie energy.",
                "Suddenly, the ground trembles beneath you, and a low rumble echoes in the distance, growing louder with each passing second.",
                "From the shadows emerges a towering figure—its body encased in shining gemstones, glowing ominously. It's a Gemstone Titan, a creature of stone and crystal.\n\n<enter>"
            };
            ts500(c3GemstoneTitanP1);

            Console.WriteLine("GEMSTONE TITAN:\n\n'You awaken me from my slumber. Prepare to feel the wrath of the earth itself!'\n\n<enter>");
            Thread.Sleep(500);
            Console.ReadLine();
            Console.Clear();

            string[] c3GemstoneTitanP2 = new string[]
            {
                "NARRATOR:\n\nYour breath quickens as you draw your weapon, your heart pounding in your chest. The time for decision is now.",
                "Will you stand firm and face the Gemstone Titan in battle, or will you retreat into the shadows, hoping to survive?\n\n<enter>"
            };
            ts500(c3GemstoneTitanP2);

            Console.WriteLine("1. Fight the Gemstone Titan with all your strength.");
            Console.WriteLine("2. Retreat and attempt to escape the cave, avoiding the confrontation.");
            Console.Write("\nEnter 1 or 2: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        public static void DeadEndCave()
        {

            string[] deadEndDialogue = new string[]
            {
                    "NARRATOR:\n\nYou've reached a dead end, the path ahead blocked by massive rocks and a cold, impenetrable darkness.",
                    "The walls close in around you, the air thick and still. The only way out is to retrace your steps.\n\n<enter>",
            };
            ts500(deadEndDialogue);

            Console.WriteLine("Press <enter> to exit");
            Console.ReadLine();
        }

        public static void EscapeCaveRiddleDialogue()
        {
            string[] caveEscapeDialogueP1 = new string[]
            {
                    "NARRATOR:\n\nThe dim glow of your torch flickers as you retrace your steps, searching for the cave’s exit.",
                    "Without warning, a towering figure emerges from the shadows, blocking your path.\n\n<enter>"
            };
            ts500(caveEscapeDialogueP1);

            string[] caveEscapeDialogueP2 = new string[]
            {
                    "ATHRON:\n\nI am Athron, the guardian of this place. You have wandered in circles, and now your fate rests in my hands.",
                    "Answer my riddle correctly, and I shall show you the way out. Fail, and you may never escape this cave.\n\n<enter>"
            };
            ts500(caveEscapeDialogueP2);

            Console.WriteLine("NARRATOR:\n\nYou feel the weight of the moment—answer correctly, and you may proceed. Fail, and you may never escape this cave.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
        }

        public static string EscapeCaveRiddle() //Console.Write, Input Required
        {
            Console.Write("ATHRON:\n\nSo, the riddle is this: Convert the binary 10000001 into a decimal!\n\nAnswer:");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void EscapeCaveRiddleCorrect()
        {
            Console.WriteLine("ATHRON:\n\nCorrect! You may proceed and DO NOT ever come back.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("NARRATOR:\n\nWith a sense of relief, you step past the Guardian and exit the cave.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
        }

        public static void EscapeCaveRiddleIncorrec()
        {
            Console.WriteLine("ATHRON:\n\nIncorrect! You have sealed your fate.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("NARRATOR:\n\nThe Guardian raises his hand, and darkness engulfs you. You perish in the cave.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
        }

        public static void SpecialSwordDIalogue()
        {
            string[] caveChestDialogue = new string[]
            {
                    "NARRATOR:\n\nAs you explore the depths of the cave, you stumble upon an ancient chest, its surface adorned with intricate carvings.",
                    "Curiosity piqued, you kneel before the chest and notice a strange inscription on the lock.\n\n<enter>"
            };
            ts500(caveChestDialogue);

        }

        public static string SpecialSwordGuess() //Console.Write, Input Required
        {
            Console.WriteLine("NARRATOR:\n\nIt reads: 'To reveal the power within, speak the word of light.'");
            Thread.Sleep(500);
            Console.WriteLine("You think for a moment. Perhaps the answer lies in the very essence of what you seek. It's a simple word related to illumination");
            Thread.Sleep(500);
            Console.Write("\n\nAnswer:");

            string answer = Console.ReadLine().ToUpper();
            return answer;
        }

        public static void SpecialSwordCorrect()
        {

            string[] specialSwordCorrectP1 = new string[]
                {
                            "NARRATOR:\n\nThe chest creaks open as the passcode is accepted.",
                            "Inside, you find a magnificent sword, its blade shimmering with a faint, ethereal glow\n\n<enter>."
                };
            ts500(specialSwordCorrectP1);

            string[] specialSwordCorrectP2 = new string[]
               {
                "NARRATOR:\n\nThis is the Blade of Lumina, said to be forged by the celestial smiths of old.",
                 "Legends say that this sword possesses great power, but it can only be wielded once.",
                "As you hold the blade, you feel a profound connection, as if it recognizes your bravery and desire to protect the innocent.",
                    "Will you claim it as your own? <enter>"
               };
            ts500(specialSwordCorrectP2);
        }

        public static void SpecialSwordIncorrect()
        {
            Console.WriteLine("NARRATOR:\n\nThe lock remains steadfast. Perhaps you should try again and think of something brighter.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
        }

        public static char SpecialSwordClaim() //Console.Write, Input Required
        {
            Console.Write("Press 'C' to claim the Blade of Lumina and add it to your inventory: ");
            char claim = Convert.ToChar(Console.ReadLine().ToUpper());
            return claim;
        }

        #endregion

        #region Korthak
        public static void ReadyForKorthakDialogue()
        {
            string[] readyForKorthakP1 = new string[]
            {
                 $"VELDROS THE SEER:\n\n {PlayersName}, it seems you're ready to face KORTHAK THE RAVAGER.",
                 "You’ve gathered the strength, skill, and courage needed for this battle.",
                 "Your weapons are sharp, your armor sturdy, and your resolve unwavering."
            };
            ts500(readyForKorthakP1);

            string[] readyForKorthakP2 = new string[]
           {
                 "Go forth, adventurer, and show the beast what Eldoria's champions are made of.",
                 "I wish you the best of luck. May your bravery lead you to victory. \n\n<enter>"
            };
            ts500(readyForKorthakP2);
        }

        public static void NotReadyForKorthakDialogue()
        {
            string[] notReadyForKorthakP1 = new string[]
            {
                $"VELDROS THE SEER:\n\n {PlayersName}, I sense you are not yet fully prepared to face KORTHAK THE RAVAGER.",
                "The path ahead is treacherous, and Korthak is a force to be reckoned with."
            };
            ts500(notReadyForKorthakP1);

            string[] notReadyForKorthakP2 = new string[]
            {
                "I suggest you venture into the Cave or the Forest, where you will find Feral Beasts guarding valuable loot and resources.",
                "Defeating these creatures will grant you the strength and upgrades you need to face the Ravager.",
                "Take your time, gather what you can, and return when you feel ready to take on Korthak. \n\n<enter>"
            };
            ts500(notReadyForKorthakP2);
        }

        public static void KorthakConfrontation()
        {
            Console.WriteLine("NARRATOR:\n\nThe ground shakes beneath your feet as you step into the darkened arena. A looming figure emerges from the shadows, its eyes glowing with malice. It is KORTHAK THE RAVAGER, the terror of Eldoria.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();
            string[] korthakConfrontationDialogue = new string[]
                {
                            "KORTHAK:\n\nFoolish mortal. You think you can defeat me? I am the embodiment of destruction, the end of all who challenge me.",
                            "I’ve torn kingdoms asunder and crushed the bravest warriors. You are nothing but a fleeting spark in my path. But you are brave—I'll give you that. Prepare to meet your doom!\n\n<enter>"
                };
            ts500(korthakConfrontationDialogue);

            Console.WriteLine("NARRATOR:\n\nYour heart pounds in your chest as you draw your weapon, facing the terrifying beast before you. There is no turning back. This will be the fight of your life.\n\n<enter>");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("KORTHAK:\n\nLet’s see if your courage can withstand the might of Korthak!");
            Console.ReadLine();
            Console.Clear();
        }
        #endregion

        #region Victory

        public static void Victory() //Console.Write, Input Required
        {
            string[] victoryDialogue = new string[]
            {
                "NARRATOR:\n\nWith one final, decisive blow, you shatter the Big Boss into pieces!",
                "The monstrous shadow that plagued the land begins to dissolve, releasing a burst of light.",
                "You stand victorious, heart pounding, as the echoes of your triumph fill the air.",
                "The townspeople, having witnessed the battle from a distance, rush toward you with cheers and applause!\n\n<enter>"
            };
            ts500(victoryDialogue);

            Console.WriteLine("VELDROS THE SEER:\n\n You did it! You defeated Korthak the Ravager!\n\n<enter>.");

            string[] heroVictoryDialogue = new string[]
            {
                    "NARRATOR:\n\nChildren dance around you, and the elders bow in gratitude.",
                    "Your name will be sung in songs for generations to come!",
                    "You are a true hero of Eldoria!\n\n<enter>"
            };
            ts500(heroVictoryDialogue);

            string[] endGameDialogue = new string[]
            {
                    "NARRATOR:\n\nAs the celebrations die down, you realize that your journey has come to an end.",
                    "The land of Eldoria is safe once more, and you can rest knowing you gave everything for its future.",
                    "Your legend will live on, immortalized in the hearts of all who know your name.",
                    "\n\nThank you for playing! Until next time, brave hero...\n\n<enter>"
            };
            ts500(endGameDialogue);

            Console.WriteLine("Press any key to exit...");
        }
        #endregion

    }
}
