using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.Validations.QueryFileValidations
{
    class VerifyIsAPersonASubscriber
    {
        // Data Members
        private List<string> idOfPeopleInQuery;
        private List<Subscriber> librarySubscribers;

        // Constructor
        public VerifyIsAPersonASubscriber(List<string> idOfPeopleInQuery, List<Subscriber> librarySubscribers)
        {
            this.idOfPeopleInQuery = idOfPeopleInQuery;
            this.librarySubscribers = librarySubscribers;
        }

        // Methods
        public bool VerifyAllPeople()
        {
            if (this.librarySubscribers != null && this.idOfPeopleInQuery != null)
            {
                foreach (int i in this.IntParseAllID(this.idOfPeopleInQuery))
                {
                    if (!this.IsThisPersonASubscriber(i, this.librarySubscribers))
                        return false;
                }

                return true;
            }
            else
            {
                if (this.librarySubscribers == null && this.idOfPeopleInQuery != null)
                    Console.WriteLine("There are no library subscribers. The list is null.");
                else if (this.librarySubscribers != null && this.idOfPeopleInQuery == null)
                    Console.WriteLine("There are no id of people. The list is null.");
                else
                    Console.WriteLine("There are no library subscribers and no id lists. They're all null.");

                return false;
            }
        }

        public bool IsThisPersonASubscriber(int id, List<Subscriber> librarySubs)
        {
            if (id != null && librarySubs != null)
            {
                foreach (Subscriber sub in librarySubs)
                {
                    if (sub.GetID() == id)
                        return true;
                }

                return false;
            }
            
            return false;

        }

        public List<int> IntParseAllID(List<string> id)
        {
            if (id != null)
            {
                List<int> newID = new List<int>();

                foreach (string i in id)
                {
                    newID.Add(int.Parse(i));
                }

                return newID;
            }

            return null;
        }
    }
}
