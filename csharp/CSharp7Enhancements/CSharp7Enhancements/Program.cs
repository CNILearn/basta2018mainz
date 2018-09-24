using System;

namespace CSharp7Enhancements
{
    class Program
    {
        static void Main(string[] args)
        {
            var kathi = new Person("Katharina", "Nagel");
            var steph = new Person("Stephanie", "Nagel");
            var t1 = (n: 42, kathi.FirstName);  // infer tuple names - C# 7.1
            Console.WriteLine(t1.FirstName);

            var t2 = (n: 42, FirstName: "Katharina");
            var thesame = t1 == t2;  // equals on tuples - C# 7.3
            Console.WriteLine(thesame);

            var kathi2 = new Person("Katharina", "Nagel");

            var t3 = (n: 42, person: kathi);
            var t4 = (n: 42, person: kathi2);
            Console.WriteLine(t3 == t4);

        }
    }
}
