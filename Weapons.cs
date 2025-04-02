using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MCNR
{

	public class Weapon
	{
		public string Name { get; set; }                        //able to access and modify its value
		public int Damage { get; set; }                         //able to access and modify its value
		public int UpgradeLevel { get; set; }                   //able to access and modify its value
		public int UpgradeCost { get; set; }                    //able to access and modify its value
		public int MaxUpgradeLevel { get; set; } = 5;           //able to access and modify its value
		public Player player { get; set; }
		public Weapon(string name, int damage, int upgradeCost)
		{
			Name = name;

			Damage = damage;

			UpgradeLevel = 1; //sword starts at level 1

			UpgradeCost = upgradeCost; //cost to upgrade

		}



        public static void weapon()
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

    }
}
