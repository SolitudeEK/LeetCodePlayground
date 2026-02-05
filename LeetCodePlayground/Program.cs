using LeetCodePlayground;
using LeetCodePlayground.HardProblems;
public class Programm
{
    public static void Main()
    {
        var arr = new int[] { 56,56, 56, 23, 89, 12, 101, 34, 65 };
        var brr = new int[] { 1, 2, 6, 26, 1, 0, 27, 3, 0, 30 };
        var crr = new string[] { "e", "o" };
        //var a = new PaintingGrid3Colors();
        var a = new Solution();
        var ans = a.MaxStingA("1234", "97");
        Console.WriteLine($"Answer: {ans}");
    }
}

