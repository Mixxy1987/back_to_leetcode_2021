using System.Collections.Generic;

namespace LeetcodeProblemsLib
{
    public class Solution
    {
        /// <summary>
        /// 1572. Matrix Diagonal Sum
        /// https://leetcode.com/problems/matrix-diagonal-sum/
        /// </summary>
        public int DiagonalSum(int[][] mat)
        {
            int sum = 0;
            int i   = 0;
            foreach (var m in mat)
            {
                sum += m[i];
                sum += m[m.Length - i - 1];
                i++;
            }

            if (mat[0].Length % 2 != 0)
            {
                var mid = mat[0].Length / 2;
                sum -= mat[mid][mid];
            }

            return sum;
        }

        /// <summary>
        /// 2133. Check if Every Row and Column Contains All Numbers
        /// https://leetcode.com/problems/check-if-every-row-and-column-contains-all-numbers/
        /// </summary>
        public bool CheckValid(int[][] matrix)
        {
            foreach (var line in matrix)
            {
                if (!CheckLine(line)) return false;
            }

            for (var i = 0; i < matrix[0].Length; i++)
            {
                var list = new List<int>();
                foreach (var t in matrix)
                {
                    list.Add(t[i]);
                }
                if(!CheckLine(list)) return false;
            }

            return true;

            bool CheckLine(IEnumerable<int> line)
            {
                var hs = new HashSet<int>();
                foreach (var item in line)
                {
                    if(hs.Contains(item)) return false;
                    hs.Add(item);
                }

                return true;
            }
        }

        /// <summary>
        /// 36. Valid Sudoku
        /// https://leetcode.com/problems/valid-sudoku/
        /// </summary>
        public bool IsValidSudoku(char[][] board)
        {
            foreach (var line in board)
            {
                if(!IsArrayValid(line)) return false;
            }

            for (var i = 0; i < 9; i++)
            {
                if (!IsArrayValid(new List<char> {board[0][i],board[1][i],board[2][i],board[3][i],board[4][i],board[5][i],board[6][i],board[7][i],board[8][i]}))
                    return false;
            }

            for (var i = 0; i < 9; i+= 3)
            {
                for (var j = 0; j < 9; j += 3)
                {
                    if (!IsArrayValid(new List<char>
                        {
                            board[i][j], board[i][j+1], board[i][j+2],
                            board[i+1][j], board[i+1][j+1], board[i+1][j+2],
                            board[i+2][j], board[i+2][j+1], board[i+2][j+2]
                        }))
                        return false;
                }
            }

            bool IsArrayValid(IEnumerable<char> arr)
            {
                var hs = new HashSet<char>();

                foreach (var item in arr)
                {
                    if (item == '.') continue;
                    if (hs.Contains(item)) return false;
                    hs.Add(item);
                }

                return true;
            }

            return true;
        }

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
