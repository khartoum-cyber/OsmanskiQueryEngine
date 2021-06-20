using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OsmanskiQueryEngine
{
    public class QueryEngine
    {
        List<User> Users { get; set; } = new List<User>();

        private void DisplayContactDetails(User user)
        {
            Console.WriteLine($"User: {user.FullName}, {user.Email}, {user.Age}");
        }

        public void DisplayContactsDetails(List<User> users)
        {
            foreach (var user in users)
            {
                DisplayContactDetails(user);
            }
        }
        public void AddContact(User user)
        {
            Users.Add(user);
        }
        public void DisplayAge(int age)
        {
            var contact = Users.FirstOrDefault(c => c.Age >= age);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
            }
            else
            {
                DisplayContactDetails(contact);
            }
        }
        public void DisplayAllContacts()
        {
            DisplayContactsDetails(Users);
        }
        public void DisplayMatchingContacts(string searchPhrase, int searchAge2)
        {
            var matchingContacts = Users.Where(c => c.FullName.Contains(searchPhrase) && c.Age == searchAge2).Select(c => c.Email).ToList();

            DisplayEmailDetails(matchingContacts);
        }

        private void DisplayEmailDetails(List<string> matchingContacts)
        {
            for (int i = 0; i < matchingContacts.Count; i++)
            {
                Console.WriteLine($"Email is: {matchingContacts.FirstOrDefault()}");
            }
        }

        public void DisplayMatchingFullName(string searchEmail)
        {
            var matchingFullName = Users.Find(c => searchEmail.Contains("@hibernatingrhinos.com") || searchEmail.Contains("@ravendb.net"));

            if (!IsValidEmail(searchEmail))
            {
                Console.WriteLine("Wrong email format.");
            }
            else
            {
                Console.WriteLine($"Full name :{matchingFullName.FullName}, Email : {matchingFullName.Email}");
            }

            //Contains(searchEmail, "@hibernatingrhinos.com") || c.Email.EndsWith("@hibernatingrhinos.com").Select(c => c.Email));
        }
        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
