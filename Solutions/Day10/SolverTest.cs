namespace AoC_2023.Solutions.Day10
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne1()
        {
            var input = InputService.SplitToArray(@".....
.S-7.
.|.|.
.L-J.
.....");
            var expected = 4;

            SolverDay10 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne2()
        {
            var input = InputService.SplitToArray(@"..F7.
.FJ|.
SJ.L7
|F--J
LJ...");
            var expected = 8;

            SolverDay10 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"");

            var expected = 0;

            SolverDay10 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
