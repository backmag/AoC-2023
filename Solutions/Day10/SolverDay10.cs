
using System.ComponentModel.Design;
using System.Reflection;
using System.Xml;

namespace AoC_2023.Solutions.Day10
{
    public class SolverDay10 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay10(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            var input = GetInput();

            var (startX, startY) = FindStartCoordinates(input);
            var walker = new PipeWalker(input, startX, startY, printProgress: false);

            walker.TakeStep();
            bool atStartPos = false;

            while (!atStartPos)
            {
                walker.TakeStep();
                var (newX, newY) = walker.GetCurrentTile();
                if (newX == startX && newY == startY)
                {
                    atStartPos = true;
                }
            }
            return (BigInteger)(walker.GetNbrSteps() / 2);
        }


        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();

            var (startX, startY) = FindStartCoordinates(input);
            var walker = new PipeWalker(input, startX, startY, printProgress: false);

            walker.TakeStep();
            bool atStartPos = false;

            var pathTiles = new List<Tuple<int, int>>();
            pathTiles.Add(Tuple.Create(startX, startY));
            while (!atStartPos)
            {
                walker.TakeStep();
                var (newX, newY) = walker.GetCurrentTile();
                pathTiles.Add(new Tuple<int, int>(newX, newY));
                if (newX == startX && newY == startY)
                {
                    atStartPos = true;
                }
            }
            walker.ResetToStart();
            var currentCenterTiles = walker.GetInitialCenterTiles(pathTiles);
            Console.WriteLine($"Nbr starting tiles: {currentCenterTiles.Count()}");
            bool isExpanding = true;

            while (isExpanding)
            {
                var newCenterTiles = walker.ExpandAroundTiles(currentCenterTiles, pathTiles);
                if (newCenterTiles.Count() == currentCenterTiles.Count())
                {
                    isExpanding = false;
                }
                else
                {
                    currentCenterTiles = newCenterTiles;
                    Console.WriteLine($"New expansion. Number of tiles: {currentCenterTiles.Count()}");
                }
            }
            var potentialSolutions = new List<int> {
                currentCenterTiles.Count(),
                input.Length * input[0].Length - pathTiles.Count() - currentCenterTiles.Count()
            };
            potentialSolutions.Sort();
            Console.WriteLine($"Potential solutions: {potentialSolutions.First()} or {potentialSolutions.Last()}");
            return (BigInteger)potentialSolutions.First();
        }

        /* 5412 Too high
         * 808 Too high
         * 521 Too low! 
         * 530 WRONG 
         */

        public static Tuple<int, int> FindStartCoordinates(string[] input)
        {
            var query = input.Select(
                (str, index) => new { Index = index, CharIndex = str.IndexOf('S') }).
                FirstOrDefault(e => e.CharIndex != -1);
            return new Tuple<int, int>(query.CharIndex, query.Index);
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }

    public class PipeWalker
    {
        private const char HORIZONTAL_PIPE = '-';
        private const char VERTICAL_PIPE = '|';
        private const char NORTH_EAST_PIPE = 'L';
        private const char NORTH_WEST_PIPE = 'J';
        private const char SOUTH_WEST_PIPE = '7';
        private const char SOUTH_EAST_PIPE = 'F';
        private const char STARTING_POSITION = 'S';

        private readonly string[] PipeMap;
        private int StartX;
        private int StartY;
        private int CurrentX;
        private int CurrentY;
        private int PreviousX;
        private int PreviousY;
        private char Direction;
        private bool PrintProgress;
        private int NbrSteps;

        public PipeWalker(string[] map, int startX, int startY, char direction = 'R', bool printProgress = false)
        {
            PipeMap = map;
            CurrentX = startX;
            CurrentY = startY;
            PrintProgress = printProgress;
            Direction = direction;
            StartX = startX;
            StartY = startY;
        }

        public void ResetToStart()
        {
            CurrentX = StartX;
            CurrentY = StartY;
            PreviousX = 0;
            PreviousY = 0;
            NbrSteps = 0;
        }

        public List<Tuple<int, int>> ExpandAroundTiles(List<Tuple<int, int>> tilesToExpand, List<Tuple<int, int>> pathTiles)
        {
            var updatedTiles = tilesToExpand.Select(e => Tuple.Create(e.Item1, e.Item2)).ToList();

            foreach (var tile in tilesToExpand)
            {
                var adjacentTiles = GetAdjacentTiles(tile);
                foreach (var adjacentTile in adjacentTiles)
                {
                    if (!pathTiles.Where(e => e.Item1 == adjacentTile.Item1 && e.Item2 == adjacentTile.Item2).Any() &&
                        !updatedTiles.Where(e => e.Item1 == adjacentTile.Item1 && e.Item2 == adjacentTile.Item2).Any() &&
                        adjacentTile.Item1 > 0 &&
                        adjacentTile.Item1 < PipeMap[0].Length &&
                        adjacentTile.Item2 > 0 &&
                        adjacentTile.Item2 < PipeMap.Length)
                    {
                        updatedTiles.Add(adjacentTile);
                    }
                }
            }
            return updatedTiles;
        }

        public List<Tuple<int, int>> GetAdjacentTiles(Tuple<int, int> tile)
        {
            var adjacentTiles = new List<Tuple<int, int>>();
            foreach (var x in Enumerable.Range(-1, 3))
            {
                foreach (var y in Enumerable.Range(-1, 3))
                {
                    adjacentTiles.Add(Tuple.Create(tile.Item1 + x, tile.Item2 + y));
                }
            }
            return adjacentTiles;
        }

        public List<Tuple<int, int>> GetInitialCenterTiles(List<Tuple<int, int>> pathTiles)
        {
            var initialTiles = new List<Tuple<int, int>>();

            TakeStep();

            while (!IsAtStart())
            {
                var tileCandidate = GetTileToDirection();

                if (!initialTiles.Where(e => e.Item1 == tileCandidate.Item1 && e.Item2 == tileCandidate.Item2).Any() &&
                     !pathTiles.Where(e => e.Item1 == tileCandidate.Item1 && e.Item2 == tileCandidate.Item2).Any() &&
                     tileCandidate.Item1 > 0 &&
                     tileCandidate.Item1 < PipeMap[0].Length &&
                     tileCandidate.Item2 > 0 &&
                     tileCandidate.Item2 < PipeMap.Length)
                {
                    initialTiles.Add(tileCandidate);
                }
                TakeStep();
            }
            return initialTiles;
        }

        public bool IsAtStart()
        {
            return CurrentX == StartX && CurrentY == StartY;
        }
        private Tuple<int, int> GetTileToDirection()
        {
            var (nextX, nextY) = GetNextTile();
            if (nextX == CurrentX)
            {
                // Moving vertically
                if (nextY < CurrentY)
                {
                    if (Direction == 'R')
                    {
                        return Tuple.Create(CurrentX - 1, CurrentY);
                    }
                    else
                    {
                        return Tuple.Create(CurrentX + 1, CurrentY);
                    }
                }
                else
                {
                    if (Direction == 'R')
                    {
                        return Tuple.Create(CurrentX + 1, CurrentY);
                    }
                    else
                    {
                        return Tuple.Create(CurrentX - 1, CurrentY);
                    }
                }
            }
            else
            {
                // Moving horizontally
                if (nextX < CurrentX)
                {
                    if (Direction == 'R')
                    {
                        return Tuple.Create(CurrentX, CurrentY + 1);
                    }
                    else
                    {
                        return Tuple.Create(CurrentX, CurrentY - 1);
                    }
                }
                else
                {
                    if (Direction == 'R')
                    {
                        return Tuple.Create(CurrentX, CurrentY - 1);
                    }
                    else
                    {
                        return Tuple.Create(CurrentX, CurrentY + 1);
                    }

                }
            }
        }


        public void TakeStep()
        {
            var (newX, newY) = GetNextTile();
            PreviousX = CurrentX;
            PreviousY = CurrentY;
            CurrentX = newX;
            CurrentY = newY;
            NbrSteps++;
            if (PrintProgress)
            {
                PrintPosition(3);
            }
        }

        public int GetNbrSteps()
        {
            return NbrSteps;
        }

        public Tuple<int, int> GetCurrentTile()
        {
            return new Tuple<int, int>(CurrentX, CurrentY);
        }


        public void PrintPosition(int windowSize)
        {
            var startPrintY = Math.Max(0, CurrentY - windowSize);
            var startPrintX = Math.Max(0, CurrentX - windowSize);
            var stopPrintY = Math.Min(PipeMap.Length, CurrentY + windowSize + 1);
            var stopPrintX = Math.Min(PipeMap[0].Length, CurrentX + windowSize + 1);

            Console.WriteLine("------------------------------------------------------");
            for (int y = startPrintY; y < stopPrintY; y++)
            {
                var printLine = "";
                for (int x = startPrintX; x < stopPrintX; x++)
                {
                    if (x == CurrentX && y == CurrentY)
                    {
                        printLine += 'X';
                    }
                    else
                    {
                        printLine += PipeMap[y][x];
                    }
                }
                Console.WriteLine(printLine);
            }
        }

        private Tuple<int, int> GetNextTile()
        {
            var validTiles = new List<Tuple<int, int>>();
            switch (PipeMap[CurrentY][CurrentX])
            {
                case HORIZONTAL_PIPE:
                    if (PreviousX == (CurrentX - 1))
                    {
                        return new Tuple<int, int>(CurrentX + 1, CurrentY);
                    }
                    else
                    {
                        return new Tuple<int, int>(CurrentX - 1, CurrentY);
                    }
                case VERTICAL_PIPE:
                    if (PreviousY == (CurrentY - 1))
                    {
                        return new Tuple<int, int>(CurrentX, CurrentY + 1);
                    }
                    else
                    {
                        return new Tuple<int, int>(CurrentX, CurrentY - 1);
                    }
                case NORTH_EAST_PIPE:
                    if (PreviousY == (CurrentY - 1))
                    {
                        return new Tuple<int, int>(CurrentX + 1, CurrentY);
                    }
                    else
                    {
                        return new Tuple<int, int>(CurrentX, CurrentY - 1);
                    }
                case NORTH_WEST_PIPE:
                    if (PreviousY == (CurrentY - 1))
                    {
                        return new Tuple<int, int>(CurrentX - 1, CurrentY);
                    }
                    else
                    {
                        return new Tuple<int, int>(CurrentX, CurrentY - 1);
                    }
                case SOUTH_WEST_PIPE:
                    if (PreviousY == (CurrentY + 1))
                    {
                        return new Tuple<int, int>(CurrentX - 1, CurrentY);
                    }
                    else
                    {
                        return new Tuple<int, int>(CurrentX, CurrentY + 1);
                    }
                case SOUTH_EAST_PIPE:
                    if (PreviousY == (CurrentY + 1))
                    {
                        return new Tuple<int, int>(CurrentX + 1, CurrentY);
                    }
                    else
                    {
                        return new Tuple<int, int>(CurrentX, CurrentY + 1);
                    }

                case STARTING_POSITION:
                    if (CurrentY > 0)
                    {
                        var tileAbove = PipeMap[CurrentY - 1][CurrentX];
                        if (tileAbove == VERTICAL_PIPE || tileAbove == SOUTH_WEST_PIPE || tileAbove == SOUTH_EAST_PIPE)
                        { validTiles.Add(new Tuple<int, int>(CurrentX, CurrentY - 1)); }
                    }
                    if (CurrentY < PipeMap.Length)
                    {
                        var tileBelow = PipeMap[CurrentY + 1][CurrentX];
                        if (tileBelow == VERTICAL_PIPE || tileBelow == NORTH_WEST_PIPE || tileBelow == NORTH_EAST_PIPE)
                        { validTiles.Add(new Tuple<int, int>(CurrentX, CurrentY + 1)); }
                    }
                    if (CurrentX > 0)
                    {
                        var tileToLeft = PipeMap[CurrentY][CurrentX - 1];
                        if (tileToLeft == HORIZONTAL_PIPE || tileToLeft == NORTH_EAST_PIPE || tileToLeft == SOUTH_EAST_PIPE)
                        { validTiles.Add(new Tuple<int, int>(CurrentX - 1, CurrentY)); }
                    }
                    if (CurrentX < PipeMap[0].Length)
                    {
                        var tileToRight = PipeMap[CurrentY][CurrentX + 1];
                        if (tileToRight == HORIZONTAL_PIPE || tileToRight == NORTH_WEST_PIPE || tileToRight == SOUTH_WEST_PIPE)
                        { validTiles.Add(new Tuple<int, int>(CurrentX + 1, CurrentY)); }
                    }
                    break;
            }
            if (Direction == 'R')
            {
                return validTiles[1];
            }
            return validTiles[0];
        }
    }
}
