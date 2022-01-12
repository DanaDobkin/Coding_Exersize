using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject
{
    class Subscriber
    {
        // Data Members
        private string lastName;
        private int id;
        private List<Book> books;
        //private bool 

        public Subscriber(string lastName, int id)
        {
            this.lastName = lastName;
            this.id = id;
            
            books = new List<Book>();
        }

        // Methods
        public bool VerifyingID()
        {
            if (this.id != null && this.id.ToString().Length != 9)
            {
                Console.WriteLine("The ID is incorrect");

                return false;
            }
            
            return true;
        }

        public void TakeANewBook(string code)
        {
            this.books.Add(new Book(code));
        }

        public void ReturnABook(string code)
        {
            this.books.Remove(this.GetASpecificBook(code));
        }

        public Book GetASpecificBook(string code)
        {
            foreach (Book book in this.books)
            {
                if (book.GetCode().Equals(code))
                {
                    return book;
                }
            }

            return null;
        }

        public bool DoIHaveTheBook(string code)
        {
            foreach (Book book in this.books)
            {
                if (book.GetCode().Equals(code))
                {
                    return true;
                }
            }

            return false;
        }

        public int CountBooks()
        {
            return this.books.Count;
        }

        public void SetAllBooksToBeTaken()
        {
            if (this.books != null)
            {
                foreach (Book b in this.books)
                {
                    b.SetIsTakenTrue();
                }
            }
            else
                Console.WriteLine("This subscriber doesn't have any books.");
        }

        // Get Methods
        public string GetLastName()
        {
            return this.lastName;
        }

        public int GetID()
        {
            return this.id;
        }

        public List<Book> GetAllBooks()
        {
            return this.books;
        }    
    }
}
