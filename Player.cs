using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCNR
{
    public class Player
    {
        public string Name { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int BaseDamage { get; set; }
        public int BaseDefense { get; set; }
        public int BaseAgility { get; set; }
        public List<string> Inventory { get; set; }
        public int Money { get; set; }

        public Player(string name, int maxHp, int currentHp, int baseDamage, int baseDefense, int baseAgility, List<string> inventory, int money)
        {
            Name = name;
            MaxHp = maxHp;
            CurrentHp = currentHp;
            BaseDamage = baseDamage;
            BaseDefense = baseDefense;
            BaseAgility = baseAgility;
            Inventory = inventory;
            Money = money;
        }
        public int InventoryItemCount(string ItemName)
        {
            int ItemCount = 0;
            foreach (var item in Inventory)
            {
                if (item == ItemName)
                {
                    ItemCount += 1;
                }
            }
            Console.WriteLine($"You have {ItemCount} {ItemName}s");
            return ItemCount;
        }
        public List<string> InventoryRemoval(string ItemName, int AmountToRemove)
        {
            int ItemCount = 0;
            for (int i = 0; i > Inventory.Count; i++)
            {
                if (ItemCount == AmountToRemove)
                    {
                    break;
                    }
                Inventory.Remove(ItemName);
            }
            return Inventory;
        }
    }
}
