using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace MCNR
{
    public class Cave
    {
        public static void Cave1Or2() // 1 = GloomBeast, 2 = SpecialSword, 0 = ExitCave + PickRoute
        {

            int C1C2choice = Narration.C1orC2();
            do
            {
                if ((C1C2choice != 1 && C1C2choice != 2 && C1C2choice != 0))
                {
                    Narration.InvalidInput();
                    C1C2choice = Narration.C1orC2();
                }


            } while (C1C2choice != 1 && C1C2choice != 2 && C1C2choice != 0);

            switch (C1C2choice)
            {
                case 1:
                    GloomBeast();
                    break;
                case 2:
                    SpecialSword();
                    break;
                case 0:
                    Narration.ExitingCave();
                    Narration.PickRoute();
                    break;

            }
        }
        public static void GloomBeast() // 1 = Fight GloomBeast, 2 = Flee + back to Cave1Or2
        {
            int GloomBeastChoice = Narration.C1GloomBeast();
            do
            {
                if ((GloomBeastChoice != 1 && GloomBeastChoice != 2))
                {
                    Narration.InvalidInput();
                    GloomBeastChoice = Narration.C1GloomBeast();
                }
            }

            while (GloomBeastChoice != 1 && GloomBeastChoice != 2);

            switch (GloomBeastChoice)
            {
                case 1:
                    // EnemyVsPlayer
                    C3RetraceExit();
                    break;
                case 2:
                    Cave1Or2();
                    break;
                default:
                    break;
            }
        }
        public static void SpecialSword() // Correct = Special Sword Claimed, Incorrect = Try Again

        {

            string guess = Narration.SpecialSwordGuess(); 
            while (guess != "LIGHT")
            {
                Narration.SpecialSwordIncorrect();
                guess = Narration.SpecialSwordGuess(); //new guess value
            }
            Narration.SpecialSwordCorrect();

            char claim = Narration.SpecialSwordClaim(); //not sure if we wanna keep it as a char

            while ((claim == 'P') || (claim == 'p'))
            {
                Narration.InvalidInput();
                claim = Narration.SpecialSwordClaim();
            }

            Narration.DeadEndCave();
            EscapeCave();
        }
        public static void C3RetraceExit() //1 = GemStoneGolem, 2 = Retrace + back to Cave1Or2, 0 = ExitCave + PickRoute
        {

            int choice = Narration.C3orRetraceorExit();
            do
            {
                if ((choice != 0 && choice != 1 && choice != 2))
                {
                    Narration.InvalidInput();
                    choice = Narration.C3orRetraceorExit();
                }

            }
            while (choice != 0 && choice != 1 && choice != 2);

            switch (choice)
            {
                case 1:
                    GemStone();
                    break;

                case 2:
                    Narration.RetracingSteps();
                    Cave1Or2();
                    break;

                case 0:
                    Narration.ExitingCave();
                    Narration.PickRoute();//playername

                    break;


            }
        }
        public static void GemStone() // 1 = Fight GemStone, 2 = Flee + back to C3RetraceExit
        {
            int GemStoneChoice = Narration.C3GemstoneTitan();
            do
            {
                if ((GemStoneChoice != 1 && GemStoneChoice != 2))
                {
                    Narration.InvalidInput();
                    GemStoneChoice = Narration.C3GemstoneTitan();
                }
            }
            while (GemStoneChoice != 1 && GemStoneChoice != 2);

            switch (GemStoneChoice)
            {
                case 1:
                    // EnemyVsPlayer
                    Narration.DeadEndCave();
                    break;
                case 2:
                    C3RetraceExit();
                    break;
            }
        }

        public static void EscapeCave() // After claiming Special Sword, EscapeCave. Correct = Exit + PickRoute, Incorrect = EnvironmentExit (might change this maybe not)
        {
            Narration.DeadEndCave();
            Narration.EscapeCaveRiddleDialogue();

            string answer = Narration.EscapeCaveRiddle();


            if (answer != "129")
            {
                Narration.EscapeCaveRiddleIncorrec();
                Environment.Exit(0); //not sure if we will do a checkpoint or not
            }
            if (answer == "129")
            {
                Narration.EscapeCaveRiddleCorrect();
                Narration.ExitingCave();
                Narration.PickRoute(); //playername
            }


        }
    }
}

