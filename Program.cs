using System.ComponentModel;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace MCNR
{
    internal class Program
    {
        //ARRAY FOR INVENTORIES
        static string[] items = new string[15];
        static int[] counts = new int[15];
        static int money = 0;
        static int enemyHP;
        static int playerHP;
        static int ore = 0;
        static int flower = 0;
        static int potion = 0;
        static int crystalflower = 0;
        static int specialsword = 0;
        static int correct = 0;
        public static Player player;

        //*****PLAYER NAME METHOD*****//
 
        public class Player
        {
            public string Name { get; set; }

            public Player(string name)
            {
                Name = name;
            }
        }
        //**************************************************//
            //*****HEALTH POTION METHODS*****//
            public class StrengthPotion
        {
            public string name { get; set; }
            public int increaseAmount { get; set; }
            public int cost { get; set; }
            public int maxUses { get; set; }
            public int currentUses { get; set; }

            //required material to craft this potion
            public static string requireMaterial = "Crystal Flower";
            public static int requiredQuantity = 1 + HealthPotion.requiredQuantity;
        }
        static void CraftStrengthPotion()
        {
            if (crystalflower >= StrengthPotion.requiredQuantity)
            {
                //deduct the material from the inventory
                crystalflower -= StrengthPotion.requiredQuantity;

                //create the potion and add it to the inventory
                StrengthPotion potion = new StrengthPotion
                {
                    name = "Strength Potion",
                    increaseAmount = 30
                };

                Console.WriteLine($"You crafted a {potion.name}! It will increase your max health by {potion.increaseAmount} HP");
                Console.WriteLine($"Remaining {StrengthPotion.requireMaterial}: {crystalflower}");
            }
            else
            {
                Console.WriteLine("You don't have enough Crystal Flowers to craft this potion.");
            }
            Console.ReadLine();
        }


        public class HealthPotion
        {
            //details for health potion
            public string name { get; set; }
            public int healingAmount { get; set; }
            public int Cost { get; set; }
            public int maxUses { get; set; } = 3;
            public int currentUses { get; set; }

            //required material to craft this potion
            public static string requiredMaterial = "Delicate Flower";
            public static int requiredQuantity = 1;
        }
        static void CraftPotion()
        {
            //check if the player has enough flowers to craft the potion
            if (flower >= HealthPotion.requiredQuantity)
            {
                //deduct the required materials from the inventory
                flower -= HealthPotion.requiredQuantity;

                //create the potion and add it to the inventory
                HealthPotion potion = new HealthPotion
                {
                    name = "Health Potion",
                    healingAmount = 20,  //set an appropriate healing amount
                };

                //add the potion to the inventory 
                //AddToInventory(potion.name);

                Console.WriteLine($"You crafted a {potion.name}! It heals for {potion.healingAmount} HP.");
                Console.WriteLine($"Remaining Delicate Flowers: {flower}");
            }
            else
            {
                Console.WriteLine("You don't have enough Delicate Flowers to craft a potion.");
            }
        }
        //**************************************************//

        //*****WEAPON METHODS*****//
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
        //**************************************************//

        //*****MAIN METHOD*****//
        static void Main(string[] args)
        {
            
            //InitializeInventory();
            //PrintInventory();
            //Introduction();
            //Tutorial();
            //InitializeInventory();
            //PrintInventory();
            //Introduction();
            //Tutorial();

            //EnteringTownAnimation();
            //Town();


            //EldrinDialogue();



            ////CavePath1OrPath2();
            ////CaveEnemyPath1();
            //CaveExitOrPath3();
            //CaveEnemyPath3();
            //////SpecialSword();
            //SpecialSwordDialogue();
            //EscapeCave();
            //EscapeCaveDialogue();

            //ForestPath1OrPath2();
            //ForestEnemyPath1();
            //ForestExitOrPath3();
            //ForestEnemyPath3();
            //SpecialFlower();
            //Exit();



            // ========= ACTUAL FLOW OF THE GAME FOR MAIN ========= //
            Introduction();
            Tutorial();               // missing tutorial for using inventory and using potions
            EnteringTownAnimation();
            Town();
            EldrinDialogue();
            //TutorialUsingPotionAndInventory();




            // not working properly //
            static int EnemyVsPlayer(int playerHP, ref int enemyHP)
            {
                Random rand = new Random();

                do
                {
                    //prompt player to attack or check inventory
                    Console.Write("Press 'A' to strike or 'I' to check your inventory: ");
                    string input = Console.ReadLine();

                    char choice = ' '; //declare choice outside of the input check

                    if (input.Length > 0) //checks if the input has at least one character
                    {
                        choice = input.ToLower()[0];
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }

                    //player Attack
                    if (choice == 'a')
                    {
                        Console.Beep(1000, 300);
                        int hitmiss = rand.Next(1, 5);
                        switch (hitmiss)
                        {
                            case 1:
                                Console.WriteLine($"Enemy HP: {enemyHP}");
                                Console.WriteLine($"Your HP: {playerHP}");
                                Console.WriteLine("Your swing goes wide, missing the enemy entirely!");
                                Console.WriteLine("0 damage\n");
                                Console.WriteLine("The enemy retaliates!\n");
                                Thread.Sleep(1500);
                                break;
                            case 2:
                                enemyHP -= 5;
                                Console.WriteLine($"Enemy HP: {enemyHP}");
                                Console.WriteLine($"Your HP: {playerHP}");
                                Console.WriteLine("You strike true!");
                                Console.WriteLine("5 damage dealt!\n");
                                Console.WriteLine("The enemy retaliates!\n");
                                Thread.Sleep(1500);
                                break;
                            case 3:
                                enemyHP -= 10;
                                Console.WriteLine($"Enemy HP: {enemyHP}");
                                Console.WriteLine($"Your HP: {playerHP}");
                                Console.WriteLine("A fierce blow!");
                                Console.WriteLine("10 damage dealt!\n");
                                Console.WriteLine("The enemy retaliates!\n");
                                Thread.Sleep(1500);
                                break;
                            default:
                                enemyHP -= 2;
                                Console.WriteLine($"Enemy HP: {enemyHP}");
                                Console.WriteLine($"Your HP: {playerHP}");
                                Console.WriteLine("You landed a glancing blow.");
                                Console.WriteLine("2 damage dealt!\n");
                                Console.WriteLine("The enemy retaliates!\n");
                                Thread.Sleep(1500);
                                break;
                        }
                    }
                    else if (choice == 'i')
                    {
                        PrintInventory();
                        continue;
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



                    //once enemy or player dies, stops loop
                } while (enemyHP > 0 && playerHP > 0);

                return playerHP;

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
                Player player = new Player(playersName);
                Console.Clear();

                string[] introDialogue = new string[]
                {
                    "Narrator: In the serene land of Eldoria, darkness begins to encroach, threatening the peace of its inhabitants...",
                    $"\n\tYou are {playersName}...",
                    "\n\tA budding hero!. Awakening to the call of adventure...",
                    "\n\tEquipped only with your bravery and a timeworn sword...",
                    "\n\tYour quest commences at the edge of your village...",
                    "\n\tWhere murmurs of a formidable foe...",
                    "\n\t'The Shadow Lord' cast a pall of fear across the land <enter>."
                };


                foreach (string words in introDialogue)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(2000);
                }
                Console.ReadLine();
                Console.Clear();

                string[] tutorialControlDialogue = new string[]
                {
                    "Narrator: You enter the realm...",
                    "\n\tPrepared to showcase your skills...",
                    "\n\tBefore you stands a training dummy, your initial challenge. To hone your combat skills <enter>"
                };


                foreach (string words in tutorialControlDialogue)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(2000);
                }
                //Console.Write("\nPress 'A' to strike!: ");
                Console.ReadLine();
                Console.Clear();

            }

            static void Tutorial()
            {
                enemyHP = 10;
                playerHP = 50;

                playerHP = EnemyVsPlayer(playerHP, ref enemyHP);

                if (enemyHP <= 0) //enemy dies
                {
                    Console.Beep(1000, 500);
                    Console.WriteLine("You have triumphed over the foe! <enter>");
                    Console.ReadLine();
                }
                if (playerHP <= 0) //player dies
                {
                    Console.Beep(400, 500);
                    Console.WriteLine("You have fallen in battle. <enter>");
                    Console.ReadLine();
                    Console.WriteLine("G A M E O V E R <enter>");
                    Console.ReadLine();
                    Environment.Exit(0);  //stop program
                }

                string[] tutorialInventoryDialogue2 = new string[]
                  {
                    "Narrator: With the enemy defeated...",
                    "\nYou discover a trove of spoils:",
                    "\n\t\tGleaming Coins...",
                    "\n\t\tDelicate flower...",
                    "\n\t\tSturdy piece of iron...",
                    "\n\t\tHealth Potion..."                  
                  };

                Console.Clear();


                foreach (string words in tutorialInventoryDialogue2)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(2000);
                }
                Console.WriteLine();
                Console.WriteLine("Gleaming Coins");
                Console.WriteLine("Delicate Flower");
                Console.WriteLine("Sturdy Iron");
                Console.WriteLine("Health Potion");
                Console.WriteLine();
                Console.WriteLine("\nPress 'P' to collect your loot!\n");
                char pick = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.Clear();

                money += 10;
                ore += 1;
                flower += 1;
                potion += 1;

                if (pick == 'P')
                {
                    AddCoins(10);

                    AddIron(1);

                    AddFlower(1);

                    AddPotion(1);

                    AddToInventory($"Gleaming Coins");       // 

                    AddToInventory($"Delicate Flower");      //

                    AddToInventory($"Sturdy Iron");          //

                    AddToInventory($"Health Potion");

                    Console.WriteLine("<enter>");
                    Console.ReadLine();

                    Console.Clear();

                    TutorialUsingPotionAndInventory();
                }

                else
                {
                    Console.WriteLine("Invalid. Press 'P' to collect your loot!");

                }
                Console.WriteLine("\nNarrator: Gather more flowers to purchase health potions at the Potion Maker");
                Console.WriteLine("\n\tCollect iron to upgrade your sword at the Blacksmith. <enter>");
                Console.ReadLine();
                Console.Clear();
            }

            static void TutorialUsingPotionAndInventory()
            {
                Console.WriteLine("Narrator: You should check your inventory to see if you have items that can aid you during the fight.");
                Thread.Sleep(2000);

                Console.WriteLine("\nNarrator: Remember, you earned a Health Potion in the previous battle. You can use that to heal yourself mid-fight if needed!");
                Thread.Sleep(2000);

                Console.WriteLine("\nNarrator: You can open your inventory at any time during battle by pressing 'I'. It's crucial to know what items you have available!");
                Thread.Sleep(2000);

                Console.Write("\nPress 'I' to open up Inventory: ");
                string temp = Console.ReadLine().ToLower();
                char open = Convert.ToChar(temp);

                if (open == 'i')
                {
                    Console.Clear();
                    PrintInventory();

                    Console.WriteLine("Narrator: Great! Now you know how to check your inventory.");
                    Thread.Sleep(2000);

                    Console.WriteLine("Narrator: Remember, during fights with enemies, it's crucial to use 'I' to access your items. You never know when a Health Potion might save you!");
                    Thread.Sleep(2000);

                    Console.WriteLine("\nNarrator: Now, let’s head to town and prepare for your next adventure! <enter>");
                    Console.ReadLine();
                    Console.Clear();

                    EnteringTownAnimation();
                }
                else
                {
                    Console.WriteLine("Invalid. <enter>");
                    Console.ReadLine();
                    Console.Clear();

                    TutorialUsingPotionAndInventory();
                }
            }

            static void UsingPotion()
            {
                Console.WriteLine("Press 3 for Health Potion");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 3)
                {
                    playerHP = 50;
                    potion -= 1;

                    Console.WriteLine($"Your health has been restored to {playerHP} points! <enter>");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine($"Enemy HP: {enemyHP}");
                    Console.WriteLine($"Your HP: {playerHP}");
                    Console.WriteLine("<enter>");
                    Console.ReadLine();
                    Console.Clear();
                }

            }

            static void UsingSpecialSword()
            {
                Console.WriteLine("Press 4 for Special Sword");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 4)
                {
                    specialsword -= 1;
                    enemyHP -= 100;

                    Console.WriteLine("You grip the hilt of your Sowrd Sword, feeling its power coursing through you.");
                    Thread.Sleep(2000);
                    Console.WriteLine("A brilliant flash of light erupts as the sword strikes your enemy.");
                    Thread.Sleep(2000);
                    Console.WriteLine($"The enemy staggers back, losing 100 health points! <enter>");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"Enemy HP: {enemyHP}");
                    Console.WriteLine($"Your HP: {playerHP}");
                    Console.WriteLine("<enter>");
                    Console.ReadLine();
                    Console.Clear();

                }
            }

            //*****ADD COINS METHOD*****//
            static void AddCoins(int amount)
            {
                // Ensure the coins are in the first index
                items[0] = "Gleaming Coins"; // Set item name for coins
                money = amount;
                counts[0] += amount; // Increment coin count


            }
            //**************************************************//

            //*****ADD IRON METHOD*****//
            static void AddIron(int amount)
            {
                //iron is added to second index
                items[1] = "Sturdy Iron"; //set item name for iron
                counts[1] += amount; //increment iron count
            }
            //**************************************************//

            //******ADD FLOWER METHOD*****//
            static void AddFlower(int amount)
            {
                //flower is added to third index
                items[2] = "Delicate Flower"; //set item name for flower
                counts[2] += amount; //increment flower count
            }
            //**************************************************//

            //*****ADD POTION METHOD*****//
            static void AddPotion(int amount)
            {
                items[4] = "Health Potion";
                counts[4] += amount;
            }

            static void AddSpecialSword(int amount)
            {
                items[4] = "Blade of Lumina";
                counts[4] += amount;
            }

            static void AddCrystalFlower(int amount)
            {
                items[5] = "Crystal Flower";
                counts[5] += amount;

            }

            //******ADD TO INVENTORY METHOD******//
            static void AddToInventory(string item) //when enemy drop loot call AddToInventory in method as shown in TutorialInventory!!!!!!
            {
                //check if the item already exists in the inventory
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == item)
                    {
                        //counts[i]++;
                        Console.WriteLine($"\n{item} count increased. Total count: {counts[i]} <enter>");
                        Console.ReadLine();
                        return;

                    }
                }

                //if item does not exist, find empty slot
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == null)
                    {
                        items[i] = item;
                        //counts[i] = 1;
                        Console.WriteLine($"\n{item} added to inventory. Total count: {counts[i]} <enter>");
                        Console.ReadLine();
                        return;

                    }
                }

                Console.WriteLine("Inventory full! Cannot add more items. <enter>");
                Console.ReadLine();
            }
            //**************************************************//

            //*****Initialize Inventory Method*****//
            static void InitializeInventory()
            {
                items[3] = "Trusty Sword"; //sword took up a slot
                counts[3] = 1;
            }
            //**************************************************//

            //*****Print Inventory Method*****//
            static void PrintInventory()
            {
                string border = new string('-', 60);
                Console.Clear();
                Console.WriteLine("Your Inventory:\n");
                Console.WriteLine(border);
                for (int i = 0; i < items.Length; i++)
                {
                    if (!string.IsNullOrEmpty(items[i]))
                    {
                        Console.WriteLine($"{items[i]}: {counts[i]}");
                    }
                }

                Console.WriteLine("\nPress enter to return to the game...");
                string input = Console.ReadLine();
                if (input != null)
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    return;
                }

            }
            //**************************************************//

            static void GameLoop()
            {
                bool gameRunning = true;

                while (gameRunning)
                {
                    Console.WriteLine("Press 'I' to view your inventory, or any key to continue the game");
                    char input = Console.ReadKey(true).KeyChar;

                    switch (input)
                    {
                        case 'I':
                            PrintInventory();
                            break;
                        case 'C':
                            return;
                            break;
                        case 'Q':
                            Console.WriteLine("Thanks for playing!");
                            gameRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid Input. Please press 'I', 'C' or 'Q'");
                            break;

                    }

                }
            }
            //*****Entering Town Animation*****//
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
            //**************************************************//

            //*****TOWN METHOD*****//
            static void Town()
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
                            VisitBlackSmith();
                            break;

                        case "2":
                            VisitPotionMaker();
                            break;

                        case "3":
                            EldrinDialogue();
                            break;

                        case "4":
                            PrintInventory();
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
            static void ReEnterTown()
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
                            VisitBlackSmith();
                            break;

                        case "2":
                            VisitPotionMaker();
                            break;

                        case "3":
                            EldrinDialogue();
                            break;

                        case "4":
                            PrintInventory();
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

            //*****VISIT BLACKSMITH METHOD*****//
            static void VisitBlackSmith()
            {
                Weapon playerWeapon = new Weapon("Trusty Sword", 10, 20);

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
                Console.WriteLine("\n\t1. Upgrade your sword");
                Console.WriteLine("\t2. Return to town");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    UpgradeWeapon(playerWeapon);

                }
                else if (choice == "2")
                {
                    ReEnterTown();
                }
                Console.Clear();
            }
            //**************************************************//

            //*****VISIT POTIONMAKER METHOD*****//
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
                    Thread.Sleep(1000);
                }
                Console.WriteLine("\nElysia: 'What potion are you thinking of brewing?'...");
                Console.WriteLine("\nHit '1' to craft a healing potion");
                Console.WriteLine("\nHit '2' to craft a strength potion");
                Console.Write("\nEnter '1' or '2': ");

                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                {
                    CraftPotion();
                }
                else if (choice == "2")
                {
                    CraftStrengthPotion();
                }



            }

            //**************************************************//

            //*****NPC DIALOGUE*****//
            static void EldrinDialogue()

            {
                string[] NPCDialogue = new string[]
                {
                    $"[Eldrin the wise]: Ahh, Hello {player.Name}...",
                    "\n\tYou have explored the Town of Eldoria...",
                    "\tFor your next quest...",
                    "\tYou must explore the Cave...",
                    "\tOr the forest...",
                    "\tWithin one of these areas is secret loot...",
                    "\tNow venture onwards and complete your quest!..."
                };

                foreach (string words in NPCDialogue)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(1000);
                }
                Console.Clear();

                EldrinPath();
            }
            //**************************************************//

            //*****ASK USER IF THEY ARE READY*****//
            static void EldrinPath()
            {
                Console.Clear();
                Console.Write("\nEnter 'yes' if you are prepared to move onwards with your quest, or 'no' if you need more time: ");
                string response = Console.ReadLine().ToLower();

                if (response == "yes")
                {
                    Console.Clear();
                    Console.WriteLine("\n[Eldrin the Wise]: Very well! May your courage shine bright. Prepare yourself well; the battle ahead will be fierce!");
                    BossEncounter();
                }
                else if (response == "no")
                {
                    Console.Clear();
                    Console.WriteLine("\n[Eldrin the Wise]: I thought so. The path ahead is fraught with danger.");
                    Thread.Sleep(2000);
                    Console.WriteLine("\n\t\tI advise you to practice your skills and gather loot from the enemies in the forest and cave.");
                    Thread.Sleep(2000);
                    Console.WriteLine("\n\t\tYou may also discover special items that will aid you in your upcoming battle.");
                    Thread.Sleep(2000);
                    Console.WriteLine("\n\t\tReturn when you feel stronger, and I’ll be here to guide you. <enter>");
                    Console.ReadLine();
                    Console.Clear();
                    CaveOrForest();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n[Eldrin the Wise]: It seems I didn’t quite understand your answer. Please tell me if you feel ready or not.");
                    EldrinPath();
                }
            }
            //**************************************************//

            //*****NPC WHEN PLAYER RETURNS*****//
            static void ReturnToEldrin()
            {
                string[] NPCDialogue = new string[]
                {
                    $"Eldrin the wise: Hello again {player.Name}...",
                    "Are you now ready to face maybe...",
                    "Your toughest opponent yet?..."
                };

                foreach (string words in NPCDialogue)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(1000);                  
                }
                Console.Clear();
                EldrinPath();
            }

            //This is where players choose to move forth on their quest or return to town to upgrade//
            static void CaveOrForest() //player will choose where he want to go cave or forest
            {
                Console.WriteLine("Which do you want to go Cave or Forest?: ");
                Console.WriteLine("\n\t1. Cave");
                Console.WriteLine("\n\t2. Forest");
                Console.WriteLine("\n\t3. Back to Town");
                Console.WriteLine("\n\t4. Back to Eldrin");
                Console.WriteLine("\n\t5. Check inventory");

                Console.Write("\nInput choice here --->  ");
                int decision = Convert.ToInt32(Console.ReadLine());

                //switch containing player decision
                switch (decision)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Entering the cave.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Entering the cave..");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Entering the cave...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Thread.Sleep(3000);
                        Console.Clear();
                        CavePath1OrPath2();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Entering the forest.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Entering the forest..");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Entering the forest...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        ForestPath1OrPath2();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Walking back.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Walking back..");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Walking back...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        ReEnterTown();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Walking back.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Walking back..");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Walking back...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        ReturnToEldrin();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Opening inventory.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Opening inventory..");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Opening inventory...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        PrintInventory();
                        break;

                }; //end of switch
            }

            static void CavePath1OrPath2()
            {
                Console.WriteLine("\nNarrator: You stand in the heart of the cave, surrounded by the echoes of dripping water and the scent of damp earth. Two distinct paths lie before you. \n\t Would you like to:");
                Console.WriteLine("\n\t1. Go to Path 1");
                Console.WriteLine("\n\t2. Go to Path 2");
                Console.WriteLine("\n\t0. Exit the Cave");
                Console.Write("\n\tEnter 1, 2 or 0: ");

                //read player input
                string choice = Console.ReadLine();
                Console.Clear();

                //process the players choice
                if (choice == "1")
                {
                    CaveEnemyPath1();
                }

                else if (choice == "2")
                {
                    SpecialSwordDialogue();
                }

                else if (choice == "0")
                {
                    CaveOrForest();
                }
                else
                {
                    Console.WriteLine("Invalid! <enter>");
                    Console.ReadLine();
                    Console.Clear();
                    CavePath1OrPath2();
                }

            }

            static void CaveExitOrPath3()
            {
                Console.WriteLine("\nNarrator: Would you like to:");
                Console.WriteLine("\n\t1. Go deeper into the cave");
                Console.WriteLine("\n\t2. Retrace back");
                Console.WriteLine("\n\t0. Exit the Cave");
                Console.Write("\nEnter 1, 2 or 0: ");

                //read player input
                string choice = Console.ReadLine();
                Console.Clear();

                //process the players choice
                if (choice == "1")
                {
                    CaveEnemyPath3();
                }

                else if (choice == "2")
                {
                    CavePath1OrPath2();
                }

                else if (choice == "0")
                {
                    CaveOrForest();
                }

            }

            static void ForestPath1OrPath2()
            {
                Console.WriteLine("\nNarrator: You find yourself in a serene glade deep within the forest, surrounded by towering trees and the gentle rustle of leaves. Two distinct paths lie before you. \n\t Would you like to:");
                Console.WriteLine("\n\t1. Go to Path 1");
                Console.WriteLine("\n\t2. Go to Path 2");
                Console.WriteLine("\n\t0. Exit the forest ");
                Console.Write("\nEnter 1, 2, or 0: ");

                string choice = Console.ReadLine();
                Console.Clear();

                //process the players choice
                if (choice == "1")
                {
                    SpecialFlower();
                }

                else if (choice == "2")
                {
                    ForestEnemyPath1();
                }

                else if (choice == "0")
                {
                    CaveOrForest();
                }



            }

            static void ForestExitOrPath3()
            {
                Console.WriteLine("\nNarrator: Would you like to:");
                Console.WriteLine("\n\t1. Go deeper into the forest");
                Console.WriteLine("\n\t2. Retrace back");
                Console.WriteLine("\n\t0. Exit the Forest");
                Console.Write("\nEnter 1, 2 or 0: ");

                //read player input
                string choice = Console.ReadLine();
                Console.Clear();

                //process the players choice
                if (choice == "1")
                {
                    ForestEnemyPath3();
                }

                else if (choice == "2")
                {
                    ForestPath1OrPath2();
                }

                else if (choice == "0")
                {
                    CaveOrForest();
                }

            }

            //*****CAVE METHOD******//
            static void CaveEnemyPath1()
            {

                string[] caveEnemyDialogue = new string[]
                {
                    "Narrator: As you delve deeper into the cave, the air grows colder and the shadows seem to shift around you...",
                    "\n\tSuddenly, a growl echoes through the darkness, and a menacing figure emerges from the shadows!",
                    "\nNarrator: It's a Cave Troll, towering above you with a fearsome glare!",
                    "\nCave Troll: 'You dare intrude in my domain?! Prepare to face my wrath!'",
                    "\nNarrator: With adrenaline pumping through your veins, you ready your sword. The battle is about to begin!",
                    "\n\tWill you fight bravely or flee into the darkness?"
                };

                foreach (string line in caveEnemyDialogue)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(2000);
                }

                Console.Clear();

                enemyHP = 20;

                playerHP = EnemyVsPlayer(playerHP, ref enemyHP);

                if (enemyHP <= 0)
                {
                    Console.Beep(1000, 500);
                    Console.WriteLine("You have defeated the Cave Troll! <enter>");
                    Console.ReadLine();
                    //here we will add rewards or further actions
                }
                else if (playerHP <= 0) //maybe we make this able to retry the enemy??
                {
                    Console.Beep(400, 500);
                    Console.WriteLine("You have fallen in battle against the Cave Troll <enter>.");
                    Console.ReadLine();

                    Console.WriteLine("G A M E O V E R <enter>");
                    Console.ReadLine();
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
                ore += 1;

                if (pick == 'P')
                {

                    AddCoins(10);

                    AddIron(1);

                    AddToInventory("Gleaming Coins");       // 

                    AddToInventory("Sturdy Iron");          //

                    Console.WriteLine($"Coins collected: {money}");
                    Console.WriteLine("<enter>");
                    Console.ReadLine();
                    Console.Clear();
                    CaveExitOrPath3();
                }

                else

                {
                    Console.WriteLine("Invalid. Press 'P' to collect your loot!");

                }



            }

            static void CaveEnemyPath3()
            {

                enemyHP = 20;

                string[] caveEnemyDialogue = new string[]
                {
                        "Narrator: As you navigate through the winding passages of the cave, a strange shimmering light catches your eye... ",
                        "\n\tSuddenly, the ground trembles, and a massive creature emerges from the shadows!",
                        "\nNarrator: It's a Crystal Golem, its body adorned with glimmering gems that sparkle ominously!",
                        "\nCrystal Golem: 'You dare disturb my slumber?! Prepare to be crushed!'",
                        "\nNarrator: Heart racing, you grip your weapon tightly. The confrontation is imminent!",
                        "\n\tWill you stand your ground or try to escape?"
                };

                foreach (string line in caveEnemyDialogue)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(2000);
                }

                Console.Clear();


                playerHP = EnemyVsPlayer(playerHP, ref enemyHP);
                if (enemyHP <= 0)
                {
                    Console.Beep(1000, 500);
                    Console.WriteLine("You have defeated the Crystal Golem! <enter>");
                    Console.ReadLine();

                }
                else if (playerHP <= 0)
                {
                    Console.Beep(400, 500);
                    Console.WriteLine("You have fallen in battle against the Crystal Golem. <enter>");
                    Console.WriteLine("G A M E O V E R <enter>");
                    Environment.Exit(0);
                }
                else
                {
                    // In case of some unexpected outcome, though unlikely
                    Console.WriteLine("The battle ended unexpectedly. <enter>");
                    Console.ReadLine();
                    CaveEnemyPath3();
                }

                Console.WriteLine("Press 'P' to collect your loot!\n");
                char pick = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.Clear();

                money += 10; // player earns 10 coins
                ore += 2;

                if (pick == 'P')
                {
                    AddCoins(10);
                    AddIron(2);
                    AddToInventory("Shimmering Coins");
                    AddToInventory("Sturdy Iron");

                    Console.WriteLine($"\nCoins collected: {money}");
                    Console.WriteLine("<enter>");
                    Console.ReadLine();
                    Console.Clear();
                    DeadEndCave();
                }
                else
                {
                    Console.WriteLine("Invalid. Press 'P' to collect your loot!");
                    Console.ReadLine();
                }
            }

            static void DeadEndCave()
            {
                Console.WriteLine("Narrator: You've reached a dead end. The darkness surrounds you, and the only way out is to retrace your steps. \nPress 'E' to exit the cave and return to safety.");
                string exit = Console.ReadLine().ToLower();

                if (exit == "e")
                {
                    Console.Clear();
                    Console.WriteLine("Exiting Cave.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Exiting Cave..");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Exiting Cave...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Thread.Sleep(2000);

                    CaveOrForest();

                }

                else
                {
                    Console.WriteLine("Invalid. Press 'E' to exit the cave");
                    DeadEndCave();
                }
            }

            static void DeadEndForest()
            {
                Console.WriteLine("Narrator: You've reached a quiet clearing in the forest. Tall trees loom around you, and a sense of stillness fills the air. \nPress 'E' to retrace your steps and return to safety.");
                string exit = Console.ReadLine().ToLower();

                if (exit == "e")
                {
                    Console.Clear();
                    Console.WriteLine("Retracing your steps through the forest.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Retracing your steps through the forest..");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Retracing your steps through the forest...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Thread.Sleep(2000);

                    CaveOrForest();
                }
                else
                {
                    Console.WriteLine("Invalid. Press 'E' to retrace your steps.");
                    DeadEndForest();
                }
            }

            static void SpecialSwordDialogue()
            {
                //dialogue when the player finds the chest
                Console.WriteLine("Narrator: As you explore the depths of the cave, you stumble upon an ancient chest, its surface adorned with intricate carvings...");
                Thread.Sleep(2000);
                Console.WriteLine("\nNarrator: Curiosity piqued, you kneel before the chest and notice a strange inscription on the lock.");
                Thread.Sleep(2000);
                SpecialSwordGuess();
            }

            static void SpecialSwordGuess()
            {
                Console.WriteLine("\nNarrator: It reads: 'To reveal the power within, speak the word of light.'");
                Thread.Sleep(2000);

                //hint for the passcode
                Console.WriteLine("\nNarrator: You think for a moment. Perhaps the answer lies in the very essence of what you seek. It's a simple word related to illumination...");
                Console.WriteLine("\nType your guess:");

                string passcode = "LIGHT"; //correct passcode
                bool chestOpened = false;

                string playerGuess = Console.ReadLine().ToUpper();

                if (playerGuess == passcode)
                {
                    Console.Clear();
                    chestOpened = true;
                    Console.WriteLine("\nNarrator: The chest creaks open as the passcode is accepted!");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nInside, you find a magnificent sword, its blade shimmering with a faint, ethereal glow.");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nNarrator: This is the Blade of Lumina, said to be forged by the celestial smiths of old... <enter>");
                    Console.ReadLine();
                    Console.Clear();

                    ContinueWithSpecialSwordDialogue();
                }
                else
                {
                    Console.WriteLine("\nNarrator: The lock remains steadfast. Perhaps you should think of something brighter... Try again <enter>");
                    Console.ReadLine();
                    Console.Clear();
                    SpecialSwordClaim();
                }
            }

            static void ContinueWithSpecialSwordDialogue()
            {
                //the rest of the dialogue about the special sword
                string[] specialSwordDialogue =
                {
                    "Narrator: This ancient relic, the Blade of Lumina, pulses with magical energy, a testament to its storied past.",
                    "\nNarrator: Legends say that this sword possesses great power, but it can only be wielded once.",
                    "\nNarrator: As you hold the blade, you feel a profound connection, as if it recognizes your bravery and desire to protect the innocent.",
                    "\nNarrator: Will you claim it as your own?"
                };

                foreach (string line in specialSwordDialogue)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(2000);
                }

                Console.Clear();
                SpecialSwordClaim();
            }

            static void SpecialSwordClaim()
            {

                // Prompt to collect the sword
                Console.WriteLine("\nPress 'C' to claim the Blade of Lumina and add it to your inventory!\n");
                char pick = Convert.ToChar(Console.ReadLine().ToUpper());

                if (pick == 'C')
                {
                    specialsword += 1;
                    AddSpecialSword(1);
                    AddToInventory("Blade of Lumina");
                    Console.WriteLine("\nNarrator: You grasp the sword tightly, feeling its power resonate through you. The Blade of Lumina is now yours!");
                    Console.WriteLine("\n\tRemember, this sword can only be used once, so choose your moment wisely! <enter>");
                    Console.ReadLine();
                    Console.Clear();
                    EscapeCave();
                }
                else
                {
                    Console.WriteLine("Invalid choice. The sword remains in the chest, waiting for a worthy hero. <enter>");
                    Console.ReadLine();
                    Console.Clear();
                    SpecialSwordClaim();
                }
            }

            static void EscapeCaveDialogue()
            {
                string[] caveEscapeDialogue = new string[]
                {
                      "Narrator: As you venture deeper into the cave, the air grows thick and heavy. A sudden realization hits you—there's no oxygen left in this part of the cave!",
                      "\n\tJust then, a massive figure blocks your path. It's the Guardian of the Cave!",
                      "\nGuardian: You have crossed into the danger zone. For your recklessness, you must answer my riddle to pass!",
                      "\nNarrator: You feel the weight of the moment—answer correctly, and you may proceed. Fail, and you may never escape this cave... <enter>"
                };
                foreach (string words in caveEscapeDialogue)
                {
                    Console.WriteLine(words);
                    Thread.Sleep(2000);
                }

                Console.ReadLine();
                Console.Clear();
                EscapeCave();
            }

            static void EscapeCave()
            {

                Console.WriteLine("Guardian: So, the riddle is this: Convert the binary 10000001 into a decimal!");
                int deci = Convert.ToInt32(Console.ReadLine());

                if (deci == 129)
                {
                    Console.WriteLine("\nGuardian: 'Correct! You may proceed and DO NOT ever come back.'");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nNarrator: With a sense of relief, you step past the Guardian and exit the cave... <enter>");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Exiting Cave.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Exiting Cave..");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Exiting Cave...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Thread.Sleep(1000);
                    CaveOrForest();

                }
                else
                {
                    Console.WriteLine("\nGuardian: 'Incorrect! You have sealed your fate...'");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nNarrator: The Guardian raises his hand, and darkness engulfs you. You perish in the cave... <enter>");
                    Console.ReadLine();
                    Console.WriteLine("G A M E  O V E R <enter>");
                    Console.ReadLine();
                    Environment.Exit(0);

                }


            }

            //*****FOREST METHOD******//
            static void ForestEnemyPath1()
            {
                string[] flowerBiomeDialogue = new string[]
                {
                    "Narrator: As you wander through the vibrant flower fields, a sweet fragrance fills the air...",
                    "\n\tSuddenly, a rustle in the blossoms catches your attention, and a colorful figure emerges!",
                    "\nNarrator: It's a Flower Guardian, radiating with a gentle glow and a watchful gaze!",
                    "\nPetal Wraith: 'You dare tread in my enchanted garden?! Prepare to be tested!'",
                    "\nNarrator: With your heart racing, you ready your staff. The challenge is about to begin!",
                    "\n\tWill you face thePetal Wraith bravely or retreat into the flowers?"
                };

                foreach (string line in flowerBiomeDialogue)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(2000);
                }

                Console.Clear();

                enemyHP = 20;



                playerHP = EnemyVsPlayer(playerHP, ref enemyHP);
                if (enemyHP <= 0)
                {
                    Console.Beep(1000, 500);
                    Console.WriteLine("You have defeated the Petal Wraith! <enter>");

                }
                else if (playerHP <= 0)
                {
                    Console.Beep(400, 500);
                    Console.WriteLine("You have fallen in battle against the Petal Wraith. <enter>");
                    Console.WriteLine("G A M E O V E R <enter>");
                    Environment.Exit(0);
                }
                else
                {
                    // In case of some unexpected outcome, though unlikely
                    Console.WriteLine("The battle ended unexpectedly.");
                }

                Console.WriteLine("Press 'P' to collect your loots!\n");
                char pick = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.Clear();

                money += 10;

                if (pick == 'P')
                {
                    AddCoins(10);

                    AddToInventory("Gleaming Coins");
                    AddToInventory("Delicate Flower");

                    Console.WriteLine($"Coins collected: {money} <enter>");
                    Console.ReadLine();
                    ForestExitOrPath3();
                }
                else
                {
                    Console.WriteLine("Invalid. Press 'P' to collect your loots!");
                }

            }

            static void ForestEnemyPath3()
            {
                string[] flowerBiomeDialogue = new string[]
                {
                    "Narrator: As you wander through the colorful flower fields, the vibrant blooms dance in the breeze...",
                    "\n\tSuddenly, the ground shakes, and a colossal creature bursts through the petals!",
                    "\nNarrator: It's a Blooming Behemoth, its massive form covered in lush flowers and vines!",
                    "\nBlooming Behemoth: 'You dare intrude upon my garden?! Prepare to face my wrath!'",
                    "\nNarrator: Heart racing, you grip your staff tightly. The confrontation is imminent!",
                    "\n\tWill you stand your ground or try to escape?"
                };

                foreach (string line in flowerBiomeDialogue)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(2000);
                }

                Console.Clear();

                enemyHP = 20; // Adjusted enemy HP for balance             

                playerHP = EnemyVsPlayer(playerHP, ref enemyHP);
                if (enemyHP <= 0)
                {
                    Console.Beep(1000, 500);
                    Console.WriteLine("You have defeated the Blooming Behemoth! <enter>");
                    Console.ReadLine();
                }
                else if (playerHP <= 0)
                {
                    Console.Beep(400, 500);
                    Console.WriteLine("You have fallen in battle against the Blooming Behemoth. <enter>");
                    Console.ReadLine();
                    Console.WriteLine("G A M E O V E R <enter>.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("The battle ended unexpectedly.");
                }

                Console.WriteLine("Press 'P' to collect your rewards!\n");
                char pick = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.Clear();

                money += 10; // Player earns 10 coins

                if (pick == 'P')
                {
                    AddCoins(10);
                    AddToInventory("Gleaming Coins");
                    AddToInventory("Delicate Flower");

                    Console.WriteLine($"Coins collected: {money} <enter>");
                    Console.ReadLine();
                    Console.Clear();
                    DeadEndForest();
                }
                else
                {
                    Console.WriteLine("Invalid. Press 'P' to collect your rewards!");
                }

            }

            static void RiddleOne()
            {
                Console.Clear();


                // First Riddle
                Console.WriteLine("Flower Angel: 'Very well! Here is your first riddle...'");
                Console.WriteLine("I rise with the dawn and set with the night, I give warmth and light, but I’m not a fire’s might. What am I?");
                string ans1 = Console.ReadLine().ToUpper();

                if (ans1 == "THE SUN" || ans1 == "SUN" || ans1 == "A SUN")
                {
                    correct++;
                    Console.Clear();
                    Console.WriteLine("The air around you shimmers with approval as the Flower Angel smiles warmly.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Flower Angel: 'You have proven your worthiness for the first riddle!'");
                    Thread.Sleep(2000);
                    Console.WriteLine("The path ahead glows with radiant light, beckoning you to continue.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Flower Angel: 'Alas, brave traveler, your answer is not correct.'");
                    Thread.Sleep(2000);
                    Console.WriteLine("Narrator: A shadow of doubt crosses your mind. But do not be disheartened; every challenge is a lesson.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Flower Angel: 'Take a moment to reflect. You have one more chance.'");
                    Thread.Sleep(2000);
                }
            }

            static void RiddleTwo()
            {
                Console.WriteLine("Flower Angel: 'Now, for your next riddle...'");
                Thread.Sleep(2000);
                Console.WriteLine("I bloom in the spring, bringing joy to the eye. I can symbolize love, yet I wither and die. What am I?");
                string ans2 = Console.ReadLine().ToUpper();

                if (ans2 == "A FLOWER" || ans2 == "FLOWER" || ans2 == "FLOWERS")
                {
                    correct++;
                    Console.WriteLine("The air around you shimmers with approval as the Flower Angel smiles warmly.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Flower Angel: 'You have proven your worthiness for the second riddle!'");
                    Thread.Sleep(2000);
                    Console.WriteLine("The petals around you dance in the breeze, celebrating your success.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Flower Angel: 'Alas, brave traveler, your answer is not correct.'");
                    Thread.Sleep(2000);
                    Console.WriteLine("Narrator: The vibrant colors around you dim slightly, reminding you of the path yet to take.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Flower Angel: 'Do not be discouraged; every challenge teaches us something valuable.'");
                    Thread.Sleep(2000);
                }
            }
           
            static void SpecialFlower()
            {
                string[] specialFlowerDialogue = new string[]
                {
                        "Narrator: As you step into the clearing, the air sparkles with golden light, and vibrant flowers bloom all around you...",
                        "\n\tYou feel a warm presence envelop you, and a gentle voice resonates through the air.",
                        "\nFlower Angel: 'Welcome, brave traveler. You have entered a sacred space, illuminated by love and nature.'",
                        "\n\tThe Flower Angel appears before you, her wings shimmering with the colors of the rainbow.",
                        "\nFlower Angel: 'Before you can approach the special flower, you must prove your worthiness. Answer my riddles, and you shall gain access.'",
                        "\n\tThe air thickens with anticipation as the Flower Angel continues. <enter>"
                };

                foreach (string line in specialFlowerDialogue)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(2000);
                }

                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Flower Angel: 'Are you ready to accept the challenge of the Healing Riddles?'");
                Console.WriteLine("\nPress 'Y' to accept or 'N' to back away.");
                char response = Convert.ToChar(Console.ReadLine().ToUpper());

                if (response == 'Y')
                {
                    RiddleOne();

                    Console.Clear();

                    RiddleTwo();

                    if (correct > 0)
                    {
                        if (correct == 1)
                        {
                            Console.WriteLine("Flower Angel: 'Ah, you have successfully answered one riddle!'");
                            Thread.Sleep(2000);
                            Console.WriteLine("Flower Angel: 'You shall receive a Crystal Flower, a token of your wisdom.'");
                            Thread.Sleep(2000);
                            Console.WriteLine("Flower Angel: 'Take it to the Potion Maker, where you can craft a healing potion that will increase your strength.'");
                            Console.WriteLine("CrystalFlower");
                            Console.WriteLine();
                            Console.WriteLine("Press 'P' to collect your loot!\n");
                            char pick = Convert.ToChar(Console.ReadLine().ToUpper());
                            Console.Clear();

                            money += 10;
                            flower += 1;
                            crystalflower += 1;

                            if (pick == 'P')
                            {
                                AddFlower(1);

                                AddCrystalFlower(1);

                                AddCoins(10);

                                AddToInventory("Delicate Flower");

                                Console.WriteLine($"Coins collected: {money} <enter>");

                                Console.WriteLine($"Flowers collected: {flower} <enter>");

                                Console.WriteLine($"Crystal flower collected: {crystalflower} <enter>");
                                Console.ReadLine();

                                CaveOrForest();
                            }
                        }
                        else if (correct == 2)
                        {
                            Console.WriteLine("Flower Angel: 'Incredible! You have answered both riddles with grace!'");
                            Thread.Sleep(2000);
                            Console.WriteLine("Flower Angel: 'You are blessed with 2 Crystal flowers, symbols of your exceptional insight.'");
                            Thread.Sleep(2000);
                            Console.WriteLine("Flower Angel: 'Use them wisely at the Potion Maker to create a powerful potion that will grant you double the strength.'");
                            Console.WriteLine("Delicate Flower x10");
                            Console.WriteLine();
                            Console.WriteLine("Press 'P' to collect your loot!\n");

                            char picked = Convert.ToChar(Console.ReadLine().ToUpper());
                            Console.Clear();

                            money += 10;
                            flower += 1;
                            crystalflower += 2;

                            if (picked == 'P')
                            {
                                AddFlower(1);

                                AddCrystalFlower(2);

                                AddCoins(10);

                                AddToInventory("Crystal Flower");
                                Console.ReadLine();

                                Console.WriteLine($"Coins collected: {money}  <enter>");
                                Console.ReadLine();

                                Console.WriteLine($"Flowers collected: {flower} <enter>");
                                Console.ReadLine();

                                Console.WriteLine($"Crystal flower collected: {crystalflower} <enter>");
                                Console.ReadLine();
                                CaveOrForest();
                            }
                        }
                    }
                }
                else if (response == 'N')
                {
                    Console.WriteLine("\nFlower Angel: 'Remember, only those who seek the truth may find the path to love. Return when you are ready. <enter>");
                    Console.ReadLine();
                    Console.Clear();
                    ForestPath1OrPath2();
                }
            }

            //*****BIGBOSS METHOD******//
            static void BossEncounter()
            {
                Console.Clear();
                Console.WriteLine("Narrator: As you step into the boss arena, the shadows coalesce into a massive, ominous form...");
                Thread.Sleep(3000);

                Console.WriteLine("\nNarrator: The Big Boss looms over you, a menacing figure shrouded in darkness.");
                Thread.Sleep(2000);
                Console.WriteLine("\nBoss: Who dares enter my domain? You think you can challenge the darkness I wield?");
                Thread.Sleep(2000);
                Console.WriteLine("\nPrepare to be crushed beneath my might! <enter>");
                Console.ReadLine();

                // Player's response to the boss
                Console.Clear();
                Console.WriteLine("\nNarrator: You stand firm, heart racing. “I will not back down! The people of Eldoria will be free from your tyranny!”");
                Thread.Sleep(2000);
                Console.WriteLine("\nNarrator: The Big Boss lets out a deep, thunderous laugh. “Foolish child! You will soon learn the true meaning of despair!”");
                Thread.Sleep(2000);

                Console.WriteLine("\nNarrator: The air thickens with tension as the battle begins... <enter>");
                Console.ReadLine();
                Console.Clear();

                // Call your battle method here
                StartBossBattle();

                if (enemyHP <= 0)
                {
                    Console.Beep(1000, 500);
                    Console.WriteLine("Narrator: With one final, decisive blow, you shatter the Big Boss into pieces!");
                    Console.WriteLine("\nNarrator: The monstrous shadow that plagued the land begins to dissolve, releasing a burst of light. <enter>");
                    Console.ReadLine();

                    Console.WriteLine("Narrator: You stand victorious, heart pounding, as the echoes of your triumph fill the air.");
                    Console.WriteLine("\nNarrator: The townspeople, having witnessed the battle from a distance, rush toward you with cheers and applause! <enter>");
                    Console.ReadLine();
                    Console.Clear();
                    Thread.Sleep(2000);
                    Console.WriteLine("Town: You did it! You defeated the Blooming Behemoth!” they shout, their faces alight with joy.");
                    Console.WriteLine("\nNarrator: Children dance around you, and the elders bow in gratitude.");
                    Console.WriteLine("\nNarrator: Your name will be sung in songs for generations to come!\n");

                    Console.WriteLine("You are a true hero of Eldoria! <enter>");
                    Console.ReadLine();
                    Console.Clear();

                    Win();
                }
                else if (playerHP <= 0)
                {
                    Console.Beep(400, 500);
                    Console.WriteLine("As the dust settles, you collapse from your wounds, defeated by the Blooming Behemoth.");
                    Console.WriteLine("The townspeople look on in despair, mourning the loss of their champion.");
                    Console.WriteLine("G A M E O V E R <enter>.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("The battle ended unexpectedly.");
                }
            }

            static void StartBossBattle()
            {
                Random rand = new Random();
                int playerHP = 1000;

                int bossHP = 200;
                do
                {
                    // Prompt player to attack or check inventory
                    Console.Write("Press 'A' to strike at the Big Boss or 'I' to check your inventory: ");
                    string input = Console.ReadLine();

                    char choice = ' '; // Declare choice outside of the input check

                    if (input.Length > 0) // Checks if the input has at least one character
                    {
                        choice = input.ToLower()[0];
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }

                    // Player Attack
                    if (choice == 'a')
                    {
                        Console.Beep(1000, 300);
                        int hitmiss = rand.Next(1, 5);
                        switch (hitmiss)
                        {
                            case 1:
                                Console.WriteLine($"Big Boss HP: {bossHP}");
                                Console.WriteLine($"Your HP: {playerHP}");
                                Console.WriteLine("Your swing goes wide, missing the Big Boss entirely!");
                                Console.WriteLine("0 damage dealt.\n");
                                Console.WriteLine("The Big Boss chuckles darkly, readying an attack...\n");
                                Thread.Sleep(1500);
                                break;
                            case 2:
                                bossHP -= 5;
                                Console.WriteLine($"Big Boss HP: {bossHP}");
                                Console.WriteLine($"Your HP: {playerHP}");
                                Console.WriteLine("You strike true! Your weapon glints in the dim light.");
                                Console.WriteLine("5 damage dealt!\n");
                                Console.WriteLine("The Big Boss snarls in fury!\n");
                                Thread.Sleep(1500);
                                break;
                            case 3:
                                bossHP -= 10;
                                Console.WriteLine($"Big Boss HP: {bossHP}");
                                Console.WriteLine($"Your HP: {playerHP}");
                                Console.WriteLine("A fierce blow! You feel the ground shake as your strike lands.");
                                Console.WriteLine("10 damage dealt!\n");
                                Console.WriteLine("The Big Boss roars in pain!\n");
                                Thread.Sleep(1500);
                                break;
                            default:
                                bossHP -= 2;
                                Console.WriteLine($"Big Boss HP: {bossHP}");
                                Console.WriteLine($"Your HP: {playerHP}");
                                Console.WriteLine("You landed a glancing blow, but the Big Boss is still standing.");
                                Console.WriteLine("2 damage dealt!\n");
                                Console.WriteLine("The Big Boss glares at you, unfazed...\n");
                                Thread.Sleep(1500);
                                break;
                        }
                        if (bossHP <= 200 && bossHP > 100)
                        {
                            Console.WriteLine("The Big Boss staggers slightly, but quickly regains composure.");
                            Console.WriteLine("“Is that all you’ve got? I will not fall so easily!”\n");
                            Thread.Sleep(1500);
                        }
                        else if (bossHP <= 100 && bossHP > 50)
                        {
                            Console.WriteLine("The Big Boss is visibly weakened, breathing heavily.");
                            Console.WriteLine("“You may have strength, but you lack resolve!”\n");
                            Thread.Sleep(1500);
                        }
                        else if (bossHP <= 50)
                        {
                            Console.WriteLine("The Big Boss lets out a furious roar, clearly enraged.");
                            Console.WriteLine("“I will not let you take my throne! Prepare for my final attack!”\n");
                            Thread.Sleep(1500);
                        }
                    }
                    else if (choice == 'i')
                    {
                        PrintInventory();
                        continue;
                    }

                    // Big Boss Attack
                    Console.Beep(800, 300);
                    int misshit = rand.Next(1, 5);
                    switch (misshit)
                    {
                        case 1:
                            Console.WriteLine($"Big Boss HP: {bossHP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("The Big Boss swings wildly, missing you completely!");
                            Console.WriteLine("0 damage dealt.\n");
                            Console.WriteLine("You sense the tension in the air...\n");
                            Console.WriteLine("Press Enter for your turn");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            playerHP -= 10;
                            Console.WriteLine($"Big Boss HP: {bossHP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("The Big Boss strikes with a powerful blow!");
                            Console.WriteLine("5 damage taken.\n");
                            Console.WriteLine("You stagger back, barely holding your ground!\n");
                            Console.WriteLine("Press Enter for your turn");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            playerHP -= 20;
                            Console.WriteLine($"Big Boss HP: {bossHP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("The Big Boss slams you with a mighty fist!");
                            Console.WriteLine("10 damage taken.\n");
                            Console.WriteLine("You feel the weight of despair press down on you!\n");
                            Console.WriteLine("Press Enter for your turn");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        default:
                            playerHP -= 50;
                            Console.WriteLine($"Big Boss HP: {bossHP}");
                            Console.WriteLine($"Your HP: {playerHP}");
                            Console.WriteLine("The Big Boss lands a glancing blow.");
                            Console.WriteLine("2 damage taken.\n");
                            Console.WriteLine("You brace yourself for the next attack...\n");
                            Console.WriteLine("Press Enter for your turn");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }

                    // Once enemy or player dies, stops loop
                } while (bossHP > 0 && playerHP > 0);
            }

            static void Win()
            {
                Console.Clear();
                Console.Beep(1000, 500);

                Console.WriteLine("Narrator: As the cheers of the townspeople fill the air, you take a moment to bask in your victory.");
                Thread.Sleep(2000);

                Console.WriteLine("Narrator: The shadows that once haunted Eldoria have been dispelled, and peace has returned to the land.");
                Thread.Sleep(2000);

                Console.WriteLine("Narrator: Your courage and strength have become legend, and your name will be remembered in tales for generations.");
                Thread.Sleep(2000);

                Console.WriteLine("Narrator: This is the end of your journey, brave hero. You have faced the darkness and emerged triumphant.");
                Thread.Sleep(2000);

                Console.WriteLine("Narrator: Congratulations on completing your quest and winning the game!");
                Thread.Sleep(2000);

                Console.WriteLine("Press Enter to exit the game.");
                Console.ReadLine();
                Environment.Exit(0);
            }

        }
    }
}
    






