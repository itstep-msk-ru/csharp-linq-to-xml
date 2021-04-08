using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQtoXML_Load {
    class Book {
        public string Title { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }

        public Book (string title, string author, int? year) {
            Title = title;
            Author = author;
            Year = year;
        }

        public XElement ToXElement () => new XElement ("book",
            new XElement ("title", this.Title),
            new XElement ("author", this.Author),
            new XElement ("year", this.Year));

        public static Book FromXElement (XElement bookElement) => new Book (
            (string) bookElement.Element ("title"),
            (string) bookElement.Element ("author"),
            (int?) bookElement.Element ("year"));

        public override string ToString () => $"\"{Title}\", {Author}, {Year}";
    }
}
