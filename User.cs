using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsmanskiQueryEngine
{
    public class User
    {
        public User(string Email, string FullName, int Age)
        {
            this.Email = Email;
            this.FullName = FullName;
            this.Age = Age;
        }

        public string Email;
        public string FullName;
        public int Age;
    }
}
