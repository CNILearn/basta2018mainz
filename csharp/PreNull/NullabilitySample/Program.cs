using System;
using System.Runtime.CompilerServices;


namespace NullabilitySample
{
    class Program
    {
        static void Main()
        {
            var b1 = new Book("Professional C# 8");

            Console.WriteLine(b1.Publisher.ToLower());
        }
    }
}
