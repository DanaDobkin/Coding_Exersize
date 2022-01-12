using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;

namespace BookLibraryProject
{
    //[Flags]
    //public enum constDefinition
    //{
    //    None = 1,  
    //    Monday = 1, 
    //    Tuesday = 1,
    //    Wednesday = 1, 
    //    Thursday = 1, 
    //    Friday = 1, 
    //    Saturday = 1,  
    //    Sunday = 1, 
    //    Weekend = Saturday | Sunday
    //}

    class Program
    {
        // Constunt Definition
        public const string SPLIT_ACTION = " ";
        public const int MAX_BOOK_AMOUNT_PER_SUB = 10;
        public const int DEFAULT_WRONG_INT = -1;

            // Query File 
            public const int RETURN_BOOK_TO_LIBRARY = 1;
            public const int TAKE_BOOK_HOME = 2;
            public const int NEW_SUBSCRIBER = 3;
            public const int DELETE_SUBSCRIBTION = 4;
            public const int BOOK_ACTION = 4;
            public const int SUBSCRIBTION_ACTION = 3;
            public const int DEFAULT_VALUE = -1;
            public const string QUERY_ADD_ACTION = "+";
            public const string QUERY_SUBTRACT_ACTION = "-";
            public const int ACTION_INDEX = 0;
            public const int NAME_INDEX = 1;
            public const int ID_INDEX = 2;
            public const int BOOK_CODE_INDEX = 3;
            public const int QUESTION_LENGTH = 2;

            // Subscribers File
            public const int NAME = 0;
            public const int ID = 1;
            public const int BOOKS = 2;
            public const string BOOKS_SPLIT = ",";
        // ENUM

        // Variable Definition
        public static List<Subscriber> subscribers;
        public static List<Book> books;
        public static List<string> queries;
        public static List<string> answer;

        static void Main(string[] args)
        {
            subscribers = new List<Subscriber>();
            books = new List<Book>();
            answer = new List<string>();
            
            //var textFileLibraryPath = ConfigurationManager.AppSettings["BooksLibrary"];
            //var textFileQueriesPath = ConfigurationManager.AppSettings["Queries"];
            //var textFileSubscribersPath = ConfigurationManager.AppSettings["Subscribers"];

            string textFileLibraryPath = $"C:\\Users\\777ma\\Documents\\Army_Learning_In_Zoom\\C_Sharp_excersize\\BookLibraryProject\\Files\\BooksLibrary.txt";
            string textFileQueriesPath = $"C:\\Users\\777ma\\Documents\\Army_Learning_In_Zoom\\C_Sharp_excersize\\BookLibraryProject\\Files\\Queries.txt";
            string textFileSubscribersPath = $"C:\\Users\\777ma\\Documents\\Army_Learning_In_Zoom\\C_Sharp_excersize\\BookLibraryProject\\Files\\Subscribers.txt";

            subscribers = GetAllSubscribers(File.ReadAllLines(textFileSubscribersPath).ToList(), subscribers);
            books = GetAllLibraryBooks(File.ReadAllLines(textFileLibraryPath).ToList());
            SetBooksToBeTaken(subscribers, books);

            queries = File.ReadAllLines(textFileQueriesPath).ToList();

            // Verifying Files
            //if (VerifyThatSubscribersHoldCorrectBooksFromLibrary(subscribers, books))
            //{
            //    IsBookAmountGood();
            //}
            //else
            //{
            //    Console.WriteLine("The library has a mess. There are subscribers that have books which don't" +
            //        "belong to the library collection.");
            //}

            Console.ReadLine();      
        }

        // After Queries Methods
        public static void StartWorkingOnQueries(List<string> queries, List<string> answer, List<Subscriber> subs, List<Book> bookInLibrary)
        {
            if (queries != null)
            {
                string[] query;

                foreach (string q in queries)
                {
                    query = GetQuery(q);
                    answer.Add(q);

                    switch (GetQueryLength(q))
                    {
                        case (BOOK_ACTION) :
                            {
                                switch (GetFirstActionInQuery(q))
                                {
                                    case (QUERY_ADD_ACTION) : //אם זה פלוס הוא רוצה לשאול ספר
                                        {
                                            if (!(FindHowManyBookASpesificSubscriberHas(subs, GetID(q)) >= MAX_BOOK_AMOUNT_PER_SUB))
                                            {
                                                if (FindIfASpesificBookIsTakenFromLibrary(bookInLibrary, GetBookCodeInQuery(q)))
                                                {

                                                }
                                                else
                                                {
                                                    Console.WriteLine("This Book doesn't exist in the library");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(GetName(q) + " can't take more book. He already" +
                                                    " has " + MAX_BOOK_AMOUNT_PER_SUB + " books.");
                                            }
                                        }
                                        
                                        break;

                                    case (QUERY_SUBTRACT_ACTION) : //אם זה מינוס הוא רוצה להחזיר ספר לספרייה
                                        {
                                            if (!(FindHowManyBookASpesificSubscriberHas(subs, GetID(q)) <= 0))
                                            {
                                                //does book exist in the library
                                            }
                                            else
                                            {
                                                Console.WriteLine(GetName(q) + " can't return books to the library" +
                                                    " since he/she doesn't have any at all.");
                                            }
                                        }

                                        break;
                                }
                            }

                            break;

                        case (SUBSCRIBTION_ACTION) :
                            {

                            }

                            break;

                        case (QUESTION_LENGTH) :
                            {

                            }

                            break;
                        
                        default :
                            Console.WriteLine("Wrong query form.");
                            break;
                    }
                }  
            }
            else
            {
                Console.WriteLine("There are no queries in the file!");
            }
        }



        // Query-Related Methods
        public static bool FindIfASpesificBookIsTakenFromLibrary(List<Book> booksInLibrary, string code)
        {
            if (booksInLibrary != null)
            {
                foreach (Book b in booksInLibrary)
                {
                    if (b.GetCode().Equals(code))
                        return b.GetIsTaken();
                }

                Console.WriteLine("Couldn't find that book");

                return false;
            }
            else
            {
                Console.WriteLine("There are no books in the library");

                return false;
            }
        }

        public static int FindHowManyBookASpesificSubscriberHas(List<Subscriber> subs, string id)
        {
            if (subs != null)
            {
                foreach (Subscriber s in subs)
                {
                    if (s.GetID().Equals(id))
                        return s.CountBooks();
                }

                Console.WriteLine("Couldn't find that subscriber");

                return DEFAULT_WRONG_INT;
            }
            else
            {
                Console.WriteLine("There are no subscribers");

                return DEFAULT_WRONG_INT;
            }
        }

        public static int GetQueryLength(string s)
        {
            return s.Split(SPLIT_ACTION).Length;
        }

        public static string[] GetQuery(string s)
        {
            return s.Split(SPLIT_ACTION);
        }

        public static string GetFirstActionInQuery(string s)
        {
            if (s.Length > ACTION_INDEX)
            {
                return GetQuery(s)[ACTION_INDEX];
            }

            return "";
        }

        public bool IsAddAction(string s)
        {
            return GetFirstActionInQuery(s).Equals(QUERY_ADD_ACTION);
        }

        public bool IsSubstractionAction(string s)
        {
            return GetFirstActionInQuery(s).Equals(QUERY_SUBTRACT_ACTION);
        }

        public static string GetName(string s)
        {
            if (s.Length > NAME_INDEX)
            {
                return GetQuery(s)[NAME_INDEX];
            }

            return "";
        }

        public static string GetID(string s)
        {
            if (s.Length > ID_INDEX)
            {
                return GetQuery(s)[ID_INDEX];
            }

            return "";
        }

        public static string GetBookCodeInQuery(string s)
        {
            if (s.Length > BOOK_CODE_INDEX)
            {
                return GetQuery(s)[BOOK_CODE_INDEX];
            }

            return "";
        }

        public int GetTypeOfQuery(string s)
        {
            if (GetQueryLength(s) == BOOK_ACTION)
            {
                if (IsAddAction(s))
                {
                    return TAKE_BOOK_HOME;
                }
                else if (IsSubstractionAction(s))
                {
                    return RETURN_BOOK_TO_LIBRARY;
                }
            }
            else if (GetQueryLength(s) == SUBSCRIBTION_ACTION)
            {
                if (IsAddAction(s))
                {
                    return NEW_SUBSCRIBER;
                }
                else if (IsSubstractionAction(s))
                {
                    return DELETE_SUBSCRIBTION;
                }
            }

            return DEFAULT_VALUE;
        }






        // Before Queries Methods
        public static bool IsBookAmountGood(List<Subscriber> subs, List<Book> book)
        {
            if (subs != null)
            {
                foreach (Subscriber s in subs)
                {
                    if (s.GetAllBooks().Count > MAX_BOOK_AMOUNT_PER_SUB)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                Console.WriteLine("There are no subscribers!");

                return false;
            }
        }

        public static void SetBooksToBeTaken(List<Subscriber> subs, List<Book> book)
        {
            if (subs != null)
            {
                foreach (Subscriber s in subs)
                {
                    foreach (Book b in s.GetAllBooks()) // Subscriber's Books
                    {
                        b.SetIsTakenTrue();
                        b.SetThisSpecificBookToBeTakenInTheLibrary(book); // In the library
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no subscribers!");
            }
        }

        public static bool VerifyThatSubscribersHoldCorrectBooksFromLibrary(List<Subscriber> allSubs, List<Book> allBooks)
        {
            if (allSubs != null && allBooks != null)
            {
                foreach (Subscriber s in allSubs)
                {
                    foreach (Book b in s.GetAllBooks())
                    {
                        if (s.GetAllBooks() == null) // Sub that doesn't have books. It is possible.
                            return true;

                        if (!b.DoesThisBookExistInLibrary(allBooks))
                        {
                            Console.WriteLine("The subscriber holds a book that doesn't exist in the library");

                            return false;
                        }  
                    }
                }

                return true;
            }
            else
            {
                Console.WriteLine("There are no subscribers");

                return false;
            }
        }
        public static List<Book> GetAllLibraryBooks(List<string> allBooksInLibrary)
        {
            if (allBooksInLibrary != null)
            {
                List<Book> allBooks = new List<Book>();
                foreach (string b in allBooksInLibrary)
                {
                    allBooks.Add(new Book(b));
                }

                return allBooks;
            }
            else
            {
                Console.WriteLine("There are no books in the library!");

                return null;
            }
        }

        public static List<Subscriber> GetAllSubscribers(List<string> subscriber, List<Subscriber> allSubscribers)
        {
            if (subscriber != null)
            {
                Subscriber b;
                int id;

                foreach (string sub in subscriber)
                {
                    if (sub.Split(SPLIT_ACTION).Length > 1) // If sub has ID
                    {
                        b = new Subscriber(sub.Split(SPLIT_ACTION)[NAME], int.Parse(sub.Split(SPLIT_ACTION)[ID]));

                        if (!b.VerifyingID()) // Incorrect ID
                            return null;
                    }
                    else
                    {
                        Console.WriteLine("This subscriber doesn't have an ID");

                        return null;
                    }

                    if (sub.Split(SPLIT_ACTION).Length > BOOKS) // Only if this sub has books
                    {
                        b = GiveToSubscriberAllHisBooks(sub.Split(SPLIT_ACTION)[BOOKS].Split(BOOKS_SPLIT), b);
                    }
                    
                    allSubscribers.Add(b);
                }

                return allSubscribers;
            }
            else
            {
                Console.WriteLine("There are no subscribers!");
                
                return null;
            }
        }

        public static Subscriber GiveToSubscriberAllHisBooks(string[] booksPerSubscriber, Subscriber b)
        {
            if (booksPerSubscriber != null && b != null)
            {
                for (int i = 0; i < booksPerSubscriber.Length; i++)
                {
                    b.TakeANewBook(booksPerSubscriber[i]);
                }

                return b;
            }
            else
            {
                Console.WriteLine("There are no books or a subscriber");

                return null;
            }
        }

        
    }
}
