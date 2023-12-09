namespace AoC_2023.Solutions.Day09
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
        public void TestExtrapolateOasis1()
        {
            var input = new List<int>
            { 0, 3, 6, 9, 12, 15};
            var expected = 18;
            var actual = SolverDay9.ExtrapolateOasis(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExtrapolateOasis2()
        {
            var input = new List<int>
            { 1, 3, 6, 10, 15, 21 };
            var expected = 28;
            var actual = SolverDay9.ExtrapolateOasis(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45");

            var expected = 2;
            SolverDay9 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
