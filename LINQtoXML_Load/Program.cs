using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQtoXML_Load {
    class Program {
        static void Main (string[] args) {
            // SaveBooks ();
            LoadBooks ();
        }

        private static void LoadBooks () {
            //string xml = File.ReadAllText ("books.xml");
            //XElement doc = XElement.Parse (xml);

            XElement root = XElement.Load ("books.xml");

            //IEnumerable<XElement> bookElements = root.Elements ();
            //IEnumerable<XElement> authors = bookElements.Elements ("author");
            //foreach (XElement author in authors)
            //    Console.WriteLine ((string) author);

            //root.Elements ()
            //    .Elements ("author")
            //    .Select (authorElement => (string) authorElement)
            //    .ToList ()
            //    .ForEach (author => Console.WriteLine (author));

            IReadOnlyList<Book> books = root.Elements ()
                .Select (bookElement => Book.FromXElement (bookElement))
                .ToList ();
            foreach (Book book in books)
                Console.WriteLine (book);
        }

        private static void SaveBooks () {
            IReadOnlyList<Book> books = new[] {
                new Book ("111", "Автор", 2019),
                new Book ("222", "Автор", 2020),
                new Book ("333", "Автор", 2019),
                new Book ("444", "Автор", 2021),
            };

            XElement booksRoot = new XElement ("books", books.Select (book => book.ToXElement ()));
            Console.WriteLine (booksRoot);
            booksRoot.Save ("books-generated.xml");
        }
    }
}
