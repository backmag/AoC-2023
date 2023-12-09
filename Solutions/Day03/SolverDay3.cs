using System.Data;
using System.Text.RegularExpressions;

namespace AoC_2023.Solutions.Day03
{
    public class SolverDay3 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay3(InputService inputService)
        {
            _inputService = inputService;
        }

        public override int SolvePartOne()
        {
            var input = GetInput();
            int lineIndex = 0;
            var validEngineParts = new List<int>();

            while (lineIndex < input.Length)
            {
                var numbers = ExtractNumbers(input[lineIndex]);
                var indexString = input[lineIndex];

                foreach (var number in numbers)
                {
                    var startIndex = indexString.IndexOf(number);
                    var stopIndex = startIndex + number.Length - 1;
                    indexString = new string('.', stopIndex) + indexString.Substring(stopIndex, indexString.Length - stopIndex);
                    if (HasAdjacentSymbol(startIndex, stopIndex, lineIndex, input))
                    {

                        validEngineParts.Add(int.Parse(number));
                    }
                }
                lineIndex++;
            }
            return validEngineParts.Sum();
        }

        public static string[] ExtractNumbers(string line)
        {
            MatchCollection matches = Regex.Matches(line, "\\d+");
            if (matches.Count == 0)
            {
                return Array.Empty<string>();
            }
            return matches.Select(e => e.Value).ToArray();
        }

        public static bool HasAdjacentSymbol(int startIndex, int stopIndex, int lineIndex, string[] input)
        {

            if (CheckLeftAndRight(startIndex, stopIndex, input[lineIndex]))
            {
                return true;
            }
            if (lineIndex > 0)
            {
                if (CheckLine(startIndex, stopIndex, input[lineIndex - 1]))
                {
                    return true;
                }
            }
            if (lineIndex < input.Length - 1)
            {
                if (CheckLine(startIndex, stopIndex, input[lineIndex + 1]))
                {
                    return true;
                }
            }
            return false;
        }


        public static bool CheckLeftAndRight(int startIndex, int stopIndex, string line)
        {

            var pattern = "[^\\d|^\\.]";
            if (startIndex > 0)
            {
                var leftChar = line[startIndex - 1].ToString();
                if (Regex.Match(leftChar, pattern).Success)
                {
                    return true;
                }
            }
            if (stopIndex < line.Length - 1)
            {
                var rightChar = line[stopIndex + 1].ToString();
                if (Regex.Match(rightChar, pattern).Success)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckLine(int startIndex, int stopIndex, string line)
        {
            var from = Math.Max(startIndex - 1, 0);
            var to = Math.Min(stopIndex + 1, line.Length - 1);
            var str = line.Substring(from, to - from + 1);
            return ContainsEngineSymbol(str);
        }

        public static bool ContainsEngineSymbol(string str)
        {
            var pattern = "[^\\d|^\\.]";
            return Regex.Match(str, pattern).Success;
        }

        public override int SolvePartTwo()
        {
            var input = GetInput();
            var gears = FindAllGears(input);
            var totalRatio = 0;

            foreach (var gear in gears)
            {
                var gearRow = gear.Item1;
                var gearCol = gear.Item2;

                var gearRatio = GetGearRatio(input, gearRow, gearCol);

                totalRatio += gearRatio;
            }
            return totalRatio;
        }

        public static int GetGearRatio(string[] input, int gearRow, int gearCol)
        {
            var numbers = GetAdjacentNumbers(input, gearRow, gearCol);
            if (numbers.Count == 2)
            {
                return numbers[0] * numbers[1];
            }
            return 0;
        }

        public static List<int> GetAdjacentNumbers(string[] input, int row, int col)
        {
            var nbrs = new List<int>();

            // Get left nbr 
            if (col > 0)
            {
                if (char.IsDigit(input[row][col - 1]))
                {
                    nbrs.Add(GetNumberAround(input[row], col - 1));
                }
            }

            // Get right nbr
            if (col < input[row].Length - 1)
            {
                if (char.IsDigit(input[row][col + 1]))
                {
                    nbrs.Add(GetNumberAround(input[row], col + 1));
                }
            }
            // Check row above
            if (row > 0)
            {
                foreach (var nbr in GetAdjacentRowNumbers(input[row - 1], col))
                {
                    nbrs.Add(nbr);
                }
            }
            if (row < input.Length - 1)
            {
                foreach (var nbr in GetAdjacentRowNumbers(input[row + 1], col))
                {
                    nbrs.Add(nbr);
                }
            }
            return nbrs;
        }

        public static List<int> GetAdjacentRowNumbers(string str, int midCol)
        {
            var numbers = new List<int>();

            if (midCol == 0)
            {
                if (char.IsDigit(str[0]))
                {
                    numbers.Add(GetNumberAround(str, 0));
                    return numbers;
                }
                if (char.IsDigit(str[1]))
                {
                    numbers.Add(GetNumberAround(str, 1));
                    return numbers;
                }
            }
            if (midCol == str.Length - 1)
            {
                if (char.IsDigit(str[midCol - 1]))
                {
                    numbers.Add(GetNumberAround(str, midCol - 1));
                    return numbers;
                }
                if (char.IsDigit(str[midCol]))
                {
                    numbers.Add(GetNumberAround(str, midCol));
                    return numbers;
                }
            }
            // midCol is not on the edge 
            if (char.IsDigit(str[midCol - 1]) && char.IsDigit(str[midCol]) && char.IsDigit(str[midCol + 1]))
            {
                numbers.Add(GetNumberAround(str, midCol));
                return numbers;
            }
            if (char.IsDigit(str[midCol - 1]))
            {
                numbers.Add(GetNumberAround(str, midCol - 1));
            }
            else if (char.IsDigit(str[midCol]))
            {
                numbers.Add(GetNumberAround(str, midCol));
                return numbers;
            }
            if (char.IsDigit(str[midCol + 1]))
            {
                numbers.Add(GetNumberAround(str, midCol + 1));
            }
            return numbers;
        }

        public static int GetNumberAround(string str, int index)
        {
            var leftSubstring = str[..index];
            var rightSubstring = str[(index + 1)..];
            var leftNbr = leftSubstring.Reverse().TakeWhile(e => char.IsDigit(e)).Reverse().ToList();
            var rightNbr = rightSubstring.TakeWhile(e => char.IsDigit(e)).ToList();

            var retString = String.Join("", leftNbr) + str[index] + String.Join("", rightNbr);

            return int.Parse(retString);
        }


        public static List<Tuple<int, int>> FindAllGears(string[] input)
        {
            var lineIndex = 0;
            var colIndex = 0;
            var gearCoordinates = new List<Tuple<int, int>>();
            while (lineIndex < input.Length)
            {
                while (colIndex < input[lineIndex].Length)
                {
                    if (input[lineIndex][colIndex] == '*')
                    {
                        gearCoordinates.Add(new Tuple<int, int>(lineIndex, colIndex));
                    }
                    colIndex++;
                }
                colIndex = 0;
                lineIndex++;
            }
            return gearCoordinates;
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
