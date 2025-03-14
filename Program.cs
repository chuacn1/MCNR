using System.ComponentModel;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using mine;

namespace MCNR
{
    internal class Program
    {
        //ARRAY FOR INVENTORIES
        static string[] items = new string[15];
        static int[] counts = new int[15];
        static int enemyHP;
        public static Player player;
        public static town town;

        public static Narration narration;

        //*****PLAYER NAME METHOD*****//
 
        
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
            if (player.InventoryItemCount("crystalflower") >= StrengthPotion.requiredQuantity)
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

      

        
        //**************************************************//

        //*****MAIN METHOD*****//
        static void Main(string[] args)
        {



            // ========= ACTUAL FLOW OF THE GAME FOR MAIN ========= //
            Narration.SplashScreen();
            Narration.IntroductionDialogue();
            Narration.TutorialControlDialogue();
            //EnemyVsPlayer
            Tutorial();    // missing tutorial for using inventory and using potions // Please refer to Narration and call accordingly for dialogues
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

            
            static void Weapon()
            {
                string weaponchoice = Console.ReadLine();
                    Console.Clear();
               Console.WriteLine("\n\tPlease choose carefully");
                    Console.WriteLine("\n\t1) Special Sword");
                    Console.WriteLine("\n\t2) Battle Axe");
                    Console.WriteLine("\n\t3) Sharpened Dagger");

                    switch (weaponchoice)
                {
                    case "1":
                        Console.WriteLine("You have chosen the Special Sword! Prepare for battle.");
                        break;
                    case "2":
                        Console.WriteLine("You have chosen the Battle Axe! It's time to fight fiercely.");
                        break;
                    case "3":
                        Console.WriteLine("You have chosen the Sharpened Dagger! Stealth is your ally.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid weapon.");
                        break;
                }
            }

              
            static void Tutorial()
            {
                enemyHP = 1;
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
                string userInput = Console.ReadLine();//  separated into two lines. 
                char UserChar = userInput[0]; // Taking the first character from the userInput rather than try parse etc. 
                Console.Clear();

                money += 10;
                ore += 1;
                flower += 1;
                potion += 1;

                switch (UserChar)
                {
                    case 'P' or 'p':
                        AddCoins(10);
                        AddIron(1);
                        AddFlower(1);
                        AddPotion(1);
                        AddToInventory("Gleaming Coins");
                        AddToInventory("Delicate Flower");
                        AddToInventory("Sturdy Iron");
                        AddToInventory("Health Potion");

                        Console.WriteLine("<enter>");
                        Console.ReadLine();
                        Console.Clear();

                        TutorialUsingPotionAndInventory();
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please press 'P' to collect your loot.");
                        break;
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
                    Thread.Sleep(1500);

                    Console.WriteLine("Narrator: Remember, during fights with enemies, it's crucial to use 'I' to access your items. You never know when a Health Potion might save you!");
                    Thread.Sleep(1500);

                    Console.WriteLine("\nNarrator: Now, let’s head to town and prepare for your next adventure! <enter>");
                    Console.ReadLine();
                    Console.Clear();

                    Town.EnteringTownAnimation();
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
                    Thread.Sleep(1500);
                    Console.WriteLine("A brilliant flash of light erupts as the sword strikes your enemy.");
                    Thread.Sleep(1500);
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

            //**************************************************//

            
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
                    Thread.Sleep(1500);
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
                    Town.ReEnterTown();
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

                Console.Clear();  //clear screen after potion maker dialogue

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
                    Thread.Sleep(1500);
                    Console.WriteLine("\n\t\tI advise you to practice your skills and gather loot from the enemies in the forest and cave.");
                    Thread.Sleep(1500);
                    Console.WriteLine("\n\t\tYou may also discover special items that will aid you in your upcoming battle.");
                    Thread.Sleep(1500);
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
                        Town.ReEnterTown();
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

        }
    }
}
    






