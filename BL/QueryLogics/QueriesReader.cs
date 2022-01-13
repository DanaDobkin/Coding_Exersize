using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BookLibraryProject.DAL
{
    class QueriesReader : AllPaths
    {
        // Data Members
        private List<string> allQueries;

        // All Possible Elements In Query
        private const int actionIndex = 0;
        private const int lastNameIndex = 1;
        private const int IDIndex = 2;
        private const int booksIndex = 3;
        private const string splitWordsChar = " ";

        // All Possible Length Of Query
        private const int borrowOrReturnBookIndex = 4;
        private const int addOrDeleteASubscriberIndex = 3;
        private const int questionMarkQueryIndex = 2;

        // Constructor
        public QueriesReader() : base()
        {
            this.allQueries = File.ReadAllLines(base.textFileQueriesPath).ToList();
        }

        // Methods
        public List<int> GetAllPossibleLength()
        {
            List<int> allPossibleLength = new List<int>();
            allPossibleLength.Add(questionMarkQueryIndex);
            allPossibleLength.Add(addOrDeleteASubscriberIndex);
            allPossibleLength.Add(borrowOrReturnBookIndex);

            return allPossibleLength;
        }

        public List<int> GetAllQueriesLengths()
        {
            if (this.allQueries != null)
            {
                List<int> allLengths = new List<int>();

                foreach (string s in this.allQueries)
                {
                    allLengths.Add(s.Split(splitWordsChar).Length);
                }

                return allLengths;
            }

            Console.WriteLine("There are no queries. The list is null.");
            
            return null;
        }

        public List<string> GetAllQueries()
        {
            return this.allQueries;
        }

        public int GetSingleQueryLengthByIndex(int index)
        {
            return this.GetSingleQueryByIndex(index).Split(splitWordsChar).Length;
        }

        public string GetSingleQueryByIndex(int index)
        {
            if (index < this.allQueries.Count)
                return this.allQueries[index];

            Console.WriteLine("Wrong index.");

            return null;
        }
    }
}
