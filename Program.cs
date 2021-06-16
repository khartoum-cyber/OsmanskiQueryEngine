using System;
using System.Collections.Generic;
using System.Linq;

namespace OsmanskiQueryEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            List<User> Users = new List<User>() {
                                    new User(){ Id = 1, Email = "abc@wp.pl", FullName = "John Wick", Age = 31},
                                    new User(){ Id = 2, Email = "xyz@wp.pl", FullName = "Gandalf", Age = 69},
                                    new User(){ Id = 3, Email = "qwerty@wp.pl", FullName = "Luke Skywalker", Age = 28},
                                };

            var newUser = from u in Users
                          where u.Age > 30 && u.FullName == "John Wick"
                          select u.Email;

            foreach (var item in newUser)
            {
                Console.WriteLine(item);
            }

            var newUser2 = from i in Users
                           where i.Email == "abc@wp.pl" || i.Email == "xyz@wp.pl"
                           select new { FullName = i.FullName};

            newUser2.ToList().ForEach(i => Console.WriteLine(i.FullName));

            // Błąd ;/
            //IEnumerable<User> newUser = (IEnumerable<User>)(from User in usersList
            //                                                where User.FullName == "John wick" && User.Age > 30
            //                                                select User.Email);

            //IEnumerable<User> newUser = from x in Users.Where(x => x.FullName == "John Wick" || x.Email == "abc@wp.pl" || x.Age == 30)
            //              .Select(x => new User { Email = x.Email, FullName = x.FullName, Age = x.Age });



            Console.ReadLine();
        }
    }
}
