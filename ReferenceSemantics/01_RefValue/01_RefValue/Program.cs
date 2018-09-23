using System;

namespace _01_RefValue
{
    readonly struct MyStruct
    {
        public MyStruct(int myProperty) => MyProperty = myProperty;

        public int MyProperty { get; }
    }

    readonly ref struct MyStruct2
    {
        public MyStruct2(int myProperty) => MyProperty = myProperty;

        public int MyProperty { get; }
    }

    TBD X
    {
        public int A { get; set; }
    }

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

            MyStruct ms1 = new MyStruct(1);
            // boxing
            string s = ms1.ToString();
            object o = ms1;

            //MyStruct2 ms2 = new MyStruct2(1);
            //string s1 = ms2.ToString();
            //object o2 = ms2;

        }
    }
}
