using System;
using System.Data;

namespace lab02_ver2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для начала, выберите фигуру:");
            int shf;
            Console.WriteLine("Король - 1, Ферзь - 2, Ладья - 3, Слон - 4, Конь - 5, Пешка - 6 ");
            do
            {
                shf = Convert.ToInt32(Console.ReadLine());
                if (shf < 1 || shf > 6)
                    Console.WriteLine("Нет такой фигуры. Попробуйте ещё раз");
                else
                    break;
            } while (shf < 1 || shf > 6);
            Console.WriteLine("Введите конечные координаты:\nПо горизонтали - ABCDEFGH\nПо вертикали - 12345678\nПример C5");
            int endver = 0;
            int endgor = 0;
            ProvFig(ref endgor, ref endver);
            Console.WriteLine("Введите конечные координаты:\nПо горизонтали - ABCDEFGH\nПо вертикали - 12345678\nПример C5");
            int endgor2 = 0;
            int endver2 = 0;
            ProvFig(ref endgor2, ref endver2);
            if (shf == 1)
                Korol(endgor, endgor2, endver, endver2);
            else if (shf == 2)
                Ferz(endgor, endgor2, endver, endver2);
            else if (shf == 3)
                Lad(endgor, endgor2, endver, endver2);
            else if (shf == 4)
                Slon(endgor, endgor2, endver, endver2);
            else if (shf == 5)
                Kon(endgor, endgor2, endver, endver2);
            else if (shf == 6)
                Peshka(endgor, endgor2, endver, endver2);
        }
        static void ProvFig(ref int x, ref int y)
        {
            string koor1;
            string gor;
            char gk;
            int goriz;
            int vert;
            do
            {
                koor1 = Console.ReadLine();
                gk = koor1[0];
                goriz = Convert.ToInt16(gk);
                gor = Convert.ToString(koor1[1]);
                vert = Convert.ToInt32(gor);
                if (goriz < 65 || goriz > 72 || vert < 1 || vert > 8)
                    Console.WriteLine("Не верно. Попробуй ещё раз.");
                else
                {
                    x += goriz;
                    y += vert;
                    break;
                }
            } while (goriz < 65 || goriz > 72 || vert < 1 || vert > 8);
        }
        static void Korol(int x1, int x2, int y1, int y2)
        {
            int razngor = Math.Abs(x1 - x2);
            int raznver = Math.Abs(y1 - y2);
            if (razngor == 1 && raznver == 1)
                Console.WriteLine("Верно");
            else if (razngor == 0 && raznver == 1)
                Console.WriteLine("Верно");
            else if (razngor == 1 && raznver == 0)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void Kon(int x1, int x2, int y1, int y2)
        {
            int razngor = Math.Abs(x1 - x2);
            int raznver = Math.Abs(y1 - y2);
            if (razngor == 1 && raznver == 2)
                Console.WriteLine("Верно");
            else if (razngor == 2 && raznver == 1)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void Ferz(int x1, int x2, int y1, int y2)
        {
            int razngor = Math.Abs(x1 - x2);
            int raznver = Math.Abs(y1 - y2);
            if (razngor == 0 && raznver > 0)
                Console.WriteLine("Верно");
            else if (raznver == 0 && razngor > 0)
                Console.WriteLine("Верно");
            else if (razngor != 0 && raznver != 0 && razngor == raznver)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void Lad(int x1, int x2, int y1, int y2)
        {
            int razngor = Math.Abs(x1 - x2);
            int raznver = Math.Abs(y1 - y2);
            if (razngor == raznver && raznver != 0 && razngor != 0)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void Slon(int x1, int x2, int y1, int y2)
        {
            int razngor = Math.Abs(x1 - x2);
            int raznver = Math.Abs(y1 - y2);
            if (razngor == 0 && raznver > 0)
                Console.WriteLine("Верно");
            else if (razngor > 0 && raznver == 0)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void Peshka(int x1, int x2, int y1, int y2)
        {
            int razngor = Math.Abs(x1 - x2);
            int raznver = Math.Abs(y1 - y2);
            if (y1 == 2)
            {
                if (razngor == 0 && raznver == 2)
                    Console.WriteLine("Верно");
                else if (razngor == 0 && raznver == 1)
                    Console.WriteLine("Верно");
                else
                    Console.WriteLine("Не верно");
            }
            else if (y1 == 1)
                Console.WriteLine($"Не верные начальные координаты");
            else
            {
                if (razngor == 0 && raznver == 1)
                    Console.WriteLine("Верно");
                else
                    Console.WriteLine("Не верно");
            }
        }
    }
}