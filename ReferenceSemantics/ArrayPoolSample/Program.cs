using System;
using System.Buffers;

namespace ArrayPoolSample
{
    class Program
    {
        const int ARRAYSIZE = 1024;

        static void Main()
        {
            UsingArrays();
            //LocalUseOfSharedPool()
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

        private static void UsingSimpleArrays()
        {
            Console.WriteLine(nameof(UsingSimpleArrays));
            for (int i = 0; i < 20; i++)
            {
                LocalUseOfArray(i);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void LocalUseOfArray(int i)
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

        private static void UsingArrays()
        {
            Console.WriteLine(nameof(UsingArrays));
            for (int i = 0; i < 20; i++)
            {
                GC.Collect(0);
                // LocalUseOfArray(i);
                LocalUseOfSharedPool(i);
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        private static void LocalUseOfSharedPool(int i)
        {
            int[] arr = ArrayPool<int>.Shared.Rent(ARRAYSIZE);
            ShowAddress($"simple array {i}", arr);
            FillTheArray(arr);
            UseTheArray(arr);
            ArrayPool<int>.Shared.Return(arr);
        }

        private static void UseTheArray(int[] arr)
        {

        }
    }
}
