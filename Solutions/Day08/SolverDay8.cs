using System.Numerics;

namespace AoC_2023.Solutions.Day08
{
    public class SolverDay8 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay8(InputService inputService)
        {
            _inputService = inputService;
        }

        public override int SolvePartOne()
        {
            var input = GetInput();
            var directionHandler = new DirectionHandler(input[0]);
            var directionMap = CreateDirectionMap(input[2..]);

            var currentValue = "AAA";

            while (currentValue != "ZZZ")
            {
                currentValue = directionMap[currentValue][directionHandler.GetNextDirection()];
            }
            return (int)directionHandler.GetSteps();
        }
        public Dictionary<string, List<string>> CreateDirectionMap(string[] input)
        {
            var retDict = new Dictionary<string, List<string>>();

            foreach (var str in input)
            {
                var name = str.Split("=").First().Trim();
                var options = str.Replace('(', ' ').Replace(')', ' ').Split("=").Last().Trim().Split(',');
                retDict.Add(name, new List<string> { options[0].Trim(), options[1].Trim() });
            }
            return retDict;
        }

        public override int SolvePartTwo()
        {
            var input = GetInput();
            var directionMap = CreateDirectionMap(input[2..]);

            List<BigInteger> steps = new List<BigInteger>();
            var nodes = directionMap.Keys.Where(e => e.Last() == 'A').ToList();
            foreach (var node in nodes)
            {
                var directionHandler = new DirectionHandler2(input[0]);
                steps.Add(GetStepsInCyclus(node, directionMap, directionHandler));
            }
            var result = FindLeastCommonMultipleOfList(steps);
            Console.WriteLine("Total length: " + result);
            return (int)steps.Aggregate((acc, x) => acc * x);
        }
        public BigInteger FindLeastCommonMultipleOfList(List<BigInteger> nbrs)
        {
            BigInteger lcm = nbrs[0];
            int idx = 1;
            while (idx < nbrs.Count())
            {
                var t = LeastCommonMultiple(lcm, nbrs[idx]);
                Console.WriteLine($"LCM of {lcm} and {nbrs[idx]}: {t}.");
                lcm = LeastCommonMultiple(lcm, nbrs[idx]);
                idx++;
            }
            return lcm;
        }
        public BigInteger LeastCommonMultiple(BigInteger a, BigInteger b)
        {
            return a * b / (GreatestCommonDivisor(a, b));
        }

        public BigInteger GreatestCommonDivisor(BigInteger a, BigInteger b)
        {
            if (b == BigInteger.Zero) return a;
            return GreatestCommonDivisor(b, a % b);

        }
        public BigInteger GetStepsInCyclus(string node, Dictionary<string, List<string>> map, DirectionHandler2 dir)
        {
            BigInteger steps = BigInteger.Zero;
            var currentNode = node;
            while (currentNode.Last() != 'Z')
            {
                currentNode = map[currentNode][dir.GetNextDirection()];
                steps++;
            }
            Console.WriteLine($"Found cyclus length for starting node {node}: {steps}.");
            return steps;
        }
        /*

        int nodesEndingInZCount = 0;
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        int logInterval = 100000000; 

        while ((nodesEndingInZCount = nodes.Count(e => e.Last() == 'Z')) != nodeCount)
        {
            var nextDirection = directionHandler.GetNextDirection();
            if (steps % logInterval == 0)
            {
                stopwatch.Stop();

                Console.WriteLine($"On step {steps} and counting...");
                Console.WriteLine($"Current nodes have {nodesEndingInZCount} nodes ending in Z.");
                Console.WriteLine($"Time for interval: {(stopwatch.ElapsedMilliseconds / 1000)} s.");
                foreach (var node in nodes)
                {
                    Console.WriteLine(node);
                }
                stopwatch.Restart();
            }
            for (int i = 0; i < nodeCount; i++)
            {
                nodes[i] = directionMap[nodes[i]][nextDirection];
            }
            steps++;
        }
        Console.WriteLine("Steps: " + steps);
        */



        public string[] GetInput()
        {
            return _inputService.GetInput();
        }

        class DirectionHandler
        {
            private string Directions;
            private BigInteger StepCounter;
            public DirectionHandler(string input)
            {
                Directions = input;
            }
            public BigInteger GetSteps()
            {
                return StepCounter;
            }
            public int GetNextDirection()
            {
                var idx = StepCounter % Directions.Length;
                var direction = Directions[(int)idx];
                var retVal = 0;
                if (direction == 'R')
                {
                    retVal = 1;
                }
                StepCounter++;
                return retVal;
            }
        }
        public class DirectionHandler2
        {
            private string Directions;
            private int currentIdx;
            public DirectionHandler2(string input)
            {
                Directions = input;
            }
            public int GetNextDirection()
            {
                var direction = Directions[currentIdx];

                var retVal = 0;
                if (direction == 'R')
                {
                    retVal = 1;
                }
                currentIdx++;
                if (currentIdx == Directions.Length)
                {
                    currentIdx = 0;
                }
                return retVal;
            }
        }
    }
}