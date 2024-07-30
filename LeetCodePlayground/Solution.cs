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

        private void PrintStack<T>(Stack<T> stack)
        {
            Stack<T> tempStack = new Stack<T>(stack);
            Console.Write("Stack:");
            foreach (var item in tempStack)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }

        private void PrintArray<T>(T[] array)
        {
            Console.Write("Array:");
            foreach (var item in array)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }
    }
}
