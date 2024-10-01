using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Xunit.Sdk;

namespace AoC_2023.Solutions.Day12
{
    public class SolverDay12 : Solver
    {
        private readonly InputService _inputService;
        private Dictionary<Tuple<string, string, int>, long> dp;
        public SolverDay12(InputService inputService)
        {
            _inputService = inputService;
            dp = [];
        }
        private int _totalCalls;
        private int _cachedCalls;


        public override BigInteger SolvePartOne()
        {
            var input = GetInput();
            long totalNbrArrangements = 0;

            foreach (var row in input)
            {
                var pattern = row.Split(" ").First();
                int[] groups = row.Split(" ").Last().Split(",").Select(e => int.Parse(e)).ToArray();
                long nbrArrangements = CalculateNbrArrangements(String.Concat(pattern, "."), groups, 0);
                totalNbrArrangements += nbrArrangements;
            }

            return (BigInteger)totalNbrArrangements;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            long totalNbrArrangements = 0;
            var currentRow = 0;

            foreach (var row in input)
            {
                var pattern = row.Split(" ").First();
                var foldedPattern = pattern + "?" + pattern + "?" + pattern + "?" + pattern + "?" + pattern;
                int[] groups = row.Split(" ").Last().Split(",").Select(e => int.Parse(e)).ToArray();
                int[] newGroups = new int[groups.Length * 5];
                int idx = 0;
                for (int i = 0; i < 5; i++)
                {
                    foreach (var group in groups)
                    {
                        newGroups[idx] = group;
                        idx++;
                    }
                }
                dp = [];
                long nbrArrangements = CalculateNbrArrangements(String.Concat(foldedPattern, "."), newGroups, 0);
                totalNbrArrangements += nbrArrangements;
                //Console.WriteLine(String.Format("Processing...({0} %). Value: {1}",
                //    (double)100 * currentRow / input.Length,
                //    nbrArrangements
                //    ));
                currentRow++;
            }
            Console.WriteLine(String.Format("Total calls: {0} \t Cached calls: {1}", _totalCalls, _cachedCalls));
            return (BigInteger)totalNbrArrangements;
        }

        private long CalculateNbrArrangements(string pattern, int[] springs, int currentStreak)
        {
            _totalCalls++;
            // handle single case
            if (pattern.Length == 1)
            {
                if (springs.Length > 1) return 0;
                switch (pattern.First())
                {
                    case '.':
                        if (currentStreak == 0 && springs.Length == 0)
                        {
                            return 1;
                        }
                        if (springs.Length == 0) return 0;
                        return currentStreak == springs.First() ? 1 : 0;
                    case '#':
                        return currentStreak + 1 == springs.First() ? 1 : 0;
                    case '?':
                        if (currentStreak == springs.First() || currentStreak + 1 == springs.First())
                        {
                            return 1;
                        }
                        return 0;
                    default:
                        break;
                }
                return 0;
            }

            if (pattern.First() == '.')
            {
                if (currentStreak != 0 && springs.Any() && springs.First() == currentStreak)
                {
                    // valid so far, pop the first spring and continue
                    return GetOrCalculate(pattern[1..], springs[1..], 0);
                }
                if (currentStreak != 0 && springs.Length != 0 && springs.First() != currentStreak)
                {
                    return 0;
                }
                return GetOrCalculate(pattern[1..], springs, currentStreak);
            }
            else if (pattern.First() == '#')
            {
                return GetOrCalculate(pattern[1..], springs, currentStreak + 1);
            }
            else // is '?' 
            {
                return GetOrCalculate(String.Concat(".", pattern[1..]), springs, currentStreak) +
                GetOrCalculate(String.Concat("#", pattern[1..]), springs, currentStreak);
            }
        }

        private long GetOrCalculate(string pattern, int[] springs, int currentStreak)
        {
            var dpKey = Tuple.Create(pattern, String.Join(",", springs), currentStreak);
            if (!dp.TryGetValue(dpKey, out long value))
            {
                value = CalculateNbrArrangements(pattern, springs, currentStreak);
                dp[dpKey] = value;
            }
            else
            {
                _cachedCalls++;
            }
            return value;
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
