using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.Validations.SubscribersFileValidation
{
    class VerifyIDApperance
    {
        // Data Members
        private List<string> IDList;

        // Constructor
        public VerifyIDApperance(List<string> IDList)
        {
            this.IDList = IDList;
        }

        // Methods
        public bool CheckAllID(List<string> IDList)
        {
            if (IDList != null)
            {
                foreach (string id in IDList)
                {
                    if (!this.CheckIDApperance(id, IDList))
                        return false;
                }

                return true;
            }
            else
                Console.WriteLine("There are no ID's. The list is null.");

            return false;
        }

        public bool CheckIDApperance(string id, List<string> IDList)
        {
            if (id != null && IDList != null)
            {
                int count = 0;

                foreach (string i in IDList)
                {
                    if (i.Equals(id) && count == 0)
                        count++;
                    else if (i.Equals(id) && count >= 1)
                    {
                        Console.WriteLine("An ID appears twice or more. It's wrong, " +
                            "because ID is a unique information.");
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
