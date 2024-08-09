using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;

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
            => details.Count(x => x[^4] > '6' || (x[^4] == '6' && x[^3] > '0'));

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

        public bool CanBeEqual(int[] target, int[] arr)
        {
            int[] map = new int[1001];

            foreach (int i in arr)
                map[i]++;

            foreach (int i in target)
            {
                if (map[i] > 0) map[i]--;
                else return false;
            }

            return true;
        }

        public int RangeSum(int[] nums, int n, int left, int right)
        {
            int MOD = 1000000007;
            List<int> sums = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int currentSum = 0;
                for (int j = i; j < n; j++)
                {
                    currentSum += nums[j];
                    sums.Add(currentSum);
                }
            }

            sums.Sort();

            long result = 0;
            for (int i = left - 1; i < right; i++)
                result = (result + sums[i]) % MOD;

            return (int)result;
        }

        public string KthDistinct(string[] arr, int k)
        {
            int n = arr.Length;
            List<string> unique = new List<string>();
            for(int  i =0; i < n-1; i++)
            {
                string candidate = arr[i];
                for (int j = i+1; j < n; j++)
                {
                    if (candidate == arr[j])
                    {
                        arr[j] = "";
                        arr[i] = "";
                    }
                }
                if (arr[i]!="") unique.Add(arr[i]);
            }
            if (arr[n-1] != "") unique.Add(arr[n-1]);
            if (unique.Count < k) return "";
            return unique[k-1];
        }

        public int MinimumPushes(string word)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();
            foreach (char letter in word)
            {
                if (!letters.TryAdd(letter, 1))
                    letters[letter]++;
            }

            var sortedLetters = letters.OrderByDescending(x => x.Value).Select(x => x.Value);

            int counter=0;
            int multiplier = 8;
            foreach (var letter in sortedLetters)
            {
                counter += letter * (multiplier++ / 8);
            }
            return counter;
        }

        public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
        {
            int count = 1, curDir = 0, step = 1;
            int[][] matrix = new int[cols*rows][];
            int[][] dirs = new int[][] {
                new int[] {0, 1},
                new int[] {1, 0},
                new int[] {0, -1},
                new int[] {-1, 0}
            };

            matrix[0] = new int[] { rStart, cStart };
            while(count < cols * rows)
            {
                for(int i=0; i < 2; i++)
                {
                    for (int j=0; j < step; j++)
                    {
                        rStart += dirs[curDir][0];
                        cStart += dirs[curDir][1];
                        if (rStart < rows && cStart < cols && cStart >= 0 && rStart >= 0)
                            matrix[count++] = new int[] { rStart, cStart };
                    }
                    curDir = ++curDir % 4;
                }
                step++;
            }
            return matrix;
        }

        public int NumMagicSquaresInside(int[][] grid)
        {
            int count = 0;
            int[][][] magicSquares =                //All possible magic square
            {
                new int[][] { new int[] {2, 7, 6}, new int[] {9, 5, 1}, new int[] {4, 3, 8} },
                new int[][] { new int[] {6, 1, 8}, new int[] {7, 5, 3}, new int[] {2, 9, 4} },
                new int[][] { new int[] {8, 1, 6}, new int[] {3, 5, 7}, new int[] {4, 9, 2} },
                new int[][] { new int[] {4, 9, 2}, new int[] {3, 5, 7}, new int[] {8, 1, 6} },
                new int[][] { new int[] {8, 3, 4}, new int[] {1, 5, 9}, new int[] {6, 7, 2} },
                new int[][] { new int[] {4, 3, 8}, new int[] {9, 5, 1}, new int[] {2, 7, 6} },
                new int[][] { new int[] {6, 7, 2}, new int[] {1, 5, 9}, new int[] {8, 3, 4} },
                new int[][] { new int[] {2, 9, 4}, new int[] {7, 5, 3}, new int[] {6, 1, 8} }
            };
            for (int i = 0; i < grid.Length-2; i++)
            {
                for (int j = 0; j < grid[0].Length-2; j++)
                {
                    if (IsMagicSquare(i, j))
                        count++;
                }
            }

            bool IsMagicSquare(int row, int col)
            {

                for(int k=0; k< 8; k++)
                {
                    bool isSame = true;
                    for (int i=0; i <3; i++)
                    {
                        for(int j=0; j<3; j++)
                        {
                            if (grid[row + i][col+j] != magicSquares[k][i][j])
                            {
                                isSame = false; break;
                            }
                        }
                        if (!isSame) break;
                    }
                    if(isSame) return true;
                }
                return false;
            }

            return count;
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

        public static void Print<T>(this List<T> list)
        {
            Console.Write("List:");
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }
    }

}
