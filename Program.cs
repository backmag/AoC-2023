using AoC_2023.Solutions.Day1;
using AoC_2023.Solutions.Day2;
using AoC_2023.Solutions.Day3;
using AoC_2023.Solutions.Day4;
using AoC_2023.Solutions.Day5;

namespace AoC_2023
{
    class Program
    {

        static string GetInputPathForDay(int day)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string inputPath = projectDirectory + $"\\Solutions\\Day{day}\\input.txt";
            return inputPath;
        }
        public static void Main(string[] args)
        {
            int day = 5;

            var inputPath = GetInputPathForDay(day);

            var inputService = new InputService(inputPath);

            var solver = FetchSolverByDay(day, inputService);

            if (solver != null)
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                var firstSolution = solver.SolvePartOne();
                stopwatch.Stop();
                Console.WriteLine($"Day {day}: Solution for part one is {firstSolution}. It took {stopwatch.ElapsedMilliseconds} ms.");
                stopwatch.Restart();
                var secondSolution = solver.SolvePartTwo();
                stopwatch.Stop();
                Console.WriteLine($"Day {day}: Solution for part two is {secondSolution}. It took {stopwatch.ElapsedMilliseconds} ms.");
            }
            else
            {
                Console.WriteLine($"No solver for day {day}.");
            }
        }

        private static Solver? FetchSolverByDay(int day, InputService inputService)
        {
            return day switch
            {
                1 => new SolverDay1(inputService),
                2 => new SolverDay2(inputService),
                3 => new SolverDay3(inputService),
                4 => new SolverDay4(inputService),
                5 => new SolverDay5(inputService),
                _ => null,
            };
        }
    }
}
