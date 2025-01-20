using LeetCodePlayground;
using LeetCodePlayground.HardProblems;
public class Programm
{
    public static void Main()
    {
        //Solution a = new Solution();
        //var ans = a.MinimizeXor(25, 72);
        int[][] m = {
    new int[] {3, 3, 3, 3, 3},
    new int[] {3, 2, 2, 2, 3},
    new int[] {3, 2, 1, 2, 3},
    new int[] {3, 2, 2, 2, 3},
    new int[] {3, 3, 3, 3, 3}
};
        var a = new TrappingWaterII();
        var ans = a.TrapRainWater(m);
        Console.WriteLine($"Answer: {ans}");
    }
}

