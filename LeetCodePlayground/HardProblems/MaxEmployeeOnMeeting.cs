namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 2127. Maximum Employees to Be Invited to a Meeting
    /// </summary>
    internal class MaxEmployeeOnMeeting
    {
        public int MaximumInvitations(int[] favorite)
        {
            int n = favorite.Length;
            int[] visited = new int[n];
            int[] depth = new int[n];
            int maxCycleSize = 0, mutualChainsSize = 0;

            int FindCycleLen(int start)
            {
                int current = start, count = 0;

                while (visited[current] == 0)
                {
                    visited[current] = 1;
                    current = favorite[current];
                    count++;
                }
                return count;
            }

            int FindChainLen(int node, int skip)
            {
                visited[node] = 1;
                int maxDepth = 0;

                for (int i = 0; i < n; i++)
                {
                    if (favorite[i] == node && i != skip && visited[i] == 0)
                        maxDepth = Math.Max(maxDepth, FindChainLen(i, skip));
                }
                return maxDepth + 1;
            }

            for (int i = 0; i < n; i++)
            {
                if (visited[i] == 0)
                {

                    int cycleLen = FindCycleLen(i);

                    if (cycleLen == 2)
                    {
                        int chain1 = FindChainLen(i, favorite[i]);
                        int chain2 = FindChainLen(favorite[i], i);

                        mutualChainsSize += chain1 + chain2;
                    }
                    else
                    {
                        maxCycleSize = Math.Max(maxCycleSize, cycleLen);
                    }
                }
            }

            return Math.Max(maxCycleSize, mutualChainsSize);
        }
    }
}
