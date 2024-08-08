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
            new int[] {1, 1},
            new int[] {2, 3},
            new int[] {2, 3},
            new int[] {1, 1},
            new int[] {1, 1},
            new int[] {1, 1},
            new int[] {1, 2}
        };


        timer.Start();
        var ans = a.SpiralMatrixIII(5, 6, 1, 4);
        timer.Stop();
        Console.WriteLine($"Answer: {ans}");
        Console.WriteLine($"Time taken: {timer.ElapsedMilliseconds} ms");
    }
}
