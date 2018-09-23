using System;
using System.Linq;

namespace _03_SpanSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new StackOnlyType();
            string s = x.ToString();
        }

        private static void StringSample()
        {
            var str1 = "The quick brown fox jumped over the lazy dogs";
            ReadOnlySpan<char> span1 = str1.AsSpan();

        }

        private static void ArraySample()
        {
            int[] arr1 = Enumerable.Range(1, 100).ToArray();
            var span1 = arr1.AsSpan();
            var s1 = span1.ToString();
            var slice1 = span1.Slice(0, 10);
            for (int i = 0; i < slice1.Length; i++)
            {
                slice1[i] += 100;
            }
            foreach (var item in span1)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
