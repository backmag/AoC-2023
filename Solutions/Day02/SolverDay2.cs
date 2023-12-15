using System.Numerics;

namespace AoC_2023.Solutions.Day02
{
    public class SolverDay2 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay2(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();

            var limits = new Dictionary<string, int>
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 },
            };

            var validGames = new List<int>();

            foreach (var line in input)
            {
                var gameNbr = ExtractGameNumber(line);
                var picks = ExtractPicks(line);
                if (IsPossible(picks, limits))
                {
                    validGames.Add(gameNbr);
                }
            }
            return (BigInteger)validGames.Sum();
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            var powerList = new List<int>();

            foreach (var line in input)
            {
                var picks = ExtractPicks(line);
                var minByColor = GetMinimumByColor(picks);
                powerList.Add(CalculatePower(minByColor));
            }
            return (BigInteger)powerList.Sum();
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
        public static int CalculatePower(Dictionary<string, int> colors)
        {
            var retPower = 1;
            foreach (var color in colors.Keys)
            {
                retPower *= colors[color];
            }
            return retPower;
        }

        public static bool IsPossible(List<Dictionary<string, int>> picks, Dictionary<string, int> limits)
        {
            foreach (var pick in picks)
            {
                foreach (var color in pick.Keys)
                {
                    if (pick[color] > limits[color])
                    {
                        return false;
                    }
                }
            }
            return true;

        }
        public static int ExtractGameNumber(string line)
        {
            var digit = line.Split(":").First().Where(char.IsDigit).ToArray();
            return int.Parse(digit);
        }
        public static List<Dictionary<string, int>> ExtractPicks(string line)
        {
            var retList = new List<Dictionary<string, int>>();
            var pickStrings = line.Split(":").Last().Split(";").ToList();
            foreach (var pick in pickStrings)
            {
                var pickDict = new Dictionary<string, int>();
                foreach (var item in pick.Split(",").ToList())
                {
                    var nbr = int.Parse(item.Trim().Split(" ").First().Trim());
                    var color = item.Trim().Split(" ").Last().Trim();
                    pickDict.Add(color, nbr);
                }
                retList.Add(pickDict);
            }
            return retList;
        }

        public static Dictionary<string, int> GetMinimumByColor(List<Dictionary<string, int>> picks)
        {
            var retDict = new Dictionary<string, int>();

            foreach (var pick in picks)
            {
                foreach (var color in pick.Keys)
                {
                    if (retDict.ContainsKey(color))
                    {
                        if (retDict[color] < pick[color])
                        {
                            retDict[color] = pick[color];
                        }
                    }
                    else
                    {
                        retDict.Add(color, pick[color]);
                    }
                }
            }
            return retDict;
        }
    }
}
