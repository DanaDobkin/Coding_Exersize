using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject.BL.QueryActions.QuestionMerkActions
{
    class GetAllBooksOfASubscriber
    {
        // Data Members
        private List<Subscriber> subs;
        private string id;
        private string[] booksArr;

        // Constructor
        public GetAllBooksOfASubscriber(List<Subscriber> subs, string id)
        {
            this.subs = subs;
            this.id = id;
        }

        // Methods
        public string[] GetArrayOfBooks()
        {
            this.booksArr = new string[this.AllBooks().Count];
            List<Book> helper = this.AllBooks();

            if (this.booksArr != null)
            {
                for (int i = 0; i < this.booksArr.Length; i++)
                {
                    this.booksArr[i] = helper[i].GetCode();
                }

                return this.booksArr;
            }

            return null;
        }

        public List<Book> AllBooks()
        {
            if (this.subs != null && this.id != null)
                return this.FindSpesificSubByID(this.id).GetAllBooks();

            else
            {
                if (this.subs == null && this.id != null)
                    Console.WriteLine("There are no subs. The list is null.");
                else if (this.subs != null && this.id == null)
                    Console.WriteLine("There is no id. It's null.");
                else
                    Console.WriteLine("There are no subs and no id. They're all null.");

                return null;
            }
        }

        public Subscriber FindSpesificSubByID(string id)
        {
            if (this.subs != null)
            {
                foreach (Subscriber s in this.subs)
                {
                    if (s.GetID().ToString().Equals(id))
                        return s;
                }
            }

            return null;
        }
    }
}
