using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

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
            return counter + 1;
        }

        public int[] SortJumbled(int[] mapping, int[] nums)
        {
            int temp;
            int j;
            int[] res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
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
            for (int i = 0; i < nums.Length; i++)
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
            for (int i = 1; i < rating.Length - 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    for (int k = i + 1; k < rating.Length; k++)
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
            for (int i = counter; i < n + counter; i++)
            {
                curSum += nums[i % n];
                curSum -= nums[i - counter];
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
            for (int i = 0; i < n - 1; i++)
            {
                string candidate = arr[i];
                for (int j = i + 1; j < n; j++)
                {
                    if (candidate == arr[j])
                    {
                        arr[j] = "";
                        arr[i] = "";
                    }
                }
                if (arr[i] != "") unique.Add(arr[i]);
            }
            if (arr[n - 1] != "") unique.Add(arr[n - 1]);
            if (unique.Count < k) return "";
            return unique[k - 1];
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

            int counter = 0;
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
            int[][] matrix = new int[cols * rows][];
            int[][] dirs = new int[][] {
                new int[] {0, 1},
                new int[] {1, 0},
                new int[] {0, -1},
                new int[] {-1, 0}
            };

            matrix[0] = new int[] { rStart, cStart };
            while (count < cols * rows)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < step; j++)
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
            for (int i = 0; i < grid.Length - 2; i++)
            {
                for (int j = 0; j < grid[0].Length - 2; j++)
                {
                    if (IsMagicSquare(i, j))
                        count++;
                }
            }

            bool IsMagicSquare(int row, int col)
            {

                for (int k = 0; k < 8; k++)
                {
                    bool isSame = true;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (grid[row + i][col + j] != magicSquares[k][i][j])
                            {
                                isSame = false; break;
                            }
                        }
                        if (!isSame) break;
                    }
                    if (isSame) return true;
                }
                return false;
            }

            return count;
        }

        public bool CanChange(string start, string target)
        {
            int n = start.Length;

            int i = 0, j = 0;

            while (i < n || j < n)
            {
                while (i < n && start[i] == '_') i++;
                while (j < n && target[j] == '_') j++;

                if (i == n && j == n) return true;

                if (i == n || j == n) return false;

                if (start[i] != target[j]) return false;

                if (start[i] == 'L' && i < j) return false;
                if (start[i] == 'R' && i > j) return false;
                i++;
                j++;
            }

            return true;
        }

        public int MaxCount(int[] banned, int n, int maxSum)
        {
            int counter = 0;
            HashSet<int> bans = new HashSet<int>(banned);

            int i = 1;
            while (i <= n && maxSum >= i)
            {
                if (i >= maxSum && !bans.Contains(i))
                {
                    counter++;
                    maxSum -= i;
                }
                i++;
            }

            return counter;
        }

        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            int n = nums.Length;
            int m = queries.Length;

            bool[] otp = new bool[m];
            int[] violations = new int[n];

            int counter = 0;
            for (int i = 1; i < n; i++)
            {
                if ((nums[i - 1] + nums[i]) % 2 == 0)
                    counter++;
                violations[i] = counter;
            }

            for (int i = 0; i < m; i++)
                otp[i] = violations[queries[i][0]] - violations[queries[i][1]] == 0;


            return otp;
        }

        public int MaximumLength(string s)
        {
            int n = s.Length;

            int window = n - 2;

            while (window > 0)
            {
                for (int i = 0; i < n - window; i++)
                {
                    var tocheck = s.Substring(i, window);

                    if (!tocheck.Equals(new string(tocheck[0], tocheck.Length)))
                        continue;

                    if (s.Select((c, i) => s.Substring(i).StartsWith(tocheck) ? 1 : 0).Sum() > 2)
                        return window;
                }

                window--;
            }

            return -1;
        }

        public long PickGifts(int[] gifts, int k)
        {
            int n = gifts.Length;
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            foreach (int gift in gifts)
                pq.Enqueue(gift, -gift);



            for (int i = 0; i < k; i++)
            {
                var gift = (int)Math.Floor(Math.Sqrt(pq.Dequeue()));
                pq.Enqueue(gift, -gift);
            }

            long counter = 0;
            while (pq.Count > 0)
                counter += pq.Dequeue();

            return counter;
        }

        public long FindScoreFT(int[] nums)
        {
            int n = nums.Length;
            int score = 0;
            int i = 0;
            while (i < n)
            {
                if (i == n - 1 || nums[i] < nums[i + 1])
                {
                    score += nums[i];
                    i += 2;
                }
                else
                {
                    if (i + 2 < n && nums[i + 1] > nums[i + 2])
                    {
                        score += nums[i] + nums[i + 2];
                        i += 4;
                    }
                    else
                    {
                        score += nums[i + 1];
                        i += 3;
                    }
                }
                Console.WriteLine($"Score {score}");
            }
            return score;
        }

        public long FindScore(int[] nums)
        {
            int n = nums.Length;
            var pq = new List<(int value, int index)>();

            for (int i = 0; i < n; i++)
                pq.Add((nums[i], i));

            pq.Sort(Comparer<(int value, int index)>.Create(
                (x, y) => x.value == y.value ? x.index.CompareTo(y.index) : x.value.CompareTo(y.value)));

            long score = 0;

            foreach (var (value, index) in pq)
            {
                if ((index > 0 && nums[index - 1] == 0) || (index < n - 1 && nums[index + 1] == 0))
                    continue;

                score += nums[index];

                nums[index] = 0;
            }

            return score;
        }

        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            int n = classes.Length;
            PriorityQueue<(int p, int t), double> pq = new PriorityQueue<(int, int), double>();

            for (int i = 0; i < n; i++)
                pq.Enqueue((classes[i][0], classes[i][1]), Gain(classes[i][0], classes[i][1]));

            while (extraStudents > 0)
            {
                var (pass, total) = pq.Dequeue();
                pass++;
                total++;
                extraStudents--;

                pq.Enqueue((pass, total), Gain(pass, total));
            }

            double result = 0;

            while (pq.Count > 0)
            {
                var (pass, total) = pq.Dequeue();
                result += (double)pass / total;
            }

            double Gain(double p, double t)
                => p / t - (p + 1) / (t + 1);

            return result / n;
        }

        public int[] GetFinalState(int[] nums, int k, int multiplier)
        {
            var pq = new PriorityQueue<int, int>();

            for (int i = 0; i < nums.Length; i++)
                pq.Enqueue(i, nums[i] * 100 + i);

            while (k > 0)
            {
                var index = pq.Dequeue();
                nums[index] *= multiplier;
                pq.Enqueue(index, nums[index] * 100 + index);
                k--;
            }

            return nums;
        }

        public string RepeatLimitedString(string s, int repeatLimit)
        {
            var letters = new int[26];

            foreach (char c in s)
                letters[c - 'a']++;

            var sb = new StringBuilder();

            for (int i = 25; i >= 0; i--)
            {
                var counter = 0;
                while (letters[i] > 0)
                {
                    counter++;

                    if (counter > repeatLimit)
                    {
                        if (i == 0)
                            return sb.ToString();

                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (letters[k] > 0)
                            {
                                sb.Append((char)(k + 'a'));
                                letters[k]--;
                                counter = 1;
                                break;
                            }
                            else if (k == 0)
                                return sb.ToString();
                        }
                    }

                    sb.Append((char)(i + 'a'));
                    letters[i]--;
                }
            }
            return sb.ToString();
        }

        public int[] FinalPrices(int[] prices)
        {
            int n = prices.Length;

            for (int i = 0; i < n - 1; i++)
            {
                var j = i + 1l;
                while (j < n && prices[i] < prices[j])
                    j++;

                prices[i] -= j == n ? 0 : prices[j];
            }

            return prices;
        }

        public int MaxChunksToSorted(int[] arr)
        {
            int n = arr.Length;

            int max = 0;
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, arr[i]);

                if (max == i)
                    counter++;
            }

            return counter;
        }

        public int MinimumLength(string s)
        {
            int n = s.Length;
            var set = new Dictionary<char, int>();

            foreach (char letter in s)
            {
                if (set.ContainsKey(letter))
                {
                    set[letter]++;
                    if (set[letter] > 2)
                    {
                        n -= 2;
                        set[letter] = 1;
                    }
                }
                else
                    set.Add(letter, 1);
            }

            return n;
        }

        public int[] FindThePrefixCommonArray(int[] A, int[] B)
        {
            int n = A.Length;
            int count = 0;

            var freq = new int[n];
            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                int ai = A[i] - 1;
                int bi = B[i] - 1;

                freq[ai]++;
                freq[bi]++;

                if (bi == ai)
                {
                    if (freq[ai] == 2)
                        count++;
                }
                else
                {
                    if (freq[ai] == 2)
                        count++;
                    if (freq[bi] == 2)
                        count++;
                }

                result[i] = count;
            }

            return result;
        }

        public int MinimizeXor(int num1, int num2)
        {
            int target = BitOperations.PopCount((uint)num2);
            int placedBits = 0;
            int result = 0;

            for (int i = 31; i >= 0 && placedBits < target; i--)
            {
                if ((num1 & (1 << i)) != 0)
                {
                    result |= (1 << i);
                    placedBits++;
                }
            }

            for (int i = 0; i < 32 && placedBits < target; i++)
            {
                if ((result & (1 << i)) == 0)
                {
                    result |= (1 << i);
                    placedBits++;
                }
            }

            return result;
        }

        public int XorAllNums(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int result = 0;

            if (m % 2 == 1)
            {
                foreach (int num in nums1)
                    result ^= num;
            }

            if (n % 2 == 1)
            {
                foreach (int num in nums2)
                    result ^= num;
            }

            return result;
        }

        public bool DoesValidArrayExist(int[] derived)
            => derived.Sum() % 2 == 0;

        public int FirstCompleteIndex(int[] arr, int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            var indexes = new (int V, int H)[m * n+1];
            var vFreq = new int[m];
            var hFreq = new int[n];


            for (int i = 0; i < m; i++){
                for(int j=0; j < n; j++)
                    indexes[mat[i][j]] = (i, j);
            }

            for(int i =0; i < m*n; i++)
            {
                var a = indexes[arr[i]];

                if (++vFreq[a.V] == n)
                    return i;
                if (++hFreq[a.H] == m)
                    return i;
            }
            return -1;
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
