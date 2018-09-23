using System;

namespace _02_RefReturn
{
    public class Container
    {
        public Container(int[] data) => _data = data;

        private int[] _data;

        public ref int GetItem(int index) => ref _data[index];

        public ref readonly int GetItem2(int index) => ref _data[index];

        public void PassByReference(in int x)
        {
            // x = 42;
        }

        public void ShowAll()
        {
            Console.WriteLine(string.Join(", ", _data));
            Console.WriteLine();
        }
    }
}
