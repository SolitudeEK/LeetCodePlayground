using LeetCodePlayground;
using LeetCodePlayground.HardProblems;
public class Programm
{
    public static void Main()
    {
        var arr = new int[] { 20, 5, 11 };
        var brr = new int[] { 1, 2, 6, 26, 1, 0, 27, 3, 0, 30 };
        var crr = new string[] { "e", "o" };
        //var a = new PaintingGrid3Colors();
        var a = new Solution();
        var ans = a.MinRemoval(arr, 2);
        Console.WriteLine($"Answer: {ans}");
    }
}

