using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;


namespace MCNR
{
    public class Forest
    {
        public static void Forest1Or2() // 1 = SpecialFlower, 2 = Blooming Behemoth, 0 = ExitForest + PickRoute
        {

            int F1F2choice = Narration.F1orF2();
            do
            {
                if ((F1F2choice != 1 && F1F2choice != 2 && F1F2choice != 0))
                {
                    Narration.InvalidInput();
                    F1F2choice = Narration.C1orC2();
                }


            } while (F1F2choice != 1 && F1F2choice != 2 && F1F2choice != 0);

            switch (F1F2choice)
            {
                case 1:
                    SpecialFlower();

                    break;
                case 2:
                    BloomingBehemoth();
                    break;
                case 0:
                    Narration.ExitingForest();
                    Veldros.RouteDecision();
                    break;

            }
        }
        public static void BloomingBehemoth() // 1 = Fight BloomingBehemoth, 2 = Flee + back to Forest1Or2
        {
            int BloomingBehemothChoice = Narration.F1BloomingBehemoth();
            do
            {
                if ((BloomingBehemothChoice != 1 && BloomingBehemothChoice != 2))
                {
                    Narration.InvalidInput();
                    BloomingBehemothChoice = Narration.C1GloomBeast();
                }
            }

            while (BloomingBehemothChoice != 1 && BloomingBehemothChoice != 2);

            switch (BloomingBehemothChoice)
            {
                case 1:
                    // Enemy.EnemyVsPlayer
                    F3RetraceExit();
                    break;
                case 2:
                    Forest1Or2();
                    break;
                default:
                    break;
            }
        }
        public static void SpecialFlower() // 1 = Proceed to Riddle, 2 = Retreat + Forest1Or2

        {
            int choice = Narration.SpecialFlowerDialogue(); //playername
            do
            {
                if (choice != 1 && choice != 2)
                {
                    Narration.InvalidInput();
                    choice = Narration.SpecialFlowerDialogue(); //playername
                }
            }
            while (choice != 1 && choice != 2);
            {
                switch (choice)
                {
                    case 1:
                        Riddle();
                        Narration.AfterSpecialFlower();
                        Narration.RetracingSteps();
                        Forest1Or2();
                        break;
                    case 2:
                        Forest1Or2();
                        break;
                }
            }
        }
        public static void Riddle() // Riddle 1 = sun, Riddle 2 = flower, 2 attempts for each. gets diff amount of loots base on scores (correct)
        {
            int attempts1 = 2, attempts2 = 2;

            int correct = 0;

            while (attempts1 > 0)
            {
                string answer = Narration.sfRiddle1(); //playername
                if (answer != "sun")
                {
                    attempts1--;
                    Narration.sfRiddle1and2Incorrect();

                }
                if (answer == "sun")
                {
                    Narration.sfRiddle1Correct();
                    correct++;
                    break;
                }
            }

            if (attempts1 == 0)
            {
                Narration.sf1CompletelyIncorrect();
            }

            while (attempts2 > 0)
            {
                string ans = Narration.sfRiddle2();
                if (ans != "flower")
                {
                    attempts2--;
                    Narration.sfRiddle1and2Incorrect();
                }
                if (ans == "flower")
                {
                    Narration.sfRiddle2Correct();
                    correct++;
                    break;
                }
            }

            switch (correct)
            {
                case 1:
                    Narration.OneCorrect();
                    break;
                case 2:
                    Narration.TwoCorrect();
                    break;
                case 0:
                    Narration.ZeroCorrect();
                    break;

            }
        }
        public static void F3RetraceExit() // 1 = CrestFallenWarden, 2 = Retrace + back to Forest1Or2, 0 = ExitForest + PickRoute
        {

            int choice = Narration.F3orRetraceorExit();
            do
            {
                if ((choice != 0 && choice != 1 && choice != 2))
                {
                    Narration.InvalidInput();
                    choice = Narration.F3orRetraceorExit();
                }

            }
            while (choice != 0 && choice != 1 && choice != 2);

            switch (choice)
            {
                case 1:
                    CrestFallenWarden();
                    break;

                case 2:
                    Narration.RetracingSteps();
                    Forest1Or2();
                    break;

                case 0:
                    Narration.ExitingForest();
                    Narration.PickRoute();//playername

                    break;


            }
        }
        public static void CrestFallenWarden() // 1 = Fight GemStone, 2 = Flee + back to C3RetraceExit
        {
            int choice = Narration.F3CrestFallenWarden();
            do
            {
                if ((choice != 1 && choice != 2))
                {
                    Narration.InvalidInput();
                    choice = Narration.C3GemstoneTitan();
                }
            }
            while (choice != 1 && choice != 2);

            switch (choice)
            {
                case 1:
                    // Enemy.EnemyVsPlayer
                    Narration.ForestDeadEnd();
                    Narration.ExitingForest();
                    Narration.PickRoute(); //playername
                    break;
                case 2:
                    F3RetraceExit();
                    break;
            }
        }


    }
}


