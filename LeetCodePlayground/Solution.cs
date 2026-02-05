using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
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
                var j = i + 1L;
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

        public long GridGame(int[][] grid)
        {
            int n = grid[0].Length;

            long[] topPrefixSum = new long[n + 1];
            long[] bottomPrefixSum = new long[n + 1];

            for (int i = 0; i < n; i++)
            {
                topPrefixSum[i + 1] = topPrefixSum[i] + grid[0][i];
                bottomPrefixSum[i + 1] = bottomPrefixSum[i] + grid[1][i];
            }

            long result = long.MaxValue;

            for (int col = 0; col < n; col++)
            {
                long topRemaining = topPrefixSum[n] - topPrefixSum[col + 1];

                long bottomCollected = bottomPrefixSum[col];

                long secondRobotPoints = Math.Max(topRemaining, bottomCollected);

                result = Math.Min(result, secondRobotPoints);
            }

            return result;
        }

        public int[][] HighestPeak(int[][] isWater)
        {
            var cells = new Queue<(int X, int Y)>();
            int m = isWater.Length;
            int n = isWater[0].Length;

            var dirs = new(int X, int Y)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

            for(int i=0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (isWater[i][j] == 1)
                    {
                        cells.Enqueue((i, j));
                        isWater[i][j] = 0;
                    }
                    else
                        isWater[i][j] = -1;
                }
            }

            while (cells.Count > 0)
            {
                var cell = cells.Dequeue();

                foreach (var dir in dirs)
                {
                    int x = cell.X + dir.X;
                    int y = cell.Y + dir.Y;

                    if (x >= 0 && x < m && y >= 0 && y < n && isWater[x][y] == -1)
                    {
                        isWater[x][y] = isWater[cell.X][cell.Y] + 1;
                        cells.Enqueue((x, y));
                    }
                }
            }

            return isWater;
        }

        public int[] LexicographicallySmallestArray(int[] nums, int limit)
        {
            int n = nums.Length;

            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) <= limit)
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }

            bool[] visited = new bool[n];
            void DFS(int node, List<int> indices)
            {
                visited[node] = true;
                indices.Add(node);

                foreach (int neighbor in graph[node])
                {
                    if (!visited[neighbor])
                    {
                        DFS(neighbor, indices);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    List<int> indices = new List<int>();
                    DFS(i, indices);

                    List<int> values = indices.Select(index => nums[index]).ToList();
                    indices.Sort();
                    values.Sort();
                    for (int k = 0; k < indices.Count; k++)
                    {
                        nums[indices[k]] = values[k];
                    }
                }
            }

            return nums;
        }

        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int n = arr.Length;
            int result = 0;

            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    if (Math.Abs((arr[i] - arr[j])) <= a)
                    {
                        for (int k = j + 1; k < n; k++)
                        {
                            if (Math.Abs((arr[j] - arr[k])) <= b && Math.Abs((arr[i] - arr[k])) <= c)
                                result++;
                        }
                    }
                }
            }
            return result;
        }

        public int CountGoodNumbers(long n)//fix
        {
            int evenMultiplayer = 5;
            int oddMultiplayer = 4;
            int mod = 1_000_000_007;

            if (n == 1)
                return 5;

            return (int)((long)Math.Pow(oddMultiplayer, n / 2) % mod * (long)Math.Pow(evenMultiplayer, (int)Math.Ceiling((double)n / 2)) % mod) % mod;
        }

        public int CountSymmetricIntegers(int low, int high)
        {
            int result = 0;

            for(int i = low; i <= high; i++)
            {
                if(i > 10 && i < 100)
                {
                    if(i / 10 == i % 10)
                        result++;
                }
                else if(i > 1000)
                {
                    if(i / 1000 + (i / 100) % 10 == i % 10 + (i % 100) / 10)
                        result++;
                }
            }

            return result;
        }

        public bool LemonadeChange(int[] bills)
        {
            int bills5 = 0, bills10 = 0;

            for (int i = 0; i < bills.Length; i++)
            {
                switch (bills[i])
                {
                    case 5:
                        bills5++; break;
                    case 10:
                        bills10++;
                        bills5--;
                        
                        break;
                    case 20:
                        if(bills10 > 0)
                        {
                            bills10--;
                            bills5--;
                        }
                        else
                            bills5 -= 3;
                        break;
                }
                if (bills5 < 0) return false;
            }
            return true;
        }

        public int MaxDistance(IList<IList<int>> arrays)
        {
            int max = arrays[0].Last();
            int min = arrays[0][0];
            int result = 0;

            for(int i =1; i < arrays.Count; i++)
            {
                int curMax = arrays[i].Last();
                int curMin = arrays[i][0];

                result = Math.Max(result, Math.Max(Math.Abs(max - curMin), Math.Abs(curMax - min)));

                min = int.Min(min, curMin);
                max = int.Max(max, curMax);
            }
            return result;
        }

        public long MaxPoints(int[][] points)
        {
            int m = points.Length;
            int n = points[0].Length;

            long[] prev = new long[n];

            for (int j = 0; j < n; j++)
            {
                prev[j] = points[0][j];
            }

            for (int i = 1; i < m; i++)
            {
                long[] leftMax = new long[n];
                long[] rightMax = new long[n];
                long[] curr = new long[n];

                leftMax[0] = prev[0];
                for (int j = 1; j < n; j++)
                    leftMax[j] = Math.Max(leftMax[j - 1] - 1, prev[j]);

                rightMax[n - 1] = prev[n - 1];
                for (int j = n - 2; j >= 0; j--)
                    rightMax[j] = Math.Max(rightMax[j + 1] - 1, prev[j]);

                for (int j = 0; j < n; j++)
                    curr[j] = points[i][j] + Math.Max(leftMax[j], rightMax[j]);

                prev = curr;
            }

            long max = 0;
            foreach (var val in prev)
                max = Math.Max(max, val);

            return max;
        }

        public int MinSteps(int n)
        {
            int res = 0;
            for (int i = 2; i <= n; i++)
            {
                while (n % i == 0)
                {
                    res += i;
                    n /= i;
                }
            }
            return res;
        }

        public long CountGood(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            long result = 0;
            int n = nums.Length;
            int i = 0, j = 1;

            Add(nums[i]);

            long counter = 0;
            while(i < n -1)
            {
                while (counter < k&&j < n)
                {
                    int temp = nums[j];
                    Add(temp);
                    counter -= (map[temp] - 1) * (map[temp] - 2) / 2;
                    counter += map[temp] * (map[temp] - 1) / 2;
                    j++;
                }

                if (counter >= k)
                    result += n - j + 1;

                counter -= map[nums[i]] * (map[nums[i]] - 1) / 2;
                map[nums[i]]--;
                counter += map[nums[i]] * (map[nums[i]] - 1) / 2;
                i++;
            }

            void Add(int x)
            {
                if (map.ContainsKey(x))
                    map[x]++;
                else
                    map.Add(x, 1);
            }

            return result;
        }

        public IList<string> StringMatching(string[] words)
        {
            var result = new List<string>();
            int n = words.Length;

            for(int i =0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i != j && words[j].Contains(words[i]))
                    {
                        result.Add(words[i]);
                        break;
                    }
                }
            }
            return result;
        }

        public int PrefixCount(string[] words, string pref)
            => words.Count(x => x.StartsWith(pref));

        public IList<string> WordSubsets(string[] words1, string[] words2)
        {
            var result = new List<string>();
            var freq = new int[26];

            foreach(string word in words2)
            {
                var temp = new int[26];
                foreach (char c in word)
                    temp[c - 'a']++;

                for(int i = 0; i < 26; i++)
                    freq[i]= Math.Max(freq[i], temp[i]);
            }

            foreach(string word in words1)
            {
                var curFreq = new int[26];

                foreach(char c in word)
                    curFreq[c-'a']++;

                bool isUniversal = true;

                for(int i = 0;i < 26; i++)
                {
                    if (freq[i] > curFreq[i])
                    {
                        isUniversal = false;
                        break;
                    }
                }

                if(isUniversal)
                    result.Add(word);
            }

            return result;
        }

        public int NumberOfArrays(int[] differences, int lower, int upper)
        {
            int n  = differences.Length;
            int max = int.MinValue;
            int min = int.MaxValue;
            int cur = 0;

            for(int i = 0; i < n; i++)
            {
                cur += differences[i];
                
                max = Math.Max(max, cur);
                min = Math.Min(min, cur);
            }

            return Math.Max(upper - lower - (max - min) + 1, 0);
        }

        public int CountLargestGroup(int n)
        {
            var map = new Dictionary<int, int>();

            for (int i = 1; i <= n; i++)
            {
                int k = 0, temp = i;

                while (temp > 0)
                {
                    k += temp % 10;
                    temp /= 10;
                }

                if(map.ContainsKey(k))
                    map[k]++;
                else
                    map.Add(k, 1);
            }

            int max = 0, count = 0;

            foreach (int i in map.Values)
            {
                if (max < i)
                {
                    max = i;
                    count = 1;
                }
                else if (max == i)
                    count++;
            }


            return count;
        }

        public int CountCompleteSubarrays(int[] nums)
        {
            int totalUnique = new HashSet<int>(nums).Count;
            int result = 0;
            int left = 0;
            var freq = new Dictionary<int, int>();

            for (int right = 0; right < nums.Length; right++)
            {
                if (!freq.ContainsKey(nums[right]))
                    freq[nums[right]] = 1;
                else
                    freq[nums[right]]++;

                while (freq.Count == totalUnique)
                {
                    result += nums.Length - right;

                    freq[nums[left]]--;
                    if (freq[nums[left]] == 0)
                        freq.Remove(nums[left]);
                    left++;
                }
            }

            return result;
        }

        public int MinTimeToReach(int[][] moveTime)
        {
            int n = moveTime.Length;
            int m = moveTime[0].Length;
            var visited = new bool[n, m];
            var pq = new PriorityQueue<(int x, int y, bool parity), int>();
            var dir = new (int x, int y)[] { (0, -1), (0, 1), (1, 0), (-1, 0) };

            pq.Enqueue((0, 0, true), 0);

            while(pq.Count > 0)
            {
                pq.TryDequeue(out var cell, out int time);
                if (visited[cell.x, cell.y])
                    continue;
                visited[cell.x, cell.y] = true;

                if (cell.x == n - 1 && cell.y == m - 1)
                    return time;

                var addCost = cell.parity ? 1 : 2;

                for (int i = 0; i < 4; i++)
                {
                    (int x, int y) newCell = (cell.x + dir[i].x, cell.y + dir[i].y);

                    if (newCell.x < 0 || newCell.y < 0 || newCell.x >= n || newCell.y >= m)
                        continue;
                    var newTime = Math.Max(time, moveTime[newCell.x][newCell.y]) + addCost;
                    pq.Enqueue((newCell.x, newCell.y, !cell.parity), newTime);
                }
            }

            return -1;
        }

        public bool CanPartition(int[] nums)
        {
            var count = nums.Sum(x => x);

            if( count % 2 == 1) 
                return false;

            var target = count / 2;
            var dp = new bool[target + 1];
            dp[0] = true;

            foreach(var num in nums)
            {
                for(int i = target; i >= 0; i--)
                {
                    dp[i] |= dp[i - num];
                }
            }

            return dp[^1];
        }

        public int CombinationSum4(int[] nums, int target)
        {
            var dp = new int[target + 1];
            dp[0] = 1;

            for(int i =1; i <= target; i++)
            {
                foreach(var num in nums)
                {
                    if (i - num >= 0)
                    {
                        dp[i] += dp[i - num];
                    }
                }
            }

            return dp[^1];
        }

        public int CountBalancedPermutations(string num) // Move to hard question and try to cpmplete
        {
            var nums = new int[num.Length]; 
            
            for(int i = 0; i<nums.Length; i++)
                nums[i] = num[i] - '0';

            var target = nums.Sum(x => x);

            if (target % 2 == 1)
                return 0;

            target /= 2;
            var dp = new int[target + 1];
            dp[0] = 1;
            

            foreach(var digit  in nums)
            {
                for(int i = target; i >= digit; i--)
                {
                    dp[i] =(dp[i] + dp[i - digit]) % 1_000_000_007;
                }
            }
            //dp.Print();
            return dp[^1];
        }

        public long MinSum(int[] nums1, int[] nums2)
        {
            int numZero1 = nums1.Count(x => x == 0);
            int numZero2 = nums2.Count(x => x == 0);

            long count1 = nums1.Aggregate(0L, (current, n) => current + n);
            long count2 = nums2.Aggregate(0L, (current, n) => current + n);

            if (count1 + numZero1 > count2 && numZero2 == 0)
                return -1;
            if (count2 + numZero2 > count1 && numZero1 == 0)
                return -1;
            if (numZero1 == 0 && numZero2 == 0 && count1 != count2)
                return -1;

            return Math.Max(count1 + numZero1, count2 + numZero2);
        }

        public bool ThreeConsecutiveOdds(int[] arr)
        {
            var count = 3;

            foreach(var digit  in arr)
            {
                if (digit % 2 == 1)
                    count--;
                else
                    count = 3;

                if (count == 0)
                    return true;
            }

            return false;
        }

        public int[] FindEvenNumbers(int[] digits)
        {
            var result = new List<int>();
            var set = new int[10];

            foreach(var digit in digits)
            {
                set[digit]++;
            }

            for(int i= 100; i < 999; i += 2)
            {
                int fDig = i / 100;
                int sDig = i % 100 / 10;
                int tDig = i % 10;
                set[fDig]--;
                set[sDig]--;
                set[tDig]--;

                if (set[fDig] >= 0 && set[sDig] >= 0 && set[tDig] >= 0)
                    result.Add(i);

                set[fDig]++;
                set[sDig]++;
                set[tDig]++;
            }

            return result.ToArray();
        }

        public int[] FindMissingAndRepeatedValues(int[][] grid)
        {
            var n = grid.Length;
            var nums = new int[n * n + 1];
            var result = new int[2];

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    nums[grid[i][j]]++;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == 2)
                    result[0] = i;
                if (nums[i] == 0)
                    result[1] = i;
            }

            return result;
        }

        public int[] ClosestPrimes(int left, int right)
        {
            List<int> primes = new List<int>();

            for (int i = left; i <= right; i++)
            {
                if (IsPrime(i))
                    primes.Add(i);
            }

            if (primes.Count < 2)
                return new int[] { -1, -1 };

            int minDiff = int.MaxValue;
            int[] result = new int[2];

            for (int i = 1; i < primes.Count; i++)
            {
                int diff = primes[i] - primes[i - 1];
                if (diff < minDiff)
                {
                    minDiff = diff;
                    result[0] = primes[i - 1];
                    result[1] = primes[i];
                }
            }

            bool IsPrime(int number)
            {
                if (number <= 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;

                int limit = (int)Math.Sqrt(number);
                for (int i = 3; i <= limit; i += 2)
                {
                    if (number % i == 0)
                        return false;
                }

                return true;
            }

            return result;
        }

        public int MinimumRecolors(string blocks, int k)
        {
            var count = 0;
            for (int i = 0; i < k; i++)
            {
                if (blocks[i] == 'W')
                    count++;
            }

            int min = count;

            for (int i = 0; i < blocks.Length - k; i++)
            {
                if (blocks[i] == 'W')
                    count--;
                if (blocks[i + k] == 'W')
                    count++;

                if (min > count)
                    min = count;
            }

            return min;
        }

        public int NumberOfAlternatingGroups(int[] colors, int k)
        {
            int n = colors.Length;
            var arr = colors.Concat(colors[0..(k - 1)]).ToArray();

            int res = 0;
            int cur = 1;

            for (int i = 0; i < n + k - 2; i++)
            {
                if (arr[i] != arr[i + 1])
                    cur++;
                else
                {
                    res += cur >= k ? cur - k + 1 : 0;
                    cur = 1;
                }
            }

            res += cur >= k ? cur - k + 1 : 0;
            return res;
        }

        public int MaximumCount(int[] nums)
            => Math.Max(nums.Count(x => x > 0), nums.Count(x => x < 0));

        public int MinZeroArray(int[] nums, int[][] queries)
        {
            int n = nums.Length;
            var line = new int[n+1];
            int k = 0;
            int overallDecrement = 0;

            for(int i=0; i < n; i++)
            {
                while (nums[i] > overallDecrement + line[i] )
                {
                    if (k == queries.Length)
                        return -1;

                    int li = queries[k][0];
                    int ri = queries[k][1];
                    int val = queries[k][2];

                    k++;

                    if (ri < i)
                        continue;

                    line[Math.Max(li, i)] += val;

                    line[ri + 1] -= val;
                }

                overallDecrement += line[i];
            }

            return k;
        }

        public bool IsZeroArray(int[] nums, int[][] queries)
        {
            int n = nums.Length;
            var line = new int[n+1];
            int k = 0;
            int overall = 0;

            for(int i=0; i < n; i++)
            {
                while(overall + line[i] < nums[i])
                {
                    if(k == queries.Length)
                        return false;

                    int li = queries[k][0];
                    int ri = queries[k][1];

                    k++;

                    if(ri < i)
                        continue;

                    line[Math.Max(li, i)]++;
                    line[ri + 1]--;
                }

                overall += line[i];
            }

            return true;
        }

        public int MaximumCandies(int[] candies, long k)
        {
            var right = candies.Aggregate(0L, (current, n) => current + n) / k;
            long left = 1;
            bool check=false;
            var result = 0;

            while(right >= left)
            {
                long mid = left +(right - left) / 2;
                check = k <= candies.Sum(x => x / mid);
                if (check)
                {
                    result = (int)mid;
                    left = mid + 1;
                }
                else
                    right = mid - 1;
            }
            
            return result;
        }

        public int LengthAfterTransformations(string s, int t)
        {
            int MOD = 1_000_000_007;
            var freq = new int[26];
            int res = 0;

            foreach(char letter in s)
                freq[letter - 'a']++;

            freq.Print();

            for (int i=25; i>=2; i--)
            {
                if (freq[i] == 0)
                    continue;
                if (26 - i > t)
                {
                    res = (res + freq[i]) % MOD;
                    freq[i] = 0;
                }
                else
                {
                    var temp = i + t;
                    Console.WriteLine($"Temp:{temp}");
                    freq[1] += (temp / 26) * freq[i];
                    if (temp % 26 != 0)
                    {
                        freq[0] += ((temp / 26) - 1) * freq[i];
                        res = (res + freq[i]) % MOD;
                    }
                    else
                        freq[0] += (temp / 26) * freq[i];
                }
            }
            freq.Print();
            if(t < 25)
            {
                res = (res + freq[1]) % MOD;
            }

            return res;
        }

        public int[] SortArrayBySunDigits(int[] numbers)
        {
            int SumDigit(int num)
            {
                int sum = 0;
                while(num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                return sum;
            }

            return numbers.OrderBy(x => SumDigit(Math.Abs(x))).ToArray();
        }

        public string MaxStingA(string A, string B)
        {
            var digitsB = B.ToList();
            var digitsA = A.ToCharArray();

            digitsB.Sort((x, y) => y.CompareTo(x));

            int indexB = 0;

            for(int i=0; i < digitsA.Length && indexB < digitsB.Count; i++)
            {
                if(digitsB[indexB] > digitsA[i])
                {
                    digitsA[i] = digitsB[indexB];
                    indexB++;
                }
            }

            return new string(digitsA);
        }

        public int[] ConstructTransformedArray(int[] nums)
        {
            int n = nums.Count();
            int[] result = new int[n];

            for (int i =0; i < n; i++)
            {
                int cur = i + nums[i];
                while(cur < 0)
                    cur += n;
                while(cur >= n)
                    cur -= n;

                result[i] = nums[cur];
            }

            return result;
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

        public static void Print<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> map)
        {
            Console.Write("Map: \n");
            foreach (var item in map)
            {
                Console.Write($"{item.Key}, {item.Value}\n");
            }
            Console.WriteLine();
        }
    }

}
