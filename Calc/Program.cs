using System;
using System.Linq;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------");
            Console.Write("2 + 3" + "->");
            Console.Write(GetCalc("2 + 3"));
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.Write("2          +      3" + "->");
            Console.Write(GetCalc("2          +      3"));
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.Write("1 / 2" + "->");
            Console.Write(GetCalc("1 / 2"));
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.Write("1 / 0" + "->");
            Console.Write(GetCalc("1 / 0"));
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.Write("1 ! 0" + "->");
            Console.Write(GetCalc("1 ! 0"));
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
        }

        static string GetCalc(string text)
        {
            var parseText = text
                .Split()
                .Where(x => x != "")
                .ToArray();
            var firstNumber = double.Parse(parseText[0]);
            var secondNumber = double.Parse(parseText[2]);
            switch (parseText[1])
            {
                case "+":
                    return (firstNumber + secondNumber).ToString();
                case "-":
                    return (firstNumber - secondNumber).ToString();
                case "*":
                    return (firstNumber * secondNumber).ToString();
                case "/":
                    if (secondNumber != 0)
                        return (firstNumber / secondNumber).ToString();
                    else return "Недопустимая операция!";
                default:
                    return "Недопустимая операция!";

            }


        }
    }
}
