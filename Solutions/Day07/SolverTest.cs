namespace AoC_2023.Solutions.Day7
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"");
            var expected = 0;

            SolverDay7 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"");

            var expected = 0;

            SolverDay7 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
