namespace AoC_2023.Solutions.Day3
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..");
            var expected = 4361;

            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne1()
        {
            var input = InputService.SplitToArray(@"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..
=.........
10000.....");
            var expected = 14361;

            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne2()
        {
            var input = InputService.SplitToArray(@"400..114..
...*......
..30..633.
6171......
..64.598..
=.........
100.......");
            var expected = 530;

            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestPartOne3()
        {
            var input = InputService.SplitToArray(@".....180.........230..........................218.....189......415.......................322....507..................206..............111...
........*.602.........571-.......................*...*.............199.....$.........181.......*......980....292............................
..509.923.=....................+......835*......608.984..............-.801..922.156...*.........533.....$.......*678.......&................");
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();
            var expected = 9402;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne4()
        {
            var input = InputService.SplitToArray(@"40...114..
...*......
..30..30..
6171......
100.......");
            var expected = 30;

            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestPartOne5()
        {
            var input = InputService.SplitToArray(@"40...114..
.........#
..30..300.
100.......");
            var expected = 300;

            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestHasAdjacentSymbol1()
        {
            var input = InputService.SplitToArray(@"467..114..
...*.....");
            var actual = SolverDay3.HasAdjacentSymbol(0, 2, 0, input);

            Assert.True(actual);
        }
        [Fact]
        public void TestHasAdjacentSymbol2()
        {
            var input = InputService.SplitToArray(@"467..114..
...*.....");
            var actual = SolverDay3.HasAdjacentSymbol(5, 7, 0, input);

            Assert.False(actual);
        }
        [Fact]
        public void TestHasAdjacentSymbol3()
        {
            var input = InputService.SplitToArray(@".........
...*.....
...1.....
.........");
            var actual = SolverDay3.HasAdjacentSymbol(3, 3, 2, input);

            Assert.True(actual);
        }

        [Fact]
        public void TestHasAdjacentSymbol4()
        {
            var input = InputService.SplitToArray(@".........
........*
........1
.........");
            var actual = SolverDay3.HasAdjacentSymbol(8, 8, 2, input);

            Assert.True(actual);
        }


        [Fact]
        public void TestExtractNumbers()
        {
            var input = "..123...";
            var actual = SolverDay3.ExtractNumbers(input);
            var expected = new String[] { "123" };

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestCheckLeftAndRight()
        {
            var inputLine = "..123$.";
            var startIndex = 2;
            var stopIndex = 4;

            var actual = SolverDay3.CheckLeftAndRight(startIndex, stopIndex, inputLine);

            Assert.True(actual);
        }


        [Fact]
        public void TestDoesNotContainsEngineSymbol()
        {
            var input = "...";
            var actual = SolverDay3.ContainsEngineSymbol(input);

            Assert.False(actual);
        }

        [Fact]
        public void TestContainsEngineSymbol()
        {
            var input = ".$.";
            var actual = SolverDay3.ContainsEngineSymbol(input);

            Assert.True(actual);
        }

        [Fact]
        public void TestPartTwo1()
        {
            var input = InputService.SplitToArray(@"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..");

            var expected = 467835;

            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestPartTwo2()
        {
            var input = InputService.SplitToArray(@"467..114..
..........
..10..633.
..*...#...
10...+.58.
*.592.....
.20...75.5
.664.59.1*");

            var expected = 305;

            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo3()
        {
            var input = InputService.SplitToArray(@"12.......*..
+.........34
.......-12..
..78........
..*....60...
78..........
.......23...
....90*12...
............
2.2......12.
.*.........*
1.1.......56");

            var expected = 6756;
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo4()
        {
            var input = InputService.SplitToArray(@"12.......*..
+.........34
.......-12..
..78........
..*....60...
78.........9
.5.....23..$
8...90*12...
............
2.2......12.
.*.........*
1.1..503+.56");

            var expected = 6756;
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);

        }


        [Fact]
        public void TestPartTwo5()
        {
            var input = InputService.SplitToArray(@".....24.*23.
..10........
..397*.610..
.......50...
1*2..4.....");

            var expected = 2;
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo6()
        {
            var input = InputService.SplitToArray(@".....24..23.
.100...50...
1.2.*4.....");

            var expected = 400;
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestPartTwo7()
        {
            var input = InputService.SplitToArray(@"............
..10.10.....
....*.......
.....100...");

            var expected = 0;
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo8()
        {
            var input = InputService.SplitToArray(@"............
.....10.....
....*.......
.....100...");

            var expected = 1000;
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo9()
        {
            var input = InputService.SplitToArray(@"*10.........
1.....0.....
...5*1......
..11..00...");

            var expected = 10;
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestPartTwo10()
        {
            var input = InputService.SplitToArray(@".....180.........230..........................218.....189......415.......................322....507..................206..............111...
........*.602.........571-.......................*...*.............199.....$.........181.......*......980....292............................
..509.923.=....................+......835*......608.984..............-.801..922.156...*.........533.....$.......*678.......&................");

            var expected = 952867;
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestPartTwo11()
        {
            var input = InputService.SplitToArray(@".202.
..*..
0.3..");

            var expected = 606;
            SolverDay3 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetNumberAround()
        {
            var input = "..123...";

            var index = 2;

            var actual = SolverDay3.GetNumberAround(input, index);
            var expected = 123;

            Assert.Equal(expected, actual);
        }
    }
}
// TOO LOW 81938380
