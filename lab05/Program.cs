using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace NewNamespace
{
    class Program
    {
        static double GetFactorial(double number)
        {
            if (number == 0)
                return 0;
            var res = 1;
            for (int i = 1; i <= number; i++)
                res *= i;
            return res;
        }

        private static ConsoleColor GetRandomConsoleColor(Random rnd)
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(rnd.Next(consoleColors.Length));
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo btn;
            do
            {
                Thread.Sleep(200);
                Random random = new Random();
                Console.ForegroundColor = GetRandomConsoleColor(random);
                Console.Write("Введите число, из которого хотите получить факторил: ");
                var num = double.Parse(Console.ReadLine());
                var res = GetFactorial(num);
                var maxLength = res
                    .ToString()
                    .ToCharArray()
                    .Count();
                Console.Write("╔");
                for (int i = 0; i < maxLength; i++)
                    Console.Write("═");
                Console.WriteLine("╗");
                Console.WriteLine("║" + res + "║");
                Console.Write("╚");
                for (int i = 0; i < maxLength; i++)
                    Console.Write("═");
                Console.WriteLine("╝");
                Console.WriteLine(@"Нажмите 'Esc', если хотите остановиться или 'Enter', если продолжить");
                btn = Console.ReadKey();
                if (btn.Key == ConsoleKey.Escape)
                    break;
                Console.Clear();
            } while (btn.Key == ConsoleKey.Enter);
        }
    }
}

