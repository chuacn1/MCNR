using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCNR;

namespace mine
{
    internal class veldros
    {
        public static void VeldrosEncounter()
        {
            Narration.VeldrosDialogue();
            RouteDecision();
        }

        public static void RouteDecision()
        {
            int choice = Narration.PickRoute();
            do
            {
                if ((choice != 1) && (choice != 2) && (choice != 3) && (choice != 4) && (choice != 5))
                {
                    Narration.InvalidInput();
                    choice = Narration.PickRoute();
                }
            }
            while ((choice != 1) && (choice != 2) && (choice != 3) && (choice != 4) && (choice != 5));

            switch (choice)
            {
                case 1:
                    Narration.EnterCave();
                    Cave.Cave1Or2();

                    break;
                case 2:
                    Narration.EnterForest();
                    Forest.Forest1Or2();
                    break;
                case 3:
                    FitCheck();
                    break;
                case 4:
                    Narration.RetracingSteps();
                    Town.EnteringTown();
                    break;
                case 5:
                    //Inventory
                    break;


            }
        }
        public static void FitCheck()
        {
            //if inventory has special sword and special flower 
            Narration.ReadyForKorthakDialogue();
            Korthak.KorthakEncounter();

            //if not
            Narration.NotReadyForKorthakDialogue();
            RouteDecision();
        }

    }
}
