using System;
using System.Collections.Generic;
using System.Linq;

namespace Midterm
{
    public class Book
    {
        public string Title {get; set;}
        public string ISBN {get; set;}
        public string Publisher {get; set;}
        public string PublishDate {get; set;}
        public string Author {get; set;}
        public string Pages {get; set;}

        public override string ToString()
        {
            string output = $"{this.Title}";
            return output;
        }

    }
}
