using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.QueryActions.AddingActions
{
    class BorrowBookFromLibrary
    {
        // Data Member
        private string bookCode;
        private List<Book> allBookFromLibrary;
        private List<Subscriber> subs;

        // Constructor
        public BorrowBookFromLibrary(string bookCode, List<Book> allBookFromLibrary)
        {
            this.bookCode = bookCode;
            this.allBookFromLibrary = allBookFromLibrary;
        }

        // Methods
        public void SetNewBookToBeTakenInSubscriberList()
        {
            if ()
        }

        public void SetNewBookToBeTakenInLibrary()
        {
            if (this.allBookFromLibrary != null && this.bookCode != null)
            {
                foreach (Book b in this.allBookFromLibrary)
                {
                    if (b.GetCode().Equals(this.bookCode) && this.IsThisBookAlreadyTaken())
                        b.SetIsTakenTrue();
                }
            }
            else
            {
                if (this.allBookFromLibrary == null && this.bookCode != null)
                    Console.WriteLine("There are no books in the library");
                else if (this.allBookFromLibrary != null && this.bookCode == null)
                    Console.WriteLine("There is no book code.");
                else
                    Console.WriteLine("There are no books in the library and no book code");
            }
        }

        public bool IsThisBookAlreadyTaken()
        {
            if (this.allBookFromLibrary != null && this.bookCode != null)
            {
                foreach (Book b in this.allBookFromLibrary)
                {
                    if (b.GetCode().Equals(this.bookCode))
                        return b.GetIsTaken();
                }
            }

            return false;
        }

    }
}
