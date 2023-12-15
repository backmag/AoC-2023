using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace AoC_2023.Solutions.Day11
{
    public class SolverDay11 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay11(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();
            var universeWidth = input[0].Length;
            var universeHeight = input.Length;
            var galaxies = CreateGalaxies(input);

            var expansionFactor = 2;
            var expandedGalaxies = ExpandUniverse(galaxies, universeWidth, universeHeight, expansionFactor);
            var shortestPaths = CalculateShortestPath(expandedGalaxies);
            return shortestPaths.Sum();
        }

        public override BigInteger SolvePartTwo()
        {

            var input = GetInput();
            var universeWidth = input[0].Length;
            var universeHeight = input.Length;
            var galaxies = CreateGalaxies(input);

            var expansionFactor = 1000000;
            var expandedGalaxies = ExpandUniverse(galaxies, universeWidth, universeHeight, expansionFactor);
            var (newWidth, newHeight) = GetNewMetrics(expandedGalaxies);
            var shortestPaths = CalculateShortestPath(expandedGalaxies);
            var totalSum =shortestPaths.Select(e => (BigInteger)e).Aggregate((acc, e) => acc + e);
            Console.WriteLine(totalSum);
            return shortestPaths.Sum();
        }

        public static Tuple<int, int> GetNewMetrics(List<Galaxy> galaxies)
        {
            var height = galaxies.Select(e => e.GetY()).Max();
            var width = galaxies.Select(e => e.GetX()).Max();
            return Tuple.Create(width, height);
        }
        public static void PrintUniverse(List<Galaxy> galaxies, int width, int height)
        {
            Console.WriteLine("------$@€ UNIVERSE  €@$------");
            List<List<char>> printArray = Enumerable.Range(0, height + 1).Select(e => (new String('.', width + 1)).ToList()).ToList();
            foreach (var galaxy in galaxies)
            {
                var x = galaxy.GetX();
                var y = galaxy.GetY();
                printArray[y][x] = '#';
            }

            foreach (var line in printArray)
            {
                Console.WriteLine(String.Join("", line).ToString());
            }
        }

        public List<Galaxy> ExpandUniverse(List<Galaxy> galaxies, int universeWidth, int universeHeight, int expansionFactor)
        {
            var expandedGalaxies = galaxies.Select(e => new Galaxy(e.GetX(), e.GetY())).ToList();
            var emptyRows = FindEmptyRows(galaxies, universeHeight);
            var emptyCols = FindEmptyCols(galaxies, universeWidth);

            var currentRowExpansion = 0;
            var currentColExpansion = 0;


            foreach (var row in emptyRows)
            {
                foreach (var item in expandedGalaxies.Where(e => e.GetY() > (row + currentRowExpansion)))
                {
                    item.SetY(item.GetY() + expansionFactor - 1);
                }
                currentRowExpansion += expansionFactor - 1;
            }
            foreach (var col in emptyCols)
            {
                foreach (var item in expandedGalaxies.Where(e => e.GetX() > (col + currentColExpansion)))
                {
                    item.SetX(item.GetX() + expansionFactor - 1);
                }
                currentColExpansion += expansionFactor - 1;
            }
            return expandedGalaxies;
        }

        public List<int> FindEmptyRows(List<Galaxy> galaxies, int universeHeight)
        {
            var galaxyCols = galaxies.Select(e => e.GetY()).Distinct();
            return Enumerable.Range(0, universeHeight).Where(e => !galaxyCols.Contains(e)).ToList();
        }
        public List<int> FindEmptyCols(List<Galaxy> galaxies, int universeWidth)
        {
            var galaxyRows = galaxies.Select(e => e.GetX()).Distinct();
            return Enumerable.Range(0, universeWidth).Where(e => !galaxyRows.Contains(e)).ToList();
        }
        public List<int> CalculateShortestPath(List<Galaxy> galaxies)
        {
            var shortestPaths = new List<int>();

            for (int i = 0; i < galaxies.Count; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    shortestPaths.Add(galaxies[i].GetDistance(galaxies[j]));
                }
            }
            return shortestPaths;
        }

        public List<Galaxy> CreateGalaxies(string[] input)
        {
            var galaxies = new List<Galaxy>();
            foreach (var (line, rowIndex) in input.Select((v, r) => (v, r)))
            {
                foreach (var (c, colIndex) in line.Select((v, r) => (v, r)))
                {
                    if (c == '#')
                    {
                        galaxies.Add(new Galaxy(colIndex, rowIndex));
                    }
                }
            }
            return galaxies;
        }


        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }

    public class Galaxy
    {
        private int posX;
        private int posY;
        public Galaxy(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public int GetX()
        {
            return posX;
        }
        public int GetY()
        {
            return posY;
        }

        public void SetX(int x)
        {
            posX = x;
        }
        public void SetY(int y)
        {
            posY = y;
        }

        public int GetDistance(Galaxy galaxy)
        {
            return Math.Abs(galaxy.GetX() - this.posX) + Math.Abs(galaxy.GetY() - this.posY);
        }
    }
}
