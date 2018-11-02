using System;
using System.Collections.Generic;
using System.Linq;

namespace Midterm
{
    public class Author
    {
         public string FirstName {get; set;}
        //lastname
        public string LastName {get; set;}
        public string Title {get; set;}

        public override string ToString()
        {
            string output = $"{this.FirstName} {this.LastName}";
            return output;
        }

       
    }
}
