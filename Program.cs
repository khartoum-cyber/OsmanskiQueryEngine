using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OsmanskiQueryEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello from QueryEngine");

            Console.WriteLine("1 - Add user.");
            Console.WriteLine("2 - Display users with age greater than given.");
            Console.WriteLine("3 - Display all users.");
            Console.WriteLine("4 - Display users' emails by their name and age.");
            Console.WriteLine("5 - Display users registered at '@ravendb.net' or '@hibernatingrhinos.com'.");
            Console.WriteLine("0 - Exit app.");

            var userInput = Console.ReadLine();

            var queryEngine = new QueryEngine();


            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Insert full name");
                        var fullName = Console.ReadLine();
                        Console.WriteLine("Insert email");
                        var email = Console.ReadLine();
                        Console.WriteLine("Insert age");
                        var age = Convert.ToInt32(Console.ReadLine());

                        if ((fullName.Length >= 2) && queryEngine.IsValidEmail(email))
                        {
                            User newContact = new User(fullName, email, age);
                            queryEngine.AddContact(newContact);

                            Console.WriteLine("User created succesfully.");
                        }
                        else
                        {
                            Console.WriteLine("Oops! Name is shorter than 2 characters or email is in wrong format. Try again.");
                        }

                        break;

                    case "2":
                        Console.WriteLine("Insert age to be found");
                        var searchAge = Convert.ToInt32(Console.ReadLine());

                        queryEngine.DisplayAge(searchAge);
                        break;

                    case "3":
                        Console.WriteLine("Displaying all contacts");
                        queryEngine.DisplayAllContacts();
                        break;

                    case "4":
                        Console.WriteLine("Enter a fullname to search by");
                        var searchPhrase = Console.ReadLine();

                        Console.WriteLine("Enter an age to search by");
                        var searchAge2 = Convert.ToInt32(Console.ReadLine());

                        queryEngine.DisplayMatchingContacts(searchPhrase,searchAge2);
                        break;

                    case "5":
                        Console.WriteLine("Enter an email: ");
                        var searchEmail = Console.ReadLine();

                        queryEngine.DisplayMatchingFullName(searchEmail);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }
                userInput = Console.ReadLine();
                
            }

            //List<User> Users = new List<User>() {
            //                        new User(){ FullName = "John Wick", email = "abc@wp.pl",  age = 31},
            //                        new User(){ Email = "xyz@wp.pl", FullName = "Gandalf", Age = 69},
            //                        new User(){ Email = "qwerty@wp.pl", FullName = "Luke Skywalker", Age = 28},
            //                    };

            //var newUser = from u in Users
            //              where u.Age > 30 && u.FullName == "John Wick"
            //              select u.Email;

            //foreach (var item in newUser)
            //{
            //    Console.WriteLine(item);
            //}

            //var newUser2 = from i in Users
            //               where i.Email == "abc@wp.pl" || i.Email == "xyz@wp.pl"
            //               select new { FullName = i.FullName};

            //newUser2.ToList().ForEach(i => Console.WriteLine(i.FullName));

            // Błąd ;/
            //IEnumerable<User> newUser = (IEnumerable<User>)(from User in usersList
            //                                                where User.FullName == "John wick" && User.Age > 30
            //                                                select User.Email);

            //IEnumerable<User> newUser = from x in Users.Where(x => x.FullName == "John Wick" || x.Email == "abc@wp.pl" || x.Age == 30)
            //              .Select(x => new User { Email = x.Email, FullName = x.FullName, Age = x.Age });

        }
    }
}
