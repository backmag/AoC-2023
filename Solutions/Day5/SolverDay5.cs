using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace AoC_2023.Solutions.Day5
{
    public class SolverDay5 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay5(InputService inputService)
        {
            _inputService = inputService;
        }

        public override int SolvePartOne()
        {
            var input = GetInput();
            var seeds = input[0].Split(":").Last().Trim().Split(" ").Select(e => BigInteger.Parse(e)).ToList();

            var mappers = CreateMappers(input[2..]);
            var minSeed = BigInteger.Parse("10000000000000");

            foreach (var seed in seeds)
            {
                var newSeed = ForwardPass(seed, mappers);
                if (newSeed < minSeed)
                {
                    minSeed = newSeed;
                }
            }
            return (int)minSeed;
        }

        public static List<Mapper> CreateMappers(string[] input)
        {
            var mappers = new List<Mapper>();
            var idx = -1;
            while (idx < input.Length)
            {
                var startIdx = idx + 1;
                idx++;
                while (idx < input.Length && input[idx].Trim() != "")
                {
                    idx++;
                }
                var initString = input[startIdx..idx];
                mappers.Add(new Mapper(initString));
            }
            return mappers;
        }

        public override int SolvePartTwo()
        {
            var input = GetInput();
            var seedRange = new SeedRange(input[0].Split(":").Last().Trim());

            var mappers = CreateMappers(input[2..]);
            mappers.Reverse();

            BigInteger locationValue = 0;
            bool isValidLocation = false;

            while (!isValidLocation)
            {
                BigInteger seedValue = ReversePass(locationValue, mappers);
                if (seedRange.ContainsSeed(seedValue))
                {
                    Console.WriteLine($"Success! Found for {seedValue}, starting at {locationValue}");
                    ReversePass(locationValue, mappers, true);
                    return (int)locationValue;
                }
                else
                {
                    locationValue++;
                }
                if (locationValue % 1000000 == 0)
                {
                    Console.WriteLine($"Location value: {locationValue}");
                }
            }

            return (int)locationValue;

        }

        public static BigInteger ForwardPass(BigInteger val, List<Mapper> mappers)
        {
            BigInteger passedValue = val;
            foreach (var mapper in mappers)
            {
                passedValue = mapper.MapInputToOutput(passedValue);
            }
            return passedValue;

        }
        public static BigInteger ReversePass(BigInteger val, List<Mapper> mappers, bool verbose = false)
        {
            BigInteger passedValue = val;
            foreach (var mapper in mappers.AsEnumerable().Reverse())
            {
                var newValue = mapper.MapOutputToInput(passedValue);
                if (verbose)
                {
                    Console.WriteLine($"Mapper {mapper.GetName()} mapped {passedValue} to {newValue}.");
                }
                passedValue = newValue;
            }
            return passedValue;
        }

        public class SeedRange
        {
            private List<BigInteger> startValues = new List<BigInteger>();
            private List<BigInteger> lengths = new List<BigInteger>();
            public SeedRange(string str)
            {
                var inputs = str.Split(" ").Select(e => BigInteger.Parse(e.Trim())).ToArray();
                var idx = 0;
                while (idx < inputs.Length - 1)
                {
                    startValues.Add(inputs[idx]);
                    lengths.Add(inputs[idx + 1]);
                    idx += 2;
                }
            }
            public bool ContainsSeed(BigInteger value)
            {
                int idx = 0;
                while (idx < startValues.Count)
                {
                    if (startValues[idx] <= value && value < (startValues[idx] + lengths[idx]))
                    {
                        return true;
                    }
                    idx++;
                }
                return false;
            }
        }

        public class Mapper
        {
            private string mapperName;
            private List<BigInteger> inputs = new List<BigInteger>();
            private List<BigInteger> outputs = new List<BigInteger>();
            private List<BigInteger> lengths = new List<BigInteger>();

            public Mapper(string[] mapStrings)
            {
                mapperName = mapStrings[0].Trim().Split(" ").First();

                foreach (var str in mapStrings[1..])
                {
                    if (str.Trim().Length > 0)
                    {
                        outputs.Add(BigInteger.Parse(str.Split(" ").First()));
                        inputs.Add(BigInteger.Parse(str.Split(" ")[1]));
                        lengths.Add(BigInteger.Parse(str.Split(" ").Last()));
                    }
                }
            }

            public string GetName()
            {
                return mapperName;
            }

            public BigInteger MapOutputToInput(BigInteger input)
            {
                var idx = 0;
                while (idx < inputs.Count)
                {
                    if (outputs[idx] <= input && input < (outputs[idx] + lengths[idx]))
                    {
                        return inputs[idx] + (input - outputs[idx]);
                    }
                    idx++;
                }
                return input;
            }

            public BigInteger MapInputToOutput(BigInteger input)
            {
                var idx = 0;
                while (idx < inputs.Count)
                {
                    if (inputs[idx] <= input && input < (inputs[idx] + lengths[idx]))
                    {
                        return outputs[idx] + (input - inputs[idx]);
                    }
                    idx++;
                }
                return input;
            }
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
