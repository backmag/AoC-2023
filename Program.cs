using AoC_2023.Solutions.Day1;
using AoC_2023.Solutions.Day2;
using AoC_2023.Solutions.Day3;
using AoC_2023.Solutions.Day4;
using AoC_2023.Solutions.Day5;
using AoC_2023.Solutions.Day6;
using AoC_2023.Solutions.Day7;
using AoC_2023.Solutions.Day8;
using AoC_2023.Solutions.Day9;
using AoC_2023.Solutions.Day10;
using AoC_2023.Solutions.Day11;
using AoC_2023.Solutions.Day12;
using AoC_2023.Solutions.Day13;
using AoC_2023.Solutions.Day14;
using AoC_2023.Solutions.Day15;


namespace AoC_2023
{
    class Program
    {

        static string GetInputPathForDay(string day)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string inputPath = projectDirectory + $"\\Solutions\\Day{day}\\input.txt";
            return inputPath;
        }
        public static void Main(string[] args)
        {
<<<<<<< HEAD
            string day = "08";
=======
            var day = "07";
>>>>>>> 0a1a966696a9d944349a579e88f6273a959b4fe4

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

        private static Solver? FetchSolverByDay(string day, InputService inputService)
        {
            return day switch
            {
                "01" => new SolverDay1(inputService),
                "02" => new SolverDay2(inputService),
                "03" => new SolverDay3(inputService),
                "04" => new SolverDay4(inputService),
                "05" => new SolverDay5(inputService),
                "06" => new SolverDay6(inputService),
                "07" => new SolverDay7(inputService),
                "08" => new SolverDay8(inputService),
                "09" => new SolverDay9(inputService),
                "10" => new SolverDay10(inputService),
                "11" => new SolverDay11(inputService),
                "12" => new SolverDay12(inputService),
                "13" => new SolverDay13(inputService),
                "14" => new SolverDay14(inputService),
                "15" => new SolverDay15(inputService),
                _ => null,
            };
        }
    }
}
