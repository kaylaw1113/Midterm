using System;
using System.Collections.Generic;
using System.Linq;


namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            //using(var db = new AppDbContext())
            {
                try
                {

                    //no matter what, delete and then create
                    //db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    if (!db.Book.Any())
                    {
                        List<Book> Book = new List<Book>()
            {
                new Book()
                {
                    Title = "Pro ASP.NET Core MVC 2 7th ed. Edition",
                    Publisher = "Apress",
                    PublishDate = "October 25, 2017",
                    Author = "Adam Freeman",
                    Pages = "1017"
                },
                new Book()
                {
                    Title = "Pro Angular 6 3rd Edition",
                    Publisher = "Apress",
                    PublishDate = "October 10, 2018",
                    Author = "Adam Freeman",
                    Pages = "776"
                },
                new Book()
                {
                    Title = "Programming Microsoft Azure Service Fabric (Developer Reference) 2nd Edition",
                    Publisher = "Microsoft Press",
                    PublishDate = "May 25, 2018",
                    Author = "Haishi Bai",
                    Pages = "528"
                }
                };

                        db.Book.AddRange(Book);

                        db.SaveChanges();

                    }
                    else
                    {
                        var book = db.Book.ToList();

                        //LINQ where
                        //published by APress
                        var filteredResult = from b in db.Book
                                             where b.Publisher = "APress"
                                             select b.Title;
                        Console.WriteLine(filteredResult);

                        // foreach(var b in filteredResult)
                        // {
                        //    Console.WriteLine(filteredResult);
                        // }

                        //LINQ FIND
                        //LINQ orderby
                        using (var db = new AppDbContext())
                        {
                            var orderedLastName = from b in db.Book
                                                  orderby b.Author.LastName
                                                  select b;

                            Console.WriteLine(orderedLastName);
                        }

                        using (var db = new AppDbContext())
                        {
                            var orderedBooks = from b in db.Book
                                               orderby b.Title descending
                                               select b;

                            Console.WriteLine(orderedBooks);
                        }
                        //LINQ Groupby and Orderby

                        //GroupBy
                        using (var db = new AppDbContext())
                        {

                            var groupedResult = from b in db.Book
                                                group b by b.Publisher;

                            foreach (var publisher in groupedResult)
                            {
                                Console.WriteLine($"Publishing Group: {publisher.Key}");

                                foreach (Book b in publisher)
                                {
                                    Console.WriteLine(b);
                                }
                            }
                        }

                        
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }
    }
}
