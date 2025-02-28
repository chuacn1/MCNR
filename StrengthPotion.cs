using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MCNR.Program;

namespace MCNR
{
    public class StrengthPotion
    {
        public string name { get; set; }
        public int increaseAmount { get; set; }
        public int cost { get; set; }
        public int maxUses { get; set; }
        public int currentUses { get; set; }

        // Required material to craft this potion
        public static string requireMaterial = "Crystal Flower";
        public static int requiredQuantity = 1 + HealthPotion.requiredQuantity;
    }
}
