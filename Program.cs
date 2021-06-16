using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OsmanskiQueryEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            List<User> usersList = new();

            var user1 = new User("abc@wp.pl", "John wick", 31);
            var user2 = new User("bjaksd@wp.pl", "Gandalf", 69);
            var user3 = new User("njdald@wp.pl", "Luke Skywalker", 29);

            usersList.Insert(0, user1);
            usersList.Insert(1, user2);
            usersList.Insert(2, user3);

            var newUser = from User in usersList
                          where User.Age > 30 && User.FullName == "John wick"
                          select User.Email;

            // Błąd ;/
            //IEnumerable<User> newUser = (IEnumerable<User>)(from User in usersList
            //                                                where User.FullName == "John wick" && User.Age > 30
            //                                                select User.Email);

            //IEnumerable<User> newUser = from x in usersList.Where(x => x.FullName == "John Wick" || x.Email == "abc@wp.pl" || x.Age == 30)
            //              .Select(x => new User { Email = x.Email, FullName = x.FullName, Age = x.Age });

            foreach (var item in newUser)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
