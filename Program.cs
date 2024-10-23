using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace MCNR
{
    internal class Program
    {
        //ARRAY FOR INVENTORIES
        static string[] items = new string[6];
        static int[] counts = new int[6];
        static int money = 0;
        static int enemyHP = 0;
        static int playerHP = 0;
        static int ore = 0;

        public class Weapon
        {

            public string Name { get; set; }                        //able to access and modify its value
            public int Damage { get; set; }                         //able to access and modify its value
            public int UpgradeLevel { get; set; }                   //able to access and modify its value
            public int UpgradeCost { get; set; }                    //able to access and modify its value
            public int MaxUpgradeLevel { get; set; } = 5;           //able to access and modify its value

            public Weapon(string name, int damage, int upgradeCost)
            {
                Name = name;

                Damage = damage;

                UpgradeLevel = 1; //sword starts at level 1

                UpgradeCost = upgradeCost; //cost to upgrade

            }

        }

        static void UpgradeWeapon(Weapon weapon)
        {
            if (weapon.UpgradeLevel < weapon.MaxUpgradeLevel)
            {
                if (ore > 0 && money >= weapon.UpgradeCost)
                {
                    //deduct iron and currency for upgrade
                    ore--;
                    money = weapon.UpgradeCost;

                    //increase weapons damage and level
                    weapon.UpgradeLevel++;
                    weapon.Damage += 5;
                    weapon.UpgradeCost += 10;

                    Console.WriteLine($"Upgrade {weapon.Name} to level {weapon.UpgradeLevel}!");
                    Console.WriteLine($"\nNew Damage: {weapon.Damage}, New Upgrade Cost: {weapon.UpgradeCost}");
                    Console.WriteLine($"\nIron left: {ore}, Currency left: {money}");
                }
                else
                {
                    Console.WriteLine("Not enough iron or currency to upgrade weapon");
                }
            }
            else
            {
                Console.WriteLine("Maximum upgrade level reached for this weapon");
            }
        }
        static void Main(string[] args)
        {
            //Introduction();
            //Tutorial();
            //TutorialInventory();
            //EnteringTownAnimation();
            //Town();

            //CaveOrForest();
            //CavePath1Or2();       //Enemy or Special Sword
            //CaveEnemyPath1();      // if 1 = Enemy
            SpecialSword();   //if 2 = SpecialSword  
            //EscapeCave(); //right after he got special sword
            //


            Console.ReadLine();

            static void EnemyVsPlayer()
            {
                Random rand = new Random();

                do
                {
                    Console.WriteLine("Press 'A' to strike");
                    string input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                    {
                        char attack = input.ToLower()[0];

                        Console.WriteLine();

                        // Player Attack
                        if (attack == 'a')
                        {
                            Console.Beep(1000, 300);
                            int hitmiss = rand.Next(1, 5);
                            switch (hitmiss)
                            {
                                case 1:
                                    enemyHP = 20;
                                    Console.WriteLine($"Enemy HP: {enemyHP}");
                                    Console.WriteLine($"Your HP: {playerHP}");
                                    Console.WriteLine("Your swing goes wide, missing the enemy entirely!");
                                    Console.WriteLine("0 damage\n");
                                    Console.WriteLine("The enemy retaliates!\n");
                                    Thread.Sleep(1000);
                                    break;
                                case 2:
                                    enemyHP -= 5;
                                    Console.WriteLine($"Enemy HP: {enemyHP}");
                                    Console.WriteLine($"Your HP: {playerHP}");
                                    Console.WriteLine("You strike true!");
                                    Console.WriteLine("5 damage dealt!\n");
                                    Console.WriteLine("The enemy retaliates!\n");
                                    Thread.Sleep(1000);
                                    break;
                                case 3:
                                    enemyHP -= 10;
                                    Console.WriteLine($"Enemy HP: {enemyHP}");
                                    Console.WriteLine($"Your HP: {playerHP}");
                                    Console.WriteLine("A fierce blow!");
                                    Console.WriteLine("10 damage dealt!\n");
                                    Console.WriteLine("The enemy retaliates!\n");
                                    Thread.Sleep(1000);
                                    break;
                                default:
                                    enemyHP -= 2;
                                    Console.WriteLine($"Enemy HP: {enemyHP}");
                                    Console.WriteLine($"Your HP: {playerHP}");
                                    Console.WriteLine("You landed a glancing blow.");
                                    Console.WriteLine("2 damage dealt!\n");
                                    Console.WriteLine("The enemy retaliates!\n");
                                    Thread.Sleep(1000);
                                    break;
                            }
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
                            Console.WriteLine($"Enemy HP: {enemyHP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("The enemy missed their strike!");
                            Console.WriteLine("0 damage");
                            Console.WriteLine("\nPress Enter for your turn");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            playerHP -= 5;
                            Console.WriteLine($"Enemy HP: {enemyHP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("The enemy lands a blow!");
                            Console.WriteLine("5 damage taken");
                            Console.WriteLine("\nPress Enter for your turn");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            playerHP -= 10;
                            Console.WriteLine($"Enemy HP: {enemyHP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("The enemy strikes fiercely!");
                            Console.WriteLine("10 damage taken");
                            Console.WriteLine("\nPress Enter for your turn");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        default:
                            playerHP -= 2;
                            Console.WriteLine($"Enemy HP: {enemyHP}");
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
                while (enemyHP > 0 && playerHP > 0);

            }

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
                Console.Write("Please Enter Your Name: ");
                string playersName = Console.ReadLine();
                Console.Clear();

                string[] introDialogue = new string[]
                {
                    "Narrator: In the serene land of Eldoria, darkness begins to encroach, threatening the peace of its inhabitants...",
                    $"\nYou are {playersName}, a budding hero, awakening to the call of adventure, equipped only with your bravery and a timeworn sword...",
                    "\nYour quest commences at the edge of your village, where murmurs of a formidable foe—the Shadow Lord—cast a pall of fear across the land."
                };


                foreach (string words in introDialogue)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(2000);
                }

                Console.Clear();

                string[] tutorialControlDialogue = new string[]
                {
                    "Narrator: You enter the realm, prepared to showcase your skills...",
                    "\n\tBefore you stands a training dummy, your initial challenge. To hone your combat skills, press 'A' to strike.",

                };


                foreach (string words in tutorialControlDialogue)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(2000);
                }

                Console.Clear();

            }


            static void Tutorial()
            {
                enemyHP = 20;
                playerHP = 50;

                EnemyVsPlayer();

                if (enemyHP <= 0) //enemy dies
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
                    Environment.Exit(0);  //stop program
                }
            }

            static void TutorialInventory()
            {
                string[] tutorialInventoryDialogue1 = new string[]
                {
                    "Narrator: With the first enemy vanquished, you find no treasure—only the thrill of victory. But as you catch your breath, another foe approaches, promising loot upon defeat...",
                    "\nNarrator: You have five spaces in your inventory—one already claimed by your trusty sword. Prepare wisely for what lies ahead!",

                };


                foreach (string words in tutorialInventoryDialogue1)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(2000);
                }

                EnemyVsPlayer();

                string[] tutorialInventoryDialogue2 = new string[]
            {
                    "Narrator: With the enemy defeated, you discover a trove of spoils: gleaming coins, a delicate flower, and a sturdy piece of iron.",
                    "\nNarrator: You have five spaces in your inventory—one already claimed by your trusty sword."

            };


                foreach (string words in tutorialInventoryDialogue2)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(2000);
                }
                Console.WriteLine();
                Console.WriteLine("Gleaming Coins");
                Console.WriteLine("Delicate Flower");
                Console.WriteLine("Sturdy Iron");
                Console.WriteLine();
                Console.WriteLine("Press 'P' to collect your loot!\n");
                char pick = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.Clear();

                money += 10;
                ore += 1;

                if (pick == 'P')
                {

                    AddCoins(10);

                    AddIron(1);

                    AddToInventory("Gleaming Coins");       // 

                    AddToInventory("Delicate Flower");      //

                    AddToInventory("Sturdy Iron");          //

                    Console.WriteLine($"Coins collected: {money}");

                    Console.WriteLine($"Iron collected: {ore}");



                }

                else

                {
                    Console.WriteLine("Invalid. Press 'P' to collect your loot!");

                }
                Console.WriteLine("\nNarrator: Gather more flowers to purchase health potions at the Potion Maker, and collect iron to upgrade your sword at the Blacksmith.");
                Thread.Sleep(2000);
                Console.Clear();
            }


            static void AddCoins(int amount)
            {
                // Ensure the coins are in the first index
                items[0] = "Gleaming Coins"; // Set item name for coins
                counts[0] += amount; // Increment coin count
            }

            static void AddIron(int iron)
            {
                //iron is added to third index
                items[2] = "Sturdy Iron"; //set item name for iron
                counts[2] += iron; //increment iron count
            }


            static void AddToInventory(string item) //when enemy drop loot call AddToInventory in method as shown in TutorialInventory!!!!!!
            {
                items[1] = "Trusty Sword"; //sword took up a slot
                counts[1] = 1;

                // check if the item already exists in the inventory
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == item)
                    {
                        counts[i]++;
                        Console.WriteLine($"\n{item} count increased. Total count: {counts[i]}");
                        Console.ReadLine();
                        return;

                    }
                }

                // if item does not exist, find empty slot
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == null)
                    {
                        items[i] = item;
                        counts[i] = 1;
                        Console.WriteLine($"\n{item} added to inventory. Total count: {counts[i]}");
                        Console.ReadLine();
                        return;

                    }
                }

                Console.WriteLine("Inventory full! Cannot add more items.");
                Console.ReadLine();
            }

            static void CaveEnemyPath1()
            {

                string[] caveEnemyDialogue = new string[]
                {
                    "Narrator: As you delve deeper into the cave, the air grows colder and the shadows seem to shift around you...",
                    "\n\tSuddenly, a growl echoes through the darkness, and a menacing figure emerges from the shadows!",
                    "\nNarrator: It's a Cave Troll, towering above you with a fearsome glare!",
                    "\nCave Troll: 'You dare intrude in my domain?! Prepare to face my wrath!'",
                    "\nNarrator: With adrenaline pumping through your veins, you ready your sword. The battle is about to begin!",
                    "\n\tWill you fight bravely or flee into the darkness? Press 'A' to attack!"
                };

                foreach (string line in caveEnemyDialogue)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(2000);
                }

                Console.Clear();

                enemyHP = 30;
                playerHP = 50;

                EnemyVsPlayer();
                if (enemyHP <= 0)
                {
                    Console.Beep(1000, 500);
                    Console.WriteLine("You have defeated the Cave Troll!");
                    // Here you can add rewards or further actions
                }
                else if (playerHP <= 0)
                {
                    Console.Beep(400, 500);
                    Console.WriteLine("You have fallen in battle against the Cave Troll.");
                    Console.WriteLine("Game Over.");
                    Environment.Exit(0);
                }
                else
                {
                    // In case of some unexpected outcome, though unlikely
                    Console.WriteLine("The battle ended unexpectedly.");
                }

                Console.WriteLine("Press 'P' to collect your loot!\n");
                char pick = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.Clear();

                money += 10;

                if (pick == 'P')
                {

                    AddCoins(10);

                    AddToInventory("Gleaming Coins");       // 

                    AddToInventory("Sturdy Iron");          //

                    Console.WriteLine($"Coins collected: {money}");
                }

                else

                {
                    Console.WriteLine("Invalid. Press 'P' to collect your loot!");

                }



            }

            static void SpecialSword()
            {
                //dialogue when the player finds the chest
                Console.WriteLine("Narrator: As you explore the depths of the cave, you stumble upon an ancient chest, its surface adorned with intricate carvings...");
                Thread.Sleep(2000);
                Console.WriteLine("\nNarrator: Curiosity piqued, you kneel before the chest and notice a strange inscription on the lock.");
                Thread.Sleep(2000);
                Console.WriteLine("\nNarrator: It reads: 'To reveal the power within, speak the word of light.'");
                Thread.Sleep(2000);

                //hint for the passcode
                Console.WriteLine("\nNarrator: You think for a moment. Perhaps the answer lies in the very essence of what you seek. It's a simple word related to illumination...");
                Console.WriteLine("What could it be? Type your guess:");

                string passcode = "LIGHT"; //correct passcode
                bool chestOpened = false;

                while (!chestOpened)
                {
                    string playerGuess = Console.ReadLine().ToUpper();

                    if (playerGuess == passcode)
                    {
                        chestOpened = true;
                        Console.WriteLine("\nNarrator: The chest creaks open as the passcode is accepted!");
                        Thread.Sleep(2000);
                        Console.WriteLine("\nInside, you find a magnificent sword, its blade shimmering with a faint, ethereal glow.");
                        Thread.Sleep(2000);
                        Console.WriteLine("\nNarrator: This is the *Blade of Lumina*, said to be forged by the celestial smiths of old...");
                        ContinueWithSpecialSwordDialogue();
                    }
                    else
                    {
                        Console.WriteLine("\nNarrator: The lock remains steadfast. Perhaps you should think of something brighter... Try again:");
                    }
                }
            }

            static void ContinueWithSpecialSwordDialogue()
            {
                //the rest of the dialogue about the special sword
                string[] specialSwordDialogue = new string[]
                {
                    "Narrator: Unlike your trusty sword, the *Blade of Lumina* pulses with magical energy, and legends speak of its unique ability: 'Light of Valor.'",
                    "\nNarrator: When wielded, this sword can unleash a radiant burst of light, dealing extra damage to foes and stunning them momentarily.",
                    "\nNarrator: However, such power comes with a cost—you may only use 'Light of Valor' once, so choose the moment wisely.",
                    "\nNarrator: You can feel a powerful connection to the blade, as if it senses your bravery and desire to protect the innocent.",
                    "\nNarrator: Will you claim it as your own?"
                };

                foreach (string line in specialSwordDialogue)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(2000);
                }

                Console.Clear();

                // Prompt to collect the sword
                Console.WriteLine("Press 'C' to claim the *Blade of Lumina* and add it to your inventory!\n");
                char pick = Convert.ToChar(Console.ReadLine().ToUpper());

                if (pick == 'C')
                {
                    AddToInventory("Blade of Lumina");
                    Console.WriteLine("\nNarrator: You grasp the sword tightly, feeling its power resonate through you. The *Blade of Lumina* is now yours!");
                    Console.WriteLine("\nNarrator: You can now unleash the 'Light of Valor' in battle, a radiant strike against darkness. Use it wisely!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. The sword remains in the chest, waiting for a worthy hero.");
                }
            }

            static void UseLightOfValor()  //Can only be use once, if (playerAction == "LIGHT") add this method BossVsPlayer

            {
                Console.WriteLine("\nYou raise the *Blade of Lumina* high, calling upon its magical power...");
                Thread.Sleep(1000);
                Console.WriteLine("A brilliant light envelops you, and with a mighty swing, you unleash a burst of radiant energy!");

                enemyHP -= 50; //discuss
            }

            static void EscapeCave() //need to check cuz its wrong
            {
                string[] caveEscapeDialogue = new string[]
                {
                      "Narrator: As you venture deeper into the cave, the air grows thick and heavy. A sudden realization hits you—there's no oxygen left in this part of the cave!",
                      "\n\tJust then, a massive figure blocks your path. It's the Guardian of the Cave!",
                      "\nGuardian: You have crossed into the danger zone. For your recklessness, you must answer my riddle to pass!",
                      "\nNarrator: You feel the weight of the moment—answer correctly, and you may proceed. Fail, and you may never escape this cave..."
                };
                foreach (string words in caveEscapeDialogue)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(2000);
                }

                Console.Clear();

                Console.WriteLine("Guardian: So, the riddle is this: Convert the binary 10000001 into a decimal!");
                int deci = Convert.ToInt32(Console.ReadLine());

                if (deci == 129)
                {
                    Console.WriteLine("\nGuardian: 'Correct! You may proceed and DO NOT ever come back.'");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nNarrator: With a sense of relief, you step past the Guardian and continue your adventure...");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("\nGuardian: 'Incorrect! You have sealed your fate...'");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nNarrator: The Guardian raises his hand, and darkness engulfs you. You perish in the cave...");
                    Thread.Sleep(2000);
                }


            }

            static void EnteringTownAnimation()
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
                    Thread.Sleep(2000);         // Pause for 1.5 seconds before showing the next frame
                }

                Console.Clear();
            }

            static void Town()
            {
                //border
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
                    Thread.Sleep(2000);
                }

                Console.Clear();

                //ask user if they want to visit blacksmith or potion maker
                Console.WriteLine("\nNarrator: Now that you are in Eldoria. Would you like to visit:");
                Console.WriteLine("\n\t1. The Blacksmith");
                Console.WriteLine("\n\t2. The Potion Maker");
                Console.Write("\nEnter 1 or 2: ");

                //read player input
                string choice = Console.ReadLine();
                Console.Clear();

                //process the players choice
                if (choice == "1")
                {
                    VisitBlackSmith();

                }

                else if (choice == "2")
                {
                    VisitPotionMaker();

                }

            }

            static void VisitBlackSmith()
            {
                //blacksmith dialogue
                string[] blackSmith = new string[]
               {
                "Narrator: You visit the Blacksmith...",
                "\n\tThe sound of the hammers hitting the anvils fill the air...",
                "\nStranger: 'Hello there stranger'...",
                "\nThrain Ironhand: 'The name is Thrain Ironhand'...",
                "\n\t'I am the Blacksmith around these parts'...",
                "\n\t'How can I help you?'..."
               };

                foreach (string intro in blackSmith)
                {
                    Console.WriteLine(intro);
                    Thread.Sleep(2000);
                }
                Console.Clear();

                //upgrade item dialogue

                Console.WriteLine("Thrain: 'Welcome to the Blacksmith!'...");
                Console.WriteLine("\n\t'Hit '1' to upgrade your sword...");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Upgrading your weapon...");

                }

            }

            static void VisitPotionMaker()
            {
                string[] potionMaker = new string[]
             {
                "Narrator: You visit the Potion Maker...",
                "\n\tYou pan around the room and see colorful bottles and strange herbs...",
                "\n\tYou see a hooded figure look up at you with glistening eyes...",
                "\nStranger: 'Hello sir'...",
                "\nElyisa Moonshade: 'My name is Elysia Moonshade'...",
                "\n\t'I can provide you with the most powerful concoctions of any kind...'",
                "\n\t'How may I help you?'..."
             };

                foreach (string intro1 in potionMaker)
                {
                    Console.WriteLine(intro1);
                    Thread.Sleep(2000);
                }
            }
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


    }
}