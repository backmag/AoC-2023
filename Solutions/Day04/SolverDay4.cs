namespace AoC_2023.Solutions.Day04;

public class SolverDay4 : Solver
{
    private readonly InputService _inputService;
    public SolverDay4(InputService inputService)
    {
        _inputService = inputService;
    }

    public override int SolvePartOne()
    {
        var input = GetInput();
        var totalPoints = 0;
        foreach (var line in input)
        {
            var matches = GetNumberMatches(line);

            if (matches > 0)
            {
                totalPoints += (int)Math.Pow(2, matches - 1);
            }
        }

        return totalPoints;
    }

    public static int GetGameNumber(string line)
    {
        return int.Parse(line.Split(':').First().Split(" ").Last());
    }
    public static List<int> GetWinningNumbers(string line)
    {
        return line.Split(":").Last().Split("|").First().Trim().Split(" ").Where(e => e.Trim() != "").Select(e => int.Parse(e)).ToList();
    }

    public static List<int> GetMyNumbers(string line)
    {
        return line.Split(":").Last().Split("|").Last().Trim().Split(" ").Where(e => e.Trim() != "").Select(e => int.Parse(e)).ToList();
    }

    public override int SolvePartTwo()
    {
        var input = GetInput();
        var nbrInstancesOfCards = Enumerable.Repeat(1, input.Length).ToList();
        var gameNbr = 1;

        foreach (var line in input)
        {
            var nbrMatches = GetNumberMatches(line);
            var idx = 1;

            while (idx <= nbrMatches && idx + gameNbr - 1 < nbrInstancesOfCards.Count)
            {
                nbrInstancesOfCards[gameNbr - 1 + idx] += nbrInstancesOfCards[gameNbr - 1];
                idx++;
            }
            gameNbr++;
        }
        return nbrInstancesOfCards.Sum();
    }

    public static int GetNumberMatches(string line)
    {
        var winningNumbers = GetWinningNumbers(line);
        var myNumbers = GetMyNumbers(line);

        var matches = myNumbers.Where(nbr => winningNumbers.Contains(nbr)).Count();
        return matches;
    }

    public string[] GetInput()
    {
        return _inputService.GetInput();
    }
}

