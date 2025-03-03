using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCNR
{
    public class Cave
    {
        public static void Cave1or2()
        {
            string C1C2choice = Narration.C1orC2();

            if (C1C2choice == "1")
            {
                string GloomBeastChoice = Narration.C1GloomBeast();
                if (GloomBeastChoice == "1")
                {
                    //EnemyVSPlayer
                }
                else 
                { 
                    //Flee Narration
                }
            }
            if (C1C2choice == "2")
            {
                string GemStoneChoice = Narration.C3GemstoneTitan();
                if (GemStoneChoice == "1")
                {
                    //EnemyVSPlayer
                    Narration.C3orRetraceorExit(); //put in method
                }
                else
                {
                    //Flee Narration
                }
            }
            if (C1C2choice == "0")
            {
                Narration.ExitingCave();
                Narration.VeldrosDialogue(); //PlayerName, Veldros.cs
                Narration.PickRoute(); //PlayerName, Veldros.cs 
            }
        }
    }
}
