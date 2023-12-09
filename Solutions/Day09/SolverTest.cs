namespace AoC_2023.Solutions.Day9
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45");
            var expected = 114;

            SolverDay9 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"");

            var expected = 0;

            SolverDay9 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
