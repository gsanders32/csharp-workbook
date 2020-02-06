using System;
using System.Collections.Generic;

namespace palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            GetWord.NewWord();
        }

    }
    class GetWord
    {
        public static void NewWord()
        {
            Console.WriteLine("Enter Word");
            Word item = new Word(Console.ReadLine().Trim());

        }
    }
    class Word
    {
        public string TheWord { get; set; }
        public Word(string item)
        {
            this.TheWord = item;
            WordArray(item);
        }

        public void WordArray(string item)
        {
            string[] lettersForward = new string[item.Length];
            string[] lettersRevserse = new string[item.Length];
            int i = 0;
            do
            {
                lettersForward[i] = item.Substring(i, 1);
                i++;
            } while (i < item.Length);
            int count = 0;
            for (int j = lettersForward.Length; j != 0; j--)
            {
                lettersRevserse[count] = lettersForward[j - 1];
                count++;
            }

            TheTest(lettersForward, lettersRevserse, item);
        }
        public void TheTest(string[] item1, string[] item2, string item3)
        {

            int count = 0;
            for (int i = 0; i < item1.Length; i++)
            {
                if (item1[i].ToLower() != item2[i].ToLower())
                {
                    Console.WriteLine($"{item1[i]} = {item2[i]} No");
                    Console.WriteLine($"\n{item3}: is not a Palindrome!");
                    i = item1.Length;
                }
                else
                {
                    Console.WriteLine($"{item1[i]} = {item2[i]} Yes");
                    count++;
                }
            }
            if (count == item1.Length)
            {
                Console.WriteLine($"\n{item3}: is a Palindrome!");
            }

        }
    }
}
