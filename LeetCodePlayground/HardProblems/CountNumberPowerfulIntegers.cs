namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 2999. Count the Number of Powerful Integers
    /// </summary>
    public class CountNumberPowerfulIntegers
    {
        public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
        {
            int suffix = int.Parse(s);
            int n = (int)Math.Floor(Math.Log10(finish)) + 1;
            int startLen = (int)Math.Floor(Math.Log10(start)) + 1;
            int startIndex = Math.Max(startLen - 1, s.Length);
            var dp = new long[n];

            if (finish < suffix)
                return 0;

            dp[startIndex-1] = 1;

            for(int i = startIndex; i < n; i++)
            {
                if (i == startIndex)
                {
                    int counter = 1;
                    
                }
                else if (i == n - 1)
                {
                    int counter = 1;
                    string dummy = '1' + new string((char)limit, i - s.Length)+s;
                    long number = long.Parse(dummy);
                    for(int j = 0; j < limit;  j++)
                    {
                       if(number + j* Math.Pow(10,i-1) <= finish)
                            counter++;
                    }
                    dp[i] = dp[i - 1] * counter;
                }
                else
                    dp[i] = dp[i-1] * limit;
            }
            
            return dp[n - 1];
        }
    }
}
