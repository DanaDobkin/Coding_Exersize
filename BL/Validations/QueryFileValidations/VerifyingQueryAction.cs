using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.Validations.QueryFileValidations
{
    class VerifyingQueryAction
    {
        // Data Members
        private List<string> actionsInQuery;
        private List<string> allCorrectActions;

        // Constructor
        public VerifyingQueryAction(List<string> actionsInQuery, List<string> allCorrectActions)
        {
            this.actionsInQuery = actionsInQuery;
            this.allCorrectActions = allCorrectActions;
        }

        // Methods
        public bool VerifyingAllActionsInQueryAreLogical(List<string> actionsInQuery, List<string> allCorrectActions)
        { 
            if (actionsInQuery != null && allCorrectActions != null)
            {
                foreach (string queryAction in actionsInQuery)
                {
                    foreach (string correctAction in allCorrectActions)
                    {
                        if (queryAction.Equals(correctAction))
                            return true;
                    }
                }

                Console.WriteLine("There is a wrong action in the query.");
                return false;
            }
            else
            {
                if (actionsInQuery == null && allCorrectActions != null)
                    Console.WriteLine("There are no actions in the query file. The list is null.");
                else if (actionsInQuery != null && allCorrectActions == null)
                    Console.WriteLine("There are no correct system-based actions. The list is null.");
                else
                    Console.WriteLine("There are no correct system-based actions and no action" +
                        " in the query file . They're all null.");

                return false;
            }
        }
    }
}
