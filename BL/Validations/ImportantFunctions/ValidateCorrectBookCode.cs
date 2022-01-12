using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibraryProject.BL.Validations
{
    class ValidateCorrectBookCode
    {
        // Data Members
        private List<string> bookCodes;
        private int codeLength;
        private int lettersAmount;
        private int digitsAmount;

        // Constructor
        public ValidateCorrectBookCode(List<string> bookCodes, int codeLength, int lettersAmount, int digitsAmount)
        {
            this.bookCodes = bookCodes;
            this.codeLength = codeLength;
            this.lettersAmount = lettersAmount;
            this.digitsAmount = digitsAmount;
        }

        // Methods
        public bool VerifyBookCode(string code)
        {
            if (code != null || code != "")
            {
                if (!(code.Any(char.IsDigit) && code.Any(char.IsLetter)))
                    return false;
                if (!code.Count(char.IsLetter).Equals(lettersAmount) || !code.Count(char.IsDigit).Equals(digitsAmount))
                    return false;

                return true;
            }
            else
            {
                Console.WriteLine("This Code Is Null.");

                return false;
            }
        }

        public bool VerifyAllBookCode()
        {
            if (this.bookCodes != null)
            {
                int countLetters = 0;

                foreach (string b in this.bookCodes)
                {
                    if (!this.VerifyBookCode(b))
                        return false;
                }

                return true;
            }
            else
            {
                Console.WriteLine("There are no book codes. The list is null.");

                return false;
            }
        }

        public bool VerifyLengthOfBookCode()
        {
            if (this.bookCodes != null)
            {
                foreach (string b in this.bookCodes)
                {
                    if (!b.Length.Equals(this.codeLength))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                Console.WriteLine("There are no book codes. The list is null.");

                return false;
            }
        }
    }
}
