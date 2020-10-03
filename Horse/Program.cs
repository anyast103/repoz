using System;

namespace Horse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsHorse(new string[2] { "A1", "B3" }));
            Console.WriteLine(IsHorse(new string[2] { "D5", "E3" }));
            Console.WriteLine(IsHorse(new string[2] { "A1", "A6" }));
            Console.WriteLine(IsHorse(new string[2] { "A2", "B3" }));
            Console.WriteLine(IsHorse(new string[2] { "A1", "A3" }));
        }
        public static bool IsHorse(string[] str)
        {
            var begin = NumberString(str[0]);
            var end = NumberString(str[1]);
            return (Math.Abs(begin - end) == 1 || Math.Abs(begin - end) == 3);
        }

        public static double NumberString(string str)
        {
            var num = 0;
            for (int i = 0; i < str.Length; i++)
            {
                num += str[i];
            }
            return num;
        }
    }
}
