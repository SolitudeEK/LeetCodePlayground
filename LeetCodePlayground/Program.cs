using LeetCodePlayground;
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
        //var ans = a.SurvivedRobotsHealths(new int[] { 3, 5, 2, 6 }, new int[] { 10, 10, 15, 12 }, "RLRL");
        timer.Stop();
        //Console.WriteLine($"Answer: {string.Join(", ", ans)}");
        Console.WriteLine($"Time taken: {timer.ElapsedMilliseconds} ms");
    }
}
