using LeetCodePlayground;
using LeetCodePlayground.HardProblems;
public class Programm
{
    public static void Main()
    {
        Solution a = new Solution();
        //var ans = a.MinimizeXor(25, 72);
        int[][] m = {
    new int[] {0, 1},
    new int[] {0,0}
};
        var ans = a.HighestPeak(m);
        Console.WriteLine($"Answer: {ans}");
    }
}

