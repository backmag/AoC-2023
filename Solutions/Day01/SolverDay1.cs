using System.Text.RegularExpressions;

namespace AoC_2023.Solutions.Day01
{
    public class SolverDay1 : Solver
    {
        private readonly InputService _inputService;

        public SolverDay1(InputService inputService)
        {
            _inputService = inputService;

        }
        public override int SolvePartOne()
        {
            var lines = GetInput();
            var coordinates = new List<int>();
            var pattern = "(\\d)";
            foreach (var line in lines)
            {
                coordinates.Add(ExtractCoordinates(line, pattern));
            }
            return coordinates.Sum();
        }

        public override int SolvePartTwo()
        {
            var lines = GetInput();
            var coordinates = new List<int>();
            var pattern = "\\d";
            foreach (var line in lines)
            {
                var replacedString = line.Replace("one", "o1e")
                    .Replace("two", "t2o")
                    .Replace("three", "t3e")
                    .Replace("four", "f4r")
                    .Replace("five", "f5e")
                    .Replace("six", "s6x")
                    .Replace("seven", "s7n")
                    .Replace("eight", "e8t")
                    .Replace("nine", "n9e");
                coordinates.Add(ExtractCoordinates(replacedString, pattern));
            }
            return coordinates.Sum();
        }

        public static int ExtractCoordinates(string line, string pattern)
        {

            var res = Regex.Matches(line, pattern);

            var firstNbr = ParseString(res.First().Value);
            var secondNbr = ParseString(res.Last().Value);
            var retVal = firstNbr * 10 + secondNbr;
            //Console.WriteLine($"Parsed ({firstNbr}, {secondNbr}) from {line}. Result: {retVal}");
            return retVal;
        }

        private static int ParseString(string str)
        {
            var stringDict = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

            int retVal;
            if (stringDict.ContainsKey(str))
            {
                retVal = stringDict[str];
            }
            else
            {
                retVal = int.Parse(str);
            }
            return retVal;
        }
        private string[] GetInput()
        {
            return _inputService.GetInput();
        }

    }
}
