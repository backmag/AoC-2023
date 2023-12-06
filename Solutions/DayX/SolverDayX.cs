namespace AoC_2023.Solutions.DayX
{
    public class SolverDayX : Solver
    {
        private readonly InputService _inputService;
        public SolverDayX(InputService inputService)
        {
            _inputService = inputService;
        }

        public override int SolvePartOne()
        {
            var input = GetInput();

            return 0;
        }

        public override int SolvePartTwo()
        {
            var input = GetInput();
            return 0;
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
