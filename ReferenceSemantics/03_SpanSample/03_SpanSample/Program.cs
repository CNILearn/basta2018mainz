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
            Console.WriteLine(s);
            ArraySample();
            StringSample();
        }

        private static void StringSample()
        {
            Console.WriteLine(nameof(StringSample));
            var str1 = "The quick brown fox jumped over the lazy dogs";

            // create a span from a string
            ReadOnlySpan<char> span1 = str1.AsSpan();

            // create a span referencing a buffer large enough to hold a new string
            Span<char> span2 = new Span<char>(new char[46]);

            // copy the first string to the second span - if the buffer is large enough
            span1.TryCopyTo(span2);
            Console.WriteLine(span2.ToString());

            // get the index of a string in the span
            int ix = span2.IndexOf("lazy");

            // replace a string within the string
            ReadOnlySpan<char> replaceSpan = "slow".AsSpan();
            Span<char> toReplace = span2.Slice(ix, 4);
            replaceSpan.TryCopyTo(toReplace);

            Console.WriteLine(span2.ToString());
        }

        private static void ArraySample()
        {
            Console.WriteLine(nameof(ArraySample));
            int[] arr1 = Enumerable.Range(1, 100).ToArray();
            var span1 = arr1.AsSpan();
            var slice1 = span1.Slice(0, 10);
            for (int i = 0; i < slice1.Length; i++)
            {
                slice1[i] += 100;
            }
            foreach (var item in span1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
