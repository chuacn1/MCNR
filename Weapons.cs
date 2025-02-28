using System;
using System.Collections.Generic;
using System.Linq;
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
	}
