using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.Validations.QueryFileValidations
{
    class VerifyingQueryLength
    {
        // Data Members
        private int queryLength;
        private List<int> possibleLengths;

        // Constructor
        public VerifyingQueryLength(int queryLength, List<int> possibleLengths)
        {
            this.queryLength = queryLength;
            this.possibleLengths = possibleLengths;
        }

        // Methods
        public bool DoesQueryHavePossibleLength(int queryLength, List<int> possibleLengths)
        {
            if (queryLength != null)
            {
                foreach (int length in possibleLengths)
                {
                    if (queryLength.Equals(length))
                        return true;
                }

                Console.WriteLine("Query length isn't good. Check queries again.");

                return false;
            }
            else
            {
                Console.WriteLine("There is no query length. It's null.");

                return false;
            }
        }
    }
}
