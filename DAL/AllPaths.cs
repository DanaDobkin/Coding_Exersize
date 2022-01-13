using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.DAL
{
    class AllPaths
    {
        // Data Members
        protected string textFileLibraryPath;
        protected string textFileQueriesPath;
        protected string textFileSubscribersPath;

        // Constunt Definition
        protected const string SPLIT_ACTION = " ";
        protected const int MAX_BOOK_AMOUNT_PER_SUB = 10;
        protected const int DEFAULT_WRONG_INT = -1;

        // Query File 
        protected const int RETURN_BOOK_TO_LIBRARY = 1;
        protected const int TAKE_BOOK_HOME = 2;
        protected const int NEW_SUBSCRIBER = 3;
        protected const int DELETE_SUBSCRIBTION = 4;
        protected const int BOOK_ACTION = 4;
        protected const int SUBSCRIBTION_ACTION = 3;
        protected const int DEFAULT_VALUE = -1;
        protected const string QUERY_ADD_ACTION = "+";
        protected const string QUERY_SUBTRACT_ACTION = "-";
        protected const int ACTION_INDEX = 0;
        protected const int NAME_INDEX = 1;
        protected const int ID_INDEX = 2;
        protected const int BOOK_CODE_INDEX = 3;
        protected const int QUESTION_LENGTH = 2;

        // Subscribers File
        public const int NAME = 0;
        public const int ID = 1;
        public const int BOOKS = 2;
        public const string BOOKS_SPLIT = ",";

        // Constructor
        public AllPaths()
        {
            //var textFileLibraryPath = ConfigurationManager.AppSettings["BooksLibrary"];
            //var textFileQueriesPath = ConfigurationManager.AppSettings["Queries"];
            //var textFileSubscribersPath = ConfigurationManager.AppSettings["Subscribers"];

            this.textFileLibraryPath = $"C:\\Users\\777ma\\Documents\\Army_Learning_In_Zoom\\C_Sharp_excersize\\BookLibraryProject\\Files\\BooksLibrary.txt";
            this.textFileQueriesPath = $"C:\\Users\\777ma\\Documents\\Army_Learning_In_Zoom\\C_Sharp_excersize\\BookLibraryProject\\Files\\Queries.txt";
            this.textFileSubscribersPath = $"C:\\Users\\777ma\\Documents\\Army_Learning_In_Zoom\\C_Sharp_excersize\\BookLibraryProject\\Files\\Subscribers.txt";
        }
    }
}
