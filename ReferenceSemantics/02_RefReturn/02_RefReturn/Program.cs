using System;
using System.Linq;

namespace _02_RefReturn
{
    class Program
    {
        static void Main()
        {
            var c = new Container(Enumerable.Range(0, 10).Select(x => x).ToArray());
            ref int item = ref c.GetItem(3);
            item = 33;
            c.ShowAll();
            Console.WriteLine();

            ref readonly int item2 = ref c.GetItem2(4);
            // item2 = 44; // can't change!

            int a = 1;
            c.PassByReference(a);
            Console.WriteLine(a);

        }
    }
}
