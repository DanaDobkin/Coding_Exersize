using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace BookLibraryProject
{
    class Book
    {
        // Data Members
        private string code;

        // Constructor
        public Book(string code)
        {
            this.code = code;
        }

        // Methods
        public bool DoesThisBookExistInLibrary(List<Book> library)
        {
            if (library != null)
            {
                foreach (Book b in library)
                {
                    if (this.code.Equals(b.GetCode()))
                        return true;
                }
            }
            else
                Console.WriteLine("This book is null");

            return false;
        }
        public bool VerifyBookCode()
        {
            if (this.code == null)
            {
                return false;
            }
            else if (this.code.Length > 6 || this.code.Length < 6)
            {
                return false;
            }
            else if (!Regex.IsMatch("[A-Z]", this.code)) // couldn't find letters
            {
                return false;
            }
            else if (!Regex.IsMatch("[1-9]", this.code)) // couldn't find numbers
            {
                return false;
            }

            return true;
        }

        // Get Methods
        public string GetCode()
        {
            return this.code;
        }








        //else if (this.code.Count(f => (f == "[A-Z]")) > 2) // more than two letters
        //{
        //    return false;
        //}
    }
}
