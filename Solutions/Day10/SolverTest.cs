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
        public void TestPartTwo_1()
        {
            var input = InputService.SplitToArray(@"FF7FSF7F7F7F7F7F---7
L|LJ||||||||||||F--J
FL-7LJLJ||||||LJL-77
F--JF--7||LJLJ7F7FJ-
L---JF-JLJ.||-FJLJJ7
|F|F-JF---7F7-L7L|7|
|FFJF7L7F-JF7|JL---7
7-L-JL7||F7|L7F-7F7|
L.L7LFJ|||||FJL7||LJ
L7JLJL-JLJLJL--JLJ.L");

            var expected = 10;

            SolverDay10 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo_2()
        {
            var input = InputService.SplitToArray(@"...........
.S-------7.
.|F-----7|.
.||.....||.
.||.....||.
.|L-7.F-J|.
.|..|.|..|.
.L--J.L--J.
...........");

            var expected = 4;

            SolverDay10 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
