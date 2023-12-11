namespace AoC_2023.Solutions.Day11
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"...#......
.......#..
#.........
..........
......#...
.#........
.........#
..........
.......#..
#...#.....");

            var expected = 374;

            SolverDay11 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"");

            var expected = 0;

            SolverDay11 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
