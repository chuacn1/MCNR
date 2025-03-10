using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCNR;
using mine;

namespace MCNR;

internal class PotionMaker
{
    public static void PotionMakerEncounter()
    {
        int choice = Narration.PotionMakerDialogue();

        do
        {
            if (choice != '1' && choice != '2' && choice != '3')
            {
                Narration.InvalidInput();
                choice = Narration.PotionMakerDialogue();
            }
        }

        while (choice != '1' && choice != '2' && choice != '3');

        switch (choice)
        {
            case 1:
                //HealingPotion
                break;
            case 2:
            //StrengthPotion
            case 3:
                Narration.ExitPotionMakerDialogue();
                town.InTown();
                break;
        }
    }
}
