namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 2179. Count Good Triplets in an Array
    /// </summary>
    public class CountGoodTripletsinArray
    {
        public long GoodTripletsOld(int[] nums1, int[] nums2) //Atempt 1 seems working but not fast enough
        {
            int  n = nums1.Length;
            long counter = 0;
            var indices2 = new int[n];

            for (int i = 0; i < n; i++)
                indices2[nums2[i]] = i;

            for(int i = 1; i < n - 1; i++)
            {
                long lhs =0, rhs =0;
                var index = indices2[nums1[i]];

                for(int j = i - 1; j >= 0; j--)
                {
                    if (indices2[nums1[j]] < index)
                        lhs++;
                }

                for (int j = i + 1; j < n; j++)
                {
                    if (indices2[nums1[j]] > index)
                        rhs++;
                }

                counter += lhs * rhs;
            }

            return counter;
        }

        public long GoodTriplets(int[] nums1, int[] nums2)
        {
            int n = nums2.Length;
            var mpp = new int[n];

            for (int i = 0; i < nums1.Length; i++)
            {
                mpp[nums1[i]] = i;
            }
            
            long total = 0;
            List<int> st = new List<int>();

            foreach (int x in nums2)
            {
                int idx = mpp[x];
                int left = OrderOfKey(st, idx);
                int right = (n - 1 - idx) - (st.Count - left);
                total += (long)left * right;

                int pos = st.BinarySearch(idx);
                if (pos < 0) pos = ~pos;
                st.Insert(pos, idx);
            }

            return total;
        }

        private int OrderOfKey(List<int> st, int key)
        {
            int pos = st.BinarySearch(key);
            return pos < 0 ? ~pos : pos;
        }
    }
}
