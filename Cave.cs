using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCNR
{
    public class Cave
    {
        public static void Cave1Or2()
        { //loop
            int C1C2choice = Narration.C1orC2();

            if (C1C2choice == '1')
            {
                GloomBeast();
            }
            if (C1C2choice == '2')
            {
                SpecialSword();
            }
            if (C1C2choice == '0')
            {
                Narration.ExitingCave();
                Narration.VeldrosDialogue(); //PlayerName, Veldros.cs
                Narration.PickRoute(); //PlayerName, Veldros.cs 
            }
            else
            {
                Narration.InvalidInput();
                Cave1Or2();
            }
        }

        public static void GloomBeast()
        {
            int GloomBeastChoice = Narration.C1GloomBeast();
            if (GloomBeastChoice == '1')
            {
                //EnemyVsPlayer
            }
            if (GloomBeastChoice == '2')
            {
                Cave1Or2();
            }
            else
            {
                Narration.InvalidInput();
                Narration.C1GloomBeast();
            }
        }
        public static void SpecialSword()
        {

            string guess = Narration.SpecialSwordGuess();

            while (guess != "LIGHT")
            {
                Narration.SpecialSwordIncorrect(); 
                guess = Narration.SpecialSwordGuess(); //new guess value
            }
            Narration.SpecialSwordCorrect();
            char claim = Narration.SpecialSwordClaim();

            C3RetraceExit();
        }

        public static void C3RetraceExit()
        {
           int choice = Narration.C3orRetraceorExit(); 

            switch (choice) 
            {
                case 1: 
                    int gemStoneChoice = Narration.C3GemstoneTitan();
                    if (gemStoneChoice == 1)
                    {
                        //EnemeyVsPlayer
                    }
                    if (gemStoneChoice == 2)
                    {
                        C3RetraceExit();
                    }
                    break;

               case 2:
                    Cave1Or2(); 
                    Narration.RetracingSteps();
                    break;

               case 0:
                    Narration.ExitingCave();
                    break;

               default:
                    Narration.InvalidInput();
                    C3RetraceExit();
                    break;

            

        }
    }
}
