namespace AoC_2023.Solutions.Day4
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11");
            var expected = 13;

            SolverDay4 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestGetGameNumber1()
        {
            var input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
            var expected = 1;
            var actual = SolverDay4.GetGameNumber(input);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestGetGameNumber2()
        {
            var input = "Card 100: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
            var expected = 100;
            var actual = SolverDay4.GetGameNumber(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetWinningNumbers()
        {
            var input = "Card 100: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
            var expected = new List<int>
            {
                41, 48, 83, 86, 17
            };
            var actual = SolverDay4.GetWinningNumbers(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetMyNumbers()
        {
            var input = "Card 100: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
            var expected = new List<int>
            {
                83, 86, 6, 31, 17, 9, 48, 53
            };
            var actual = SolverDay4.GetMyNumbers(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11");
            var expected = 30;

            SolverDay4 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
