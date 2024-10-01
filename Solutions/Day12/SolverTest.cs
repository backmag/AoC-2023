namespace AoC_2023.Solutions.Day12
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne_1()
        {
            var input = InputService.SplitToArray(@"???.### 1,1,3
.??..??...?##. 1,1,3
?#?#?#?#?#?#?#? 1,3,1,6
????.#...#... 4,1,1
????.######..#####. 1,6,5
?###???????? 3,2,1");
            var expected = 21;

            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne_2()
        {
            var input = InputService.SplitToArray(@"?###???????? 3,2,1");
            var expected = 10;

            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne_2a()
        {
            var input = InputService.SplitToArray(@"#????. 2,1");
            var expected = 2;
            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne_3()
        {
            var input = InputService.SplitToArray(@".??..??...?##. 1,1,3");
            var expected = 4;

            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne_4()
        {
            var input = InputService.SplitToArray(@"?#?#?#?#?#?#?#? 1,3,1,6");
            var expected = 1;

            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne_5()
        {
            var input = InputService.SplitToArray(@"????.#...#... 4,1,1");
            var expected = 1;

            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne_6()
        {
            var input = InputService.SplitToArray(@"????.######..#####. 1,6,5");
            var expected = 4;

            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestPartTwo_1()
        {
            var input = InputService.SplitToArray(@"???.### 1,1,3
.??..??...?##. 1,1,3
?#?#?#?#?#?#?#? 1,3,1,6
????.#...#... 4,1,1
????.######..#####. 1,6,5
?###???????? 3,2,1");
            var expected = 525152;

            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestPartTwo_2()
        {
            var input = InputService.SplitToArray(@"????.#...#... 4,1,1");
            var expected = 16;

            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"");

            var expected = 0;

            SolverDay12 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
