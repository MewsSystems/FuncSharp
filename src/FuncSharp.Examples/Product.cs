using System;

namespace FuncSharp.Examples
{
    public class User : Product3<string, string, DateTime>
    {
        public User(string firstName, string lastName, DateTime birthDate)
            : base(firstName, lastName, birthDate)
        {
        }

        public string FirstName { get { return ProductValue1; } }
        public string LastName { get { return ProductValue2; } }
        public DateTime BirthDate { get { return ProductValue3; } }
    }
}
