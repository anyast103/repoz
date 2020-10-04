using System;
using System.Linq;
using System.Numerics;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetResult(new int[]{ 1,2,3,4,5}, new int[] { 1, 2, 3 , 4}));
            int[,] mas = { { 1, 2, 3}, { 4, 5, 6}, { 7, 8, 9}, { 10, 11, 12} };
            Console.WriteLine(GetResult(mas, new int[] { 7,8,9}));
            int[,] mas2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7,8,8} };
            Console.WriteLine(GetResult(mas, mas2));
        }

        static bool GetResult(int[] first, int[] second)
        {
            var flag = true;
            var firstEnter = true;
            int j = 0;
            for (int i = 0; i < first.Count(); i++)
            {
                if (firstEnter == true && first[i] == second[j])
                {
                    firstEnter = false;
                    j++;
                }
                else if ( j!= second.Count() && first[i] == second[j]  && firstEnter==false)
                    j++;
                else if (j == second.Count() && firstEnter == false)
                    break;
                else if(firstEnter==false) flag = false;
            }
            return flag;
        }

        static bool GetResult(int[,] first, int[] second)
        {
            var flag = true;
            int rows = first.GetUpperBound(0) + 1;
            int columns = first.Length / rows;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    if (first[i, j] != second[j] && columns != second.Count())
                        flag = false;
            return flag;
        }

        static bool GetResult(int[,] first, int[,] second)
        {
            var flag = 0;
            var countArraysInSecond = second.GetUpperBound(0) + 1;
            int rows = first.GetUpperBound(0) + 1;
            int columns = first.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (countArraysInSecond == i)
                    {
                        i = rows; 
                        j = columns;
                        break;
                    }
                    if (first[i, j] != second[i, j])
                    {
                        i++;
                        j = 0;
                        break;
                    }
                }
                flag++;
            }
            flag--;
            return flag == countArraysInSecond;
        }
    }
}
