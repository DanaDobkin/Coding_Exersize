using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.QueryActions.QuestionMerkActions
{
    class WhoDoesThisBookBelongTo
    {
        // Data Members
        private List<Subscriber> subs;
        private string bookCode;

        // Constructor
        public WhoDoesThisBookBelongTo(List<Subscriber> subs, string bookCode)
        {
            this.subs = subs;
            this.bookCode = bookCode;
        }

        // Methods
        public Subscriber FindBookOwner()
        {
            if (this.subs != null)
            {
                foreach (Subscriber s in this.subs)
                {
                    if (s.DoIHaveTheBook(this.bookCode))
                        return s;
                }
            }
            else
                Console.WriteLine("There are no subs. The List is null.");

            return null;
        }
    }
}
