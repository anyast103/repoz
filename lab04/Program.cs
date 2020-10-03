using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Посчитать кол-во знаков препинания в нем ");
            Console.WriteLine("Я !! пажилая?.., криветочка-;:" + " " + "Ответ: "+GetCountPunctitationSymbols(@"Я !! пажилая?.., криветочка-;:"));
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Разбить текст на отдельные предложения: Я в дороге. Не звони, я перезвоню! Целую.");
            GetSplitProposal("Я в дороге. Не звони, я перезвоню! Целую.")
                .ForEach(x=>Console.WriteLine(x));
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Создать массив уникальных слов в тексте и вывести их на экран через запятую");
            GetUniqueWords("Я в дороге. Не звони, я перезвоню! Целую в дороге жопа не : звони Целую.")
                .ForEach(x => Console.Write(x + ", "));
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Найдите самое длинное слово во всем тексте. Выведите его на экран.");
            Console.Write("Слова: ");
            GetUniqueWords("Я в дороге. Не звони, я перезвоню! Целую в дороге жопа не : звони Целую.")
                .ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine("Ответ - " + GetMostLengthWord(GetUniqueWords("Я в дороге. Не звони, я перезвоню! Целую в дороге жопа не : звони Целую.")));
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine(@"Если самое длинное слово имеет четную длину - выведите вторую половину на экран
Если нечетное - замените центральный символ на символ * ");
            Console.WriteLine(GetMostLengthWord(GetUniqueWords("Я в дороге. Не звони, я перезвоню! Целую в дороге жопа не : звони Целую.")) + "->"
                + GetParity(GetMostLengthWord(GetUniqueWords("Я в дороге. Не звони, я перезвоню! Целую в дороге жопа не : звони Целую."))));
            Console.WriteLine(GetMostLengthWord(GetUniqueWords("Я в дороге. Не звони, я перезвон! Целую в дороге жопа не : звони Целую.")) + "->"
                    + GetParity(GetMostLengthWord(GetUniqueWords("Я в дороге. Не звони, я перезвон! Целую в дороге жопа не : звони Целую."))));
            Console.WriteLine("-------------------------------------------------------------------");
        }

        static string GetParity(string word)
        {
            if (word.Length % 2 == 0)
                return word.Remove(0, word.Length / 2);
            else
            {
                word = word.Remove(word.Length / 2, 1);
                return word.Insert(word.Length / 2, "*");
            }
        }
        static string GetMostLengthWord(List<string> words)
        {
            var mostLength = 0;
            var res = "";
            foreach(var e in words)
            {
                if (mostLength<=e.Length)
                {
                    mostLength = e.Length;
                    res = e;
                }
            }
            return res;
        }

        static int GetCountPunctitationSymbols(string text)
        {
            var res = 0;
            var symbols = new char[] { ',', '.', ':', '!', '?', ';', '"', '-'};
            foreach (var e in text)
                if (symbols.Contains(e))
                    res++;
            return res;
        }

        static List<string> GetSplitProposal(string text)
        {
            bool firstIteration = true;
            var res = new List<string>();
            var sb = new StringBuilder();
            foreach (var e in text)
            {
                if (e != '.' && e != ';' && e != '?' && e != '!')
                    sb.Append(e);
                else
                {
                    if (!firstIteration)
                        sb.Remove(0, 1);
                    firstIteration = false;
                    res.Add(sb.ToString());
                    sb.Clear();
                }
            }
            return res;
        }

        static List<string> GetUniqueWords(string words)
        {
            var res = new List<string>();
            var splitedText = words.Split(',', '.', ':', '!', '?', ';', '"', '-', ' ')
                .Where(x => x != "")
                .ToArray();
            foreach (var e in splitedText)
            {
                var word = e.ToLower();
                if (!res.Contains(word))
                    res.Add(word);
            }
            return res;
        }
    }
}
