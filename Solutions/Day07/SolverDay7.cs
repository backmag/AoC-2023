namespace AoC_2023.Solutions.Day07
{
    public class SolverDay7 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay7(InputService inputService)
        {
            _inputService = inputService;
        }

        public override int SolvePartOne()
        {
            var input = GetInput();
            var hands = CreateHands(input);
            hands.Sort();
            var idx = 0;
            var result = 0; 
            while (idx < hands.Count)
            {
                result += hands[idx].BidAmount * (idx + 1);
                idx += 1; 
            }
            return result;
        }
        public List<Hand> CreateHands(string[] input)
        {
            List<Hand> result = new List<Hand>();
            foreach (var line in input)
            {
                result.Add(new Hand(line.Split(" ").First(), int.Parse(line.Split(" ").Last())));
            }
            return result;
        }
        public List<JokerHand> CreateJokerHands(string[] input)
        {
            List<JokerHand> result = new List<JokerHand>();
            foreach (var line in input)
            {
                result.Add(new JokerHand(line.Split(" ").First(), int.Parse(line.Split(" ").Last())));
            }
            return result;
        }
        public override int SolvePartTwo()
        {
            var input = GetInput();
            var hands = CreateJokerHands(input);
            hands.Sort();
            var idx = 0;
            var result = 0;
            while (idx < hands.Count)
            {
                result += hands[idx].BidAmount * (idx + 1);
                idx += 1;
            }
            return result;
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
