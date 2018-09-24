using System;
using System.Buffers;
using System.Linq;

namespace ArrayPoolSample
{
    class Program
    {
        const int ARRAYSIZE = 1024;

        static void Main()
        {
          //  ArrayPool1();
            UsingArrays(pool: false, collect: false);
        }

        public static void ArrayPool1()
        {
            for (int i = 0; i < 10; i++)
            {
                int arrayLength = (i + 1) << 10;
                int[] arr = ArrayPool<int>.Shared.Rent(arrayLength);
                Console.WriteLine($"requested an array of {arrayLength} and received {arr.Length}");
                for (int j = 0; j < arrayLength * j; j++)
                {
                    arr[j] = j;
                }
                ArrayPool<int>.Shared.Return(arr, clearArray: true);
            }
        }

        private static void UsingArrays(bool pool = false, bool collect = false)
        {
            Console.WriteLine(nameof(UsingArrays));
            for (int i = 0; i < 20; i++)
            {
                if (collect)
                {
                    GC.Collect(0);  // avoid with production code
                }
                if (pool)
                {
                    UseArrayFromPool(i);
                }
                else
                {
                    UseArray(i);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        private static void UseArray(int i)
        {
            int[] arr = new int[ARRAYSIZE];
            ShowAddress($"simple array {i}", arr);
            FillTheArray(arr);
            UseTheArray(arr);
        }

        private static void FillTheArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
        }

        unsafe private static void ShowAddress(string name, int[] item)
        {
            fixed (int* addr = item)
            {
                Console.WriteLine($"\t0x{(ulong)addr:X}");
            }
        }

        private static void UseArrayFromPool(int i)
        { 
            int[] arr = ArrayPool<int>.Shared.Rent(ARRAYSIZE);
            ShowAddress($"simple array {i}", arr);
            FillTheArray(arr);
            UseTheArray(arr);
            ArrayPool<int>.Shared.Return(arr);
        }

        private static void UseTheArray(int[] arr)
        {
            int sum = arr.Sum();
           // Console.WriteLine($"use array with sum: {sum}");
        }
    }
}
