using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.Validations.QueryFileValidations
{
    class ValidateBookExistInLibrary
    {
        // Data Members
        private List<string> queryRequieredBooks;
        private List<string> libraryBooks;

        // Constructor
        public ValidateBookExistInLibrary(List<string> queryRequieredBooks, List<string> libraryBooks)
        {
            this.queryRequieredBooks = queryRequieredBooks;
            this.libraryBooks = libraryBooks;
        }

        // Methods
        public bool DoesBookExistInLibrary(string book, List<string> libraryBooks)
        {
            if (book != null && libraryBooks != null)
            { 
                foreach (string lb in libraryBooks)
                {
                    if (lb.Equals(book))
                        return true;
                }

                Console.WriteLine("This book doesn't exist in the library.");

                return false;
            }
            else
            {
                if (book == null && libraryBooks != null)
                    Console.WriteLine("There is no book. It's null.");
                else if (book != null && libraryBooks == null)
                    Console.WriteLine("There is no library. The list is null.");
                else
                    Console.WriteLine("There is no library and no book. All is null.");

                return false;
            }
        }
    }
}
