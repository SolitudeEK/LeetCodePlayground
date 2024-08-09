using LeetCodePlayground;
using LeetCodePlayground.HardProblems;
using System.Diagnostics;
public class Programm
{
    public static void Main()
    {
        Solution a = new Solution();
        Stopwatch timer = new Stopwatch();
        int[][] data =
{
            new int[] { 4, 3, 8, 4 },
            new int[] { 9, 5, 1, 9 },
            new int[] { 2, 7, 6, 2 }
        };


        timer.Start();
        var ans = a.NumMagicSquaresInside(data);
        timer.Stop();
        Console.WriteLine($"Answer: {ans}");
        Console.WriteLine($"Time taken: {timer.ElapsedMilliseconds} ms");
    }
}
