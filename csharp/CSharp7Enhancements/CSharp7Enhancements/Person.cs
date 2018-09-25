using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Enhancements
{
    public class Person
    {
        public Person(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);

        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
