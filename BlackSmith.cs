using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCNR;

namespace MCNR
{
    internal class BlackSmith
    {
        public static void BackSmithEncounter()
        {
            int choice = Narration.BlackSmithDialogue();

            do
            {
                if (choice != '1' && choice != '2')
                {
                    Narration.InvalidInput();
                    choice = Narration.BlackSmithDialogue();
                }
            }

            while (choice != '1' && choice != '2');

            switch (choice)
            {
                case 1:
                    //UpgradeSword
                    break;
                case 2:
                    Narration.ExitBlackSmithDialogue();
                    town.InTown();
                    break;
            }
        }
    }
}
