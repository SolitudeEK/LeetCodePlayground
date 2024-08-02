namespace LeetCodePlayground
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            int counter = 0;
            var temp = nums[0];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (temp != nums[i + 1])
                {
                    nums[counter] = temp;
                    counter++;
                    temp = nums[i + 1];
                    nums[counter] = temp;
                }
            }
            return counter+1;
        }

        public int[] SortJumbled(int[] mapping, int[] nums)
        {
            int temp;
            int j;
            int[] res = new int[nums.Length];
            for(int i =0; i < nums.Length; i++)
            {
                temp = 0;
                j = 1;
                res[i] = nums[i];
                while (res[i] > 0)
                {
                    temp += mapping[nums[i] % 10] * j;
                    res[i] = res[i] / 10;
                    j = j * 10;
                }
                res[i] = temp;
            }
            for(int i = 0; i < nums.Length; i++)
            {
                for (j = 1; j < nums.Length; j++)
                {

                }
            }
                return nums;
        }

        public int NumTeams(int[] rating)
        {
            int counter = 0;
            for(int i=1; i< rating.Length-1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    for(int k=i+1; k < rating.Length; k++)
                    {
                        if (rating[j] < rating[i] && rating[i] < rating[k])
                            counter++;
                        if (rating[j] > rating[i] && rating[i] > rating[k])
                            counter++;
                    }
                }
            }
            return counter;
        }

        public int MinimumDeletions(string s)
        {
            int otp = 0;
            int countB = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == 'b')
                    countB++;
                else
                    otp = Math.Min(otp + 1, countB);
            }
            return otp;
        }

        public int MinHeightShelves(int[][] books, int shelfWidth)
        {
            int n = books.Length;
            int[] dp = new int[n + 1];
            Array.Fill(dp, int.MaxValue);
            dp[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                int width = 0;
                int maxHeight = 0;
                for (int j = i; j > 0; j--)
                {
                    width += books[j - 1][0];
                    if (width > shelfWidth) break;
                    maxHeight = Math.Max(maxHeight, books[j - 1][1]);
                    dp[i] = Math.Min(dp[i], dp[j - 1] + maxHeight);
                }
            }

            return dp[n];
        }

        public int CountSeniors(string[] details)
        {
            return details.Count(x => x[^4] > '6' || (x[^4] == '6' && x[^3] > '0'));
        }

        public int MinSwaps(int[] nums)
        {
            int n = nums.Length;
            int counter = nums.Sum();
            int max = nums.Take(counter).Sum();
            int curSum = max;
            for (int i = counter; i < n + counter; i++ )
            {
                curSum += nums[i % n];
                curSum -= nums[i-counter];
                if (curSum > max)
                {
                    max = curSum;
                }
            }
            return counter - max;
        }
    }
    static class SolutionExtenssion
    {
        public static void Print<T>(this T[] array)
        {
            Console.Write("Array:");
            foreach (var item in array)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }

        public static void Print<T>(this T[][] matrix)
        {
            Console.WriteLine("Matrix:");
            foreach (var line in matrix)
            {
                foreach (var item in line)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Print<T>(this Stack<T> stack)
        {
            Stack<T> tempStack = new Stack<T>(stack);
            Console.Write("Stack:");
            foreach (var item in tempStack)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }
    }

}
