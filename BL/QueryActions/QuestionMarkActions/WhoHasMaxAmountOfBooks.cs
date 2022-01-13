using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.QueryActions.QuestionMerkActions
{
    class WhoHasMaxAmountOfBooks : MaxBookAmountHolder
    {
        // Data Members
        private List<Subscriber> subs;
        private MaxBookAmountHolder maxPerson;
        private int maxCounter;

        // Constructor
        public WhoHasMaxAmountOfBooks(List<Subscriber> subs) : base()
        {
            this.subs = subs;
            this.maxPerson = new MaxBookAmountHolder();
            this.maxCounter = 0;
        }

        // Methods
        public MaxBookAmountHolder FindMaxAmountHolder()
        {
            if (this.subs != null)
            {
                foreach (Subscriber sub in this.subs)
                {
                    if (sub.GetAllBooks().Count > this.maxCounter)
                    {
                        this.maxPerson.SetBookAmount(sub.GetAllBooks().Count);
                        this.maxPerson.SetID(sub.GetID().ToString());
                        this.maxPerson.SetLastName(sub.GetLastName());
                    }
                }

                return this.maxPerson;
            }
            else
                Console.WriteLine("There are no subs. The list is null.");

             return null;
        }
    }
}
