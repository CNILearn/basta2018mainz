using System;

namespace _01_RefValue
{
    class Program
    {
        static void ChangeValue(X x1)
        {
            x1.A = 2;
        }

        static void Main()
        {
            var myX = new X
            {
                A = 1
            };

            ChangeValue(myX);
            Console.WriteLine(myX.A);
        }
    }
}
