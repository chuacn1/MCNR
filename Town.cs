using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCNR;

namespace MCNR
{
    internal class town
    {
        public static void EnteringTown()
        {
            Narration.EnteredTownScreen();
            Narration.EnteringTownDialogue();
            InTown();
        }

        public static void InTown()
        {
            int townChoice = Narration.VisitBSorPM();

            do
            {
                if ((townChoice != 0) && (townChoice != 1) && (townChoice != 2) && (townChoice != 3))
                {
                    Narration.InvalidInput();
                    townChoice = Narration.VisitBSorPM();
                }
            }
            while ((townChoice != 0) && (townChoice != 1) && (townChoice != 2) && (townChoice != 3));
            {

                switch (townChoice)
                {
                    case 0:
                        //Inventory
                        break;
                    case 1:
                        //BlackSmith
                        break;
                    case 2:
                        //PotionMaker
                        break;
                    case 3:
                        Veldros.VeldrosEncounter();
                        break;
                }


            }
        }
    }
}
