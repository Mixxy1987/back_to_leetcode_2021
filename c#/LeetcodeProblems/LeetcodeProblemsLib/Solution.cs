using System.Collections.Generic;

namespace LeetcodeProblemsLib
{
    public class Solution
    {
        /// <summary>
        /// N 1122
        /// https://leetcode.com/problems/relative-sort-array/
        /// </summary>
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            var res1 = new List<int>(arr1.Length);
            var res2 = new List<int>();
            var pr = new Dictionary<int, int>();
            
            for (var i = 0; i < arr2.Length; i++) pr[arr2[i]] = i;

            for (var i = 0; i < arr1.Length; i++)
                if (pr.ContainsKey(arr1[i])) res1.Add(arr1[i]);
                else res2.Add(arr1[i]);

            res1.Sort(new DuplicateKeyComparer(pr));
            res2.Sort();
            res1.AddRange(res2);
            return res1.ToArray();
        }

        private struct DuplicateKeyComparer : IComparer<int>
        {
            private readonly Dictionary<int, int> _pr;
            public DuplicateKeyComparer(Dictionary<int, int> pr) => _pr = pr;
            public int Compare(int x, int y) => _pr[x] >= _pr[y] ? 1 : -1;
        }
    }
}
