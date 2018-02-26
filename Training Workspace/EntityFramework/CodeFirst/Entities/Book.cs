using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate{ get; set; }
        public decimal Price{ get; set; }
        public int AuthorID{get; set; }
        public Author Author { get; set; }
    }
}
