
namespace AoC_2023.Solutions.Day10
{
    public class SolverDay10 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay10(InputService inputService)
        {
            _inputService = inputService;
        }

        public override int SolvePartOne()
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
            return (int)(walker.GetNbrSteps() / 2);
        }

        public static Tuple<int, int> FindStartCoordinates(string[] input)
        {
            var query = input.Select(
                (str, index) => new { Index = index, CharIndex = str.IndexOf('S') }).
                FirstOrDefault(e => e.CharIndex != -1);
            return new Tuple<int, int>(query.CharIndex, query.Index);
        }


        public override int SolvePartTwo()
        {
            var input = GetInput();

            var (startX, startY) = FindStartCoordinates(input);
            var walker = new PipeWalker(input, startX, startY, printProgress: false);

            walker.TakeStep();
            bool atStartPos = false;

            var pathCoordinates = new List<Tuple<int, int>>();
            while (!atStartPos)
            {
                walker.TakeStep();
                var (newX, newY) = walker.GetCurrentTile();
                pathCoordinates.Add(new Tuple<int, int>(newX, newY));
                if (newX == startX && newY == startY)
                {
                    atStartPos = true;
                }
            }
            /* 
             * Figure out direction of movement, and add all tiles to the right of the walker (which is not in the walker path). 
             * for each of the added tiles, expand in all directions to search for more tiles around them.
             * Further expand one step for all of the new tiles, until no new tiles are found. 
             */

            return 0;
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
        }

        public void TakeStep()
        {
            var (newX, newY) = GetNextTile();
            PreviousX = CurrentX;
            PreviousY = CurrentY;
            CurrentX = newX;
            CurrentY = newY;
            NbrSteps++;
            PrintPosition(3);
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
