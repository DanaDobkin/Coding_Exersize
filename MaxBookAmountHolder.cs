using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryProject
{
    class MaxBookAmountHolder
    {
        // Data Members
        protected string id;
        protected string lastName;
        protected int bookAmount;

        // Constructor
        public MaxBookAmountHolder(string id, string lastName, int bookAmount)
        {
            this.id = id;
            this.lastName = lastName;
            this.bookAmount = bookAmount;
        }

        // Default Constructor
        public MaxBookAmountHolder()
        {
            this.id = "";
            this.lastName = "";
            this.bookAmount = 0;
        }

        // Get Methods
        public string GetID()
        {
            return this.id;
        }
        public string GetLastName()
        {
            return this.lastName;
        }

        public int GetMaxAmountOfBooks()
        {
            return this.bookAmount;
        }

        // Set Methods
        public void SetID(string id)
        {
            this.id = id;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public void SetBookAmount(int bookAmount)
        {
            this.bookAmount = bookAmount;
        }

        // ToString
        public override string ToString()
        {
            string s = "The Maximum Books Amount Holder Of The Library Is: \n";
            s += "Last Name: " + this.lastName + "\n";
            s += "ID: " + this.id + "\n";
            s += "Book Amount: " + this.bookAmount;

            return s;
        }
    }
}
