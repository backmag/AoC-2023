namespace AoC_2023.Solutions.Day8
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne1()
        {
            var input = InputService.SplitToArray(@"RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)");
            var expected = 2;

            SolverDay8 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestPartOne2()
        {
            var input = InputService.SplitToArray(@"LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)");
            var expected = 6;

            SolverDay8 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)");

            var expected = 6;

            SolverDay8 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
