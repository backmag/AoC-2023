using System.Numerics;

namespace AoC_2023.Solutions.Day5
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4");
            var expected = 35;

            SolverDay5 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateMappers()
        {
            var input = InputService.SplitToArray(@"seed-to-soil map:
50 98 2
52 50 48");
            var actual = new SolverDay5.Mapper(input).GetName();
            var expected = "seed-to-soil";

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestMapper1()
        {
            var input = InputService.SplitToArray(@"seed-to-soil map:
52 98 48");
            var mapper = new SolverDay5.Mapper(input);
            var inputSeed = 99;
            var expected = 53;

            var actual = mapper.MapInputToOutput(inputSeed);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMapper2()
        {
            var input = InputService.SplitToArray(@"seed-to-soil map:
52 98 48");
            var mapper = new SolverDay5.Mapper(input);
            var inputSeed = 1;
            var expected = 1;

            var actual = mapper.MapInputToOutput(inputSeed);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMapper3()
        {
            var input = InputService.SplitToArray(@"seed-to-soil map:
52 98 2");
            var mapper = new SolverDay5.Mapper(input);
            var inputSeed = 99;
            var expected = 53;

            var actual = mapper.MapInputToOutput(inputSeed);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMapper4()
        {
            var input = InputService.SplitToArray(@"seed-to-soil map:
52 98 2");
            var mapper = new SolverDay5.Mapper(input);
            var inputSeed = 100;
            var expected = 100;

            var actual = mapper.MapInputToOutput(inputSeed);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMapper5()
        {
            var input = InputService.SplitToArray(@"seed-to-soil map:
1716002126 3982609232 32819234");
            var mapper = new SolverDay5.Mapper(input);
            BigInteger inputSeed = 3982609232;
            BigInteger expected = 1716002126;

            var actual = mapper.MapInputToOutput(inputSeed);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestOutputInputMapper1()
        {
            var input = InputService.SplitToArray(@"seed-to-soil map:
1716002126 3982609232 32819234");
            var mapper = new SolverDay5.Mapper(input);
            BigInteger inputSeed = 1716002126;
            BigInteger expected = 3982609232;

            var actual = mapper.MapOutputToInput(inputSeed);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestOutputInputMapper2()
        {
            var input = InputService.SplitToArray(@"seed-to-soil map:
52 98 48");
            var mapper = new SolverDay5.Mapper(input);
            var inputValue = 52;
            var expected = 98;

            var actual = mapper.MapOutputToInput(inputValue);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSeedRange()
        {
            var seedRange = new SolverDay5.SeedRange("10 5 20 4");
            var val = 15; 

            Assert.False(seedRange.ContainsSeed(val));
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4");

            var expected = 46;

            SolverDay5 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
