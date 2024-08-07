using LeetCodePlayground;
using LeetCodePlayground.HardProblems;
using System.Diagnostics;
public class Programm
{
    public static void Main()
    {
        Solution a = new Solution();
        IntToEnglish b = new IntToEnglish();
        Stopwatch timer = new Stopwatch();
        int[][] data =
{
            new int[] {1, 1},
            new int[] {2, 3},
            new int[] {2, 3},
            new int[] {1, 1},
            new int[] {1, 1},
            new int[] {1, 1},
            new int[] {1, 2}
        };


        timer.Start();
        //var ans = a.MinimumPushes("aabbccddeeffgghhiiiiii");
        var ans = b.NumberToWords(1234567);
        timer.Stop();
        Console.WriteLine($"Answer: {ans}");
        Console.WriteLine($"Time taken: {timer.ElapsedMilliseconds} ms");
    }
}
