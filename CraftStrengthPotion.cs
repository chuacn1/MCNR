using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MCNR.Program;

namespace MCNR
{
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
}