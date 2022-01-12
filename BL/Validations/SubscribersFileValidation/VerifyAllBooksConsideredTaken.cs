using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.Validations.SubscribersFileValidation
{
    class VerifyAllBooksConsideredTaken
    {
        // Data Members
        private List<Book> libraryBooks;
        private List<Subscriber> subscriberBooks;
        private List<string> subscribersFile;

        // Constructor
        public VerifyAllBooksConsideredTaken(List<Book> libraryBooks, List<Subscriber> subscriberBooks, List<string> subscribersFile)
        {
            this.libraryBooks = libraryBooks;
            this.subscriberBooks = subscriberBooks;
            this.subscribersFile = subscribersFile;
        }

        // Methods
        public bool IsBookConsideredTakenInSubsriberList(List<Subscriber> subscriberBooks)
        {
            if (subscriberBooks != null)
            {
                foreach (Subscriber s in subscriberBooks)
                {
                    foreach (Book b in s.GetAllBooks())
                    {
                        if (!b.GetIsTaken())
                            return false;
                    }
                }

                return true;
            }
            else
                Console.WriteLine("The subscriber doesn't have any books. The list is null.");
                
            return false;
        }

        public bool IsBookConsideredTakenInLibrary(Book book)
        {
            if (book != null)
            {
                return book.GetIsTaken();
            }

            Console.WriteLine("There is no book. It's null.");
            return false;
        }

        public Book FindBookInLibrary(string bookCode, List<Book> libraryBooks)
        {
            if (libraryBooks != null && bookCode != null)
            {
                foreach (Book lb in libraryBooks)
                {
                    if (lb.GetCode().Equals(bookCode))
                        return lb;
                }
            }

            Console.WriteLine("The book doesn't exist in the library.");
            return null;
        }
    }
}
