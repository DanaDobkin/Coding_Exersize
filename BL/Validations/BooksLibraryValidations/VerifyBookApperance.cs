using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.Validations.BooksLibraryValidations
{
    class VerifyBookApperance
    {
        // Data Members
        private List<string> allBooks;

        // Constructor
        public VerifyBookApperance(List<string> allBooks)
        {
            this.allBooks = allBooks;
        }

        // Methods
        public bool CheckAllBooks(List<string> allBooks)
        {
            if (allBooks != null)
            {
                foreach (string ab in allBooks)
                {
                    if (!this.CheckBookApperance(ab, allBooks))
                        return false;
                }

                return true;
            }
            else
                Console.WriteLine("There are no ID's. The list is null.");

            return false;
        }

        public bool CheckBookApperance(string book, List<string> allBooks)
        {
            if (book != null && allBooks != null)
            {
                int count = 0;

                foreach (string ab in allBooks)
                {
                    if (ab.Equals(book) && count == 0)
                        count++;
                    else if (ab.Equals(book) && count >= 1)
                    {
                        Console.WriteLine("A book appears twice or more. It's wrong, " +
                            "because book code is a unique information.");
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
