using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public int id { get; set; }
        public string author { get; set; }
        public string title { get; set;}
        public string year { get; set; }
        public Book(string title, string author, string year, int newId=0)
        {
            id = newId;
            this.title = title;
            this.author = author;
            this.year = year;
        }
    }
}
