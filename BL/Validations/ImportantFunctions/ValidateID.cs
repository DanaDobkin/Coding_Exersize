using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.Validations.ImportantFunctions
{
    class ValidateID
    {
        // Data Members
        private List<int> id;

        // Constructor
        public ValidateID(List<int> id)
        {
            this.id = id;
        }

        // Methods
        public bool AreAllIDCorrect()
        {
            if (this.id != null)
            {
                foreach (int s in this.id)
                {
                    if (!this.IsIDCorrest(s))
                        return false;
                }

                return true;
            }

            Console.WriteLine("Couldn't find id. The list is null.");
            return false;
        }

        public bool IsIDCorrest(int id)
        {
            return (id.ToString().Length != 9);
        }
    }
}
