namespace AoC_2023.Solutions.Day11
{
    public class SolverDay11 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay11(InputService inputService)
        {
            _inputService = inputService;
        }

        public override int SolvePartOne()
        {
            var input = GetInput();
            var universeWidth = input[0].Length;
            var universeHeight = input.Length;
            var galaxies = CreateGalaxies(input);
            var expandedGalaxies = ExpandUniverse(galaxies, universeWidth, universeHeight);
            var shortestPaths = CalculateShortestPath(expandedGalaxies);
            PrintUniverse(galaxies, universeWidth, universeHeight);
            PrintUniverse(expandedGalaxies, universeWidth, universeHeight);

            return shortestPaths.Sum();
        }

        public override int SolvePartTwo()
        {
            var input = GetInput();
            return 0;
        }

        public static void PrintUniverse(List<Galaxy> galaxies, int width, int height)
        {
            var printArray = Enumerable.Range(0, height).Select(e => new String('.', width)).ToList();
            var idx = 0; 
            while(idx < height)
            {

            }
        }

        public List<Galaxy> ExpandUniverse(List<Galaxy> galaxies, int universeWidth, int universeHeight)
        {
            var expandedGalaxies = galaxies.Select(e => new Galaxy(e.GetX(), e.GetY())).ToList();
            var emptyRows = FindEmptyRows(galaxies, universeHeight);
            var emptyCols = FindEmptyCols(galaxies, universeWidth);

            foreach (var row in emptyRows)
            {
                foreach (var item in galaxies.Where(e => e.GetY() > row))
                {
                    item.SetY(item.GetY() + 1);
                }
            }
            foreach (var col in emptyCols)
            {
                foreach (var item in galaxies.Where(e => e.GetX() > col))
                {
                    item.SetX(item.GetX() + 1);
                }
            }
            return galaxies;
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
