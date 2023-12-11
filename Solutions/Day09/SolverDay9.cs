namespace AoC_2023.Solutions.Day09
{
    public class SolverDay9 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay9(InputService inputService)
        {
            _inputService = inputService;
        }

        public override int SolvePartOne()
        {
            var input = GetInput();
            var extrapolatedSum = 0;

            foreach (var line in input)
            {
                extrapolatedSum += ExtrapolateOasis(line.Split(" ").Select(e => int.Parse(e)).ToList());
            }
            return extrapolatedSum;
        }

        public override int SolvePartTwo()
        {
            var input = GetInput();
            var extrapolatedSum = 0;

            foreach (var line in input)
            {
                extrapolatedSum += ExtrapolateOasis(
                    line.Split(" ").Select(e => int.Parse(e)).ToList(),
                    forward: false);
            }
            return extrapolatedSum;
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
        public static int ExtrapolateOasis(List<int> numbers, bool forward = true)
        {
            var diffList = numbers.
                Skip(1).
                Select((number, idx) => number - numbers[idx]).
                ToList();

            if (diffList.Count(e => e != 0) == 0)
            {
                if (forward)
                {
                    return numbers.Last();
                }
                else return numbers.First();
            }
            if (forward)
            {
                return numbers.Last() + ExtrapolateOasis(diffList, forward);
            }
            return numbers.First() - ExtrapolateOasis(diffList, forward);
        }
    }
}
