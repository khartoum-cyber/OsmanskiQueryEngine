using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsmanskiQueryEngine
{
    public class User
    {
        public User(string fullname, string email, int age)
        {
            FullName = fullname;
            Email = email;
            Age = age;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
