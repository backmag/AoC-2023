namespace AoC_2023.Solutions.Day13
{
    public class SolverTest
    {

        [Fact]
        public void TestFlipOne()
        {
            var input = new string[]
            {
                "#.#",
                "...",
                "###",
            };
            var expected = new string[]
            {
                "#.#",
                "..#",
                "#.#",
            };
            Frame frame = new(input);

            frame.Flip();
            var actual = frame.GetFrame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestFlipTwo()
        {
            var input = new string[]
            {
                "#.#...",
                "......",
                "###...",
            };
            var expected = new string[]
            {
                "#.#",
                "..#",
                "#.#",
                "...",
                "...",
                "...",
            };
            Frame frame = new(input);

            frame.Flip();
            var actual = frame.GetFrame();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestFlipThree()
        {
            var input = new string[]
            {
"#..#..##.#.",
"#..#..##.#.",
"......#..##",
"##########.",
"..####.#.##",
"#.#.##....#",
"..#.##....#",
"..####.#.##",
"##########.",
"......#..##",
"#..#..##.#."
            };

            var expected = new string[]
            {
"##.#.#..#.#",
"...#....#..",
"...######..",
"##.##..##.#",
"...######..",
"...######..",
"####....###",
"##.##..##.#",
"...#....#..",
"#####..####",
"..#.####.#."
};

            Frame frame = new(input);

            Assert.Equal(frame.GetFrame(), input);

            frame.Flip();
            var actual = frame.GetFrame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMirrorFrameOne()
        {
            Frame frame = new(
            [
                "#...##..#",
                "#....#..#",
                "..##..###",
                "#####.##.",
                "#####.##.",
                "..##..###",
                "#....#..#"
            ]);
            var expected = 4;

            var actual = frame.FindMirrorRow();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMirrorFrameFlipped()
        {
            Frame frame = new(
            [
                "#.##..##.",
                "..#.##.#.",
                "##......#",
                "##......#",
                "..#.##.#.",
                "..##..##.",
                "#.#.##.#.",
            ]);
            frame.Flip();

            var expected = 5;

            var actual = frame.FindMirrorRow();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestChangeSymbol()
        {
            Frame frame = new(
            [
                "#.#",
                "...",
                "###",
            ]);

            string[] expected =
            [
                "..#",
                "...",
                "###",
            ];

            frame.ChangeSymbol(0, 0);
            var actual = frame.GetFrame();
            Assert.Equal(expected, actual);

            expected =
            [
                "#.#",
                "...",
                "###",
            ];
            frame.ChangeSymbol(0, 0);
            actual = frame.GetFrame();
            Assert.Equal(expected, actual);


            expected =
            [
                "#.#",
                "...",
                "##.",
            ];
            frame.ChangeSymbol(2, 2);
            actual = frame.GetFrame();
            Assert.Equal(expected, actual);

            for (int row = 0; row < actual.Length; row++)
            {
                for (int col = 0; col < actual[0].Length; col++)
                {
                    frame.ChangeSymbol(row, col);
                }
            }

            expected =
            [
                ".#.",
                "###",
                "..#",
            ];
            actual = frame.GetFrame();
            Assert.Equal(expected, actual);

            for (int row = 0; row < actual.Length; row++)
            {
                for (int col = 0; col < actual[0].Length; col++)
                {
                    frame.ChangeSymbol(row, col);
                }
            }

            expected =
            [
                "#.#",
                "...",
                "##.",
            ];
            actual = frame.GetFrame();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.

#...##..#
#....#..#
..##..###
#####.##.
#####.##.
..##..###
#....#..#");

            var expected = 405;

            SolverDay13 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo_1()
        {
            var input = InputService.SplitToArray(@"#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.

#...##..#
#....#..#
..##..###
#####.##.
#####.##.
..##..###
#....#..#");

            var expected = 400;

            SolverDay13 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo_2()
        {
            var input = InputService.SplitToArray(@"#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.");

            var expected = 300;

            SolverDay13 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestPartTwo_3()
        {
            var input = InputService.SplitToArray(@"#...##..#
#....#..#
..##..###
#####.##.
#####.##.
..##..###
#....#..#");

            var expected = 100;

            SolverDay13 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo_4()
        {
            var input = InputService.SplitToArray(@"#...##..#
#..#####.##.#.#..
####..#.#....####
..##.......##.#.#
#..######.#.#####
#..######.#.#####
..##.......##.#.#
####..#.#....####
#..#####.##.#.#..
#..#...###..#..#.
#..#.###.#..#...#
###.##..#.####.#.
.##.###.##...#.##
##.###.#..###..##
#..###.#..###..##
.##.###.##...#.##
###.##..#.####.#.
#..#.###.#..#...#");

            var expected = 1400;

            SolverDay13 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo_5()
        {
            var input = InputService.SplitToArray(@"..#..#...#..#..#.
.#.....#..##....#
..###.#.#....##..
#..#..#..###.##.#
###...##.###.##.#
#..##..###.#....#
.###.######.#..#.
###.#..#....####.
...#..#..#..#..#.
##.#..###.#......
.##.#..###.######
....#.##..##.##.#
..###...####....#
..#...#...##.##.#
..#...#.#.##.##.#");
            var expected = 1400;

            SolverDay13 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo_6()
        {
            var input = InputService.SplitToArray(@"####..##.#.##.#.#
##.##.###########
...##....##..##..
####.###..####..#
...#.####.#..#.##
.......#.#.##.#.#
.....#.#.#..#.#.#");
            var expected = 12;

            SolverDay13 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo_7()
        {
            var input = InputService.SplitToArray(@"#..#..##.#.
#..#..##.#.
......#..##
##########.
..####.#.##
#.#.##....#
..#.##....#
..####.#.##
##########.
......#..##
#..#..##.#.");
            var expected = 600;

            SolverDay13 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
