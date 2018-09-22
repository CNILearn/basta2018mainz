using System;
using System.Runtime.CompilerServices;

[module:NonNullTypes]

namespace NullabilitySample
{
    class Program
    {
        static void Main(string[] args)
        {
            var b1 = new Book("Professional C# 8");

            if (b1.Publisher != null)
            {
                Console.WriteLine(b1.Publisher.ToLower());
            }
            Console.WriteLine(b1.Publisher?.ToLower());

            var b2 = new LegacyBook("Professional C# 6");
            Console.WriteLine(b2.Publisher.ToLower());
        }
    }
}
