using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibraryProject.BL.Validations.ImportantFunctions
{
    class ValidateLastName
    {
        // Data Members
        private List<string> lastNames;

        // Constructor
        public ValidateLastName(List<string> lastNames)
        {
            this.lastNames = lastNames;
        }

        // Methods
        public bool VerifyLastNames()
        {
            if (this.lastNames != null)
            {
                foreach (string s in this.lastNames)
                {
                    if (!s.Any(char.IsLetter) || s.Any(char.IsDigit))
                        return false;
                }

                return true;
            }
            else
            {
                Console.WriteLine("There are no last names. The list is null.");

                return false;
            }
        }
    }
}
