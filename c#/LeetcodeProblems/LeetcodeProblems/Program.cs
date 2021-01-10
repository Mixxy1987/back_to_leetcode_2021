using LeetcodeProblemsLib;

namespace LeetcodeProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();

            var res = s.RelativeSortArray(
                new[] {2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19},
                new[] {2, 1, 4, 3, 9, 6});
        }
    }
}
