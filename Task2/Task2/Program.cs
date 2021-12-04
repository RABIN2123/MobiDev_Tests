using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        /// <summary>
        /// amount parse into numbers
        /// </summary>
        /// <param name="amount"></param>
        protected static List<int> parse_into_numbers(int amount)
        {
            int digit=(int)Math.Log10(amount) + 1;
            int i = 0;
            List<int> numbers = new List<int>();
            do
            {
                if (amount % 10 != 0)
                {
                    numbers.Add((amount % 10) * (int)Math.Pow(10, i));
                }
                i++;
            }
            while ((amount /= 10) != 0);
            numbers.Reverse();
            return numbers;
        }
        /// <summary>
        /// convert numbers to word
        /// </summary>
        /// <param name="numbers"></param>
        protected static string convert(List<int> numbers)
        {
            Dictionary<int, string> numb_into_word = new Dictionary<int, string>(){
                {0, "zero"},{1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}, {5, "five"},
                {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"}, {10, "ten"},
                {11, "eleven"}, {12, "twelve"}, {13, "thirteen"}, {14, "fourteen"},
                {15, "fiftteen"},{16, "sixteen"},{17, "seventeen"},{18, "eighteen"},{19, "nineteen"},{20, "twenty"},
                {30, "thirty" },{40,"forty"},{50,"fifty"},{ 60,"sixty"},{ 70,"seventy"},{ 80,"eighty"},{90,"ninety"}
            };
            string word="";
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != 0 || (i == 0 && numbers[i] != 0))
                {
                    if (numbers[i] < 100)
                    {
                        if (numbers[i] < 10 || numbers[i] >= 20)
                        {
                            word += numb_into_word[numbers[i]];
                            if (numbers.Count - i > 1)
                            {
                                word += "-";
                            }
                            else
                            {
                                word += " ";
                            }
                        }
                        else
                        {
                            word += numb_into_word[numbers[i] + numbers[i + 1]];
                            numbers[i + 1] = 0;
                            word += " ";
                        }
                    }
                    else if (numbers[i] >= 100 && numbers[i] < 1000)
                    {
                        word += numb_into_word[numbers[i] / 100] + " hundred ";
                    }
                    else if (numbers[i] >= 1000 && numbers[i] < 100000)
                    {
                        if ((numbers[i] >= 20000 && numbers.Count > 1) && numbers[i + 1] >= 1000)
                        {
                            word += numb_into_word[numbers[i] / 1000] + "-" + numb_into_word[numbers[i + 1] / 1000];
                            numbers[i + 1] = 0;
                        }
                        else
                        {
                            if (numbers.Count-i == 1 || numbers[i+1]/1000==0)
                            {
                                word += numb_into_word[numbers[i] / 1000];
                            }
                            else
                            {
                                word += numb_into_word[numbers[i] / 1000 + numbers[i + 1] / 1000];
                                numbers[i + 1] = 0;
                            }
                        }
                        word += " thousand ";
                    }
                    else if (numbers[i] >= 100000)
                    {
                       word += numb_into_word[numbers[i] / 100000];
                        if (numbers.Count>1 && numbers[i + 1] / 1000 != 0)
                        {
                            if (numbers.Count >= 3 && numbers[i + 1] < 20000 && numbers[i+2]/1000!=0)
                            {
                                word += " hundred " + numb_into_word[numbers[i + 1] / 1000+ numbers[i + 2] / 1000];
                                numbers[i + 2] = 0;
                            }
                            else
                            {
                                word += " hundred "+numb_into_word[numbers[i + 1] / 1000];
                                if (numbers.Count >= 3 && numbers[i + 2] / 1000 != 0)
                                {
                                word += "-"+numb_into_word[numbers[i + 2] / 1000];
                                    numbers[i + 2] = 0;
                                }
                            }
                            numbers[i + 1] = 0;
                        }
                        word += " thousand ";
                    }
                }
            }
            return word;
        }
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true) {
                again:
                Console.Write("Input: ");
                int amount = int.Parse(Console.ReadLine());
                if (amount >= 1000000)
                {
                    Console.WriteLine("Max number = 999999");
                    goto again;
                }
                List<int> numbers=parse_into_numbers(amount);
                string word=convert(numbers);
                Console.WriteLine("Output: "+word);
            }
        }
    }
}
