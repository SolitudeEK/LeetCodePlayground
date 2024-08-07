using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 273. Integer To English Words
    /// </summary>
    public class IntToEnglish
    {
        public string NumberToWords(int num)
        {
            string[] map = new string[]
            {
                "Zero", "One", "Two", "Three", "Four", "Five", "Six",
                "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve",
                "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                "Eighteen", "Nineteen"
            };
            string[] map2 = new string[]
            {
                "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty",
                "Seventy", "Eighty", "Ninety"
            };
            if (num == 0)
                return "Zero";

            List<string> words = new List<string>();
            void PartToWord(int num)
            {
                if (num > 99)
                {
                    words.Add(map[num / 100]);
                    words.Add("Hundred");
                    num = num % 100;
                }
                if (num > 19)
                {
                    words.Add(map2[num / 10]);
                    if (num % 10 != 0)
                        words.Add(map[num % 10]);
                }
                else if (num > 0)
                    words.Add(map[num]);
            }

            int i = (int)Math.Floor(Math.Log10(num)+1);
            if (i > 9)
            {
                PartToWord(num / 1_000_000_000);
                words.Add("Billion");
                num %= 1_000_000_000;
            }
            if(i > 6 && num / 1_000_000 != 0)
            {
                PartToWord(num / 1_000_000);
                words.Add("Million");
                num %= 1_000_000;
            }
            if (i > 3 && num / 1_000 != 0)
            {
                PartToWord(num / 1_000);
                words.Add("Thousand");
                num %= 1_000;
            }
            PartToWord(num);

            return String.Join(' ', words);
        }
    }
}
