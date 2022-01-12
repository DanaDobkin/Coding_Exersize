using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.Validations.QueryFileValidations
{
    class VerifyAMatchBetweenLastNameAndID
    {
        // Data Members
        private List<string> lastNamesInQuery;
        private List<string> idInQuery;
        private List<Subscriber> librarySubs;

        // Constructor
        public VerifyAMatchBetweenLastNameAndID(List<string> lastNamesInQuery, List<string> idInQuery, List<Subscriber> librarySubs)
        {
            this.lastNamesInQuery = lastNamesInQuery;
            this.idInQuery = idInQuery;
            this.librarySubs = librarySubs;
        }

        // Methods
        public List<string> GetAllPossibleIDOfASpecificName(string name, List<Subscriber> librarySubs)
        {
            if (librarySubs != null)
            {
                List<string> possibleID = new List<string>();

                foreach (Subscriber s in librarySubs)
                {
                    if (s.GetLastName().Equals(name))
                    {
                        possibleID.Add(s.GetID().ToString());
                    }
                }

                if (possibleID == null)
                {
                    Console.WriteLine("There is no subscriber under that name.");

                    return null;
                }

                return possibleID;
            }
            else
            {
                Console.WriteLine("There are no subscribers in the library. The list is null.");

                return null;
            }
        }

        public bool FindingMatchingIDAndLastName(string name, string idInQuery)
        {
            List<string> possibleID = this.GetAllPossibleIDOfASpecificName(name, this.librarySubs);

            if (possibleID != null)
            {
                foreach (string s in possibleID)
                {
                    if (s.Equals(idInQuery))
                        return true;
                }

                return false;
            }
            else
            {
                

                return false;
            }
        }

        public bool MatchingAllLastNamesAndID(List<string> idInQuery, List<string> lastNamesInQuery)
        {
            if (lastNamesInQuery != null && idInQuery != null)
            {
                for (int i = 0; i < lastNamesInQuery.Count; i++)
                {
                    if (!this.FindingMatchingIDAndLastName(lastNamesInQuery[i], idInQuery[i]))
                    {
                        Console.WriteLine("There are no possible id for this last name. There is no subscriber " +
                            "with such last name in the library.");

                        return false;
                    }
                }

                return true;
            }
            else
            {
                if (lastNamesInQuery == null && idInQuery != null)
                    Console.WriteLine("There are no lat names in the query. The list is null.");
                else if (lastNamesInQuery != null && idInQuery == null)
                    Console.WriteLine("There are no id in the query. The list is null.");
                else
                    Console.WriteLine("There are no last names and no id lists. They're all null.");

                return false;
            }
        }
    }
}
