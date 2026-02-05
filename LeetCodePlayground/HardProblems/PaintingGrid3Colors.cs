using System.Diagnostics.Metrics;

namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 1931. Painting a Grid With Three Different Colors
    /// </summary>
    internal class PaintingGrid3Colors
    {
        int MOD = 1_000_000_007;
        public int ColorTheGrid(int m, int n)
        {
            var mask = Generate(m);

            var adjacent = GetAdjacent(mask);

            var dp = DP(n, mask.Count, adjacent);

            return dp.Aggregate(0, (cur, x) => cur = (cur+x.Value) % MOD);
        }

        private List<int[]> Generate(int m)
        {
            var totalCombination = Math.Pow(3, m);
            var result = new List<int[]>();

            for (int i = 0; i < totalCombination; i++)
            {
                var temp = i;
                var candidate = new int[m];
                var check = true;

                for(int j =0; j < m; j++)
                {
                    candidate[j] = temp % 3;
                    temp /= 3;

                    if (j > 0 && candidate[j-1] == candidate[j])
                    {
                        check = false;
                        break;
                    }
                }

                if(check)
                    result.Add(candidate);
            }

            return result;
        }

        private Dictionary<int, List<int>> GetAdjacent(List<int[]> mask)
        {
            var n = mask.Count;
            var m = mask[0].Length;
            var mask1 = mask;
            var mask2 = mask;
            var result = new Dictionary<int, List<int>>();

            for(int i = 0;i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    bool check = true;

                    for (int k = 0; k < m; k++)
                    {
                        if(mask1[i][k] == mask2[j][k])
                            { check = false; break; }
                    }

                    if (check)
                    {
                        if(!result.ContainsKey(i))
                            result.Add(i, new List<int>());
                        result[i].Add(j);
                    }
                }
            }

            return result;
        }

        private Dictionary<int, int> DP(int n, int maskLen, Dictionary<int, List<int>> adjacent)
        {
            var result = new Dictionary<int, int>();

            for (int i = 0; i < maskLen; i++)
                result.Add(i, 1);

            for(int i=1; i<n; i++)
            {
                var cur = new Dictionary<int, int>();

                for(int mask2=0; mask2 < maskLen; mask2++)
                {
                    if (adjacent.ContainsKey(mask2))
                    {
                        foreach(var mask1 in adjacent[mask2])
                        {
                            if(!cur.ContainsKey(mask2))
                                cur.Add(mask2, 0);

                            cur[mask2] = (cur[mask2] + result[mask1]) % MOD;
                        }
                    }
                }

                result = cur;
            }

            return result;
        }
    }
}
