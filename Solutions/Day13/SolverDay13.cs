namespace AoC_2023.Solutions.Day13
{
    public class SolverDay13 : Solver
    {
        private readonly InputService _inputService;
        public SolverDay13(InputService inputService)
        {
            _inputService = inputService;
        }

        public override BigInteger SolvePartOne()
        {
            string[] input = GetInput();
            Frame[] frames = ParseFrames(input);
            var score = 0;
            foreach (Frame frame in frames)
            {
                var mirrorRow = frame.FindMirrorRow();

                if (mirrorRow == -1)
                {
                    frame.Flip();
                    mirrorRow = frame.FindMirrorRow();
                    score += mirrorRow;
                }
                else
                {
                    score += mirrorRow * 100;
                }
            }
            return score;
        }

        public override BigInteger SolvePartTwo()
        {
            var input = GetInput();
            Frame[] frames = ParseFrames(input);
            var score = 0;
            var currentFrameIdx = 1;

            foreach (Frame frame in frames)
            {
                int mirrorRow = FindSmudgeMirror(frame);
                if (mirrorRow == -1)
                {
                    frame.Flip();
                    mirrorRow = FindSmudgeMirror(frame);
                    if (mirrorRow == -1)
                    {
                        throw new Exception(
                        String.Format("Something is fishy with frame {0} [rotation: {1}]:", currentFrameIdx, frame.Rotation)
                        );
                    }
                    score += mirrorRow;
                }
                else
                {
                    score += mirrorRow * 100;
                }
                currentFrameIdx++;
            }
            return score;
        }

        private int FindSmudgeMirror(Frame frame)
        {
            var standardMirrorRow = frame.FindMirrorRow();
            int row = 0;
            while (row < frame.Rows)
            {
                int col = 0;
                while (col < frame.Columns)
                {
                    frame.ChangeSymbol(row, col);
                    var mirrorRow = frame.FindMirrorRow();
                    if (mirrorRow != -1 && mirrorRow == standardMirrorRow)
                    {
                        // keep searching at higher rows
                        mirrorRow = frame.FindMirrorRow(startingRow: mirrorRow + 1);
                    }
                    if (mirrorRow != -1)
                    {
                        return mirrorRow;
                    }
                    else
                    {
                        // didn't find a mirror, change the symbol back
                        frame.ChangeSymbol(row, col);
                        col++;
                    }
                }
                row++;
            }
            return -1;
        }

        private Frame[] ParseFrames(string[] input)
        {
            List<Frame> frames = [];
            List<string> frameStrings = [];
            foreach (var line in input)
            {
                if (line.Equals(""))
                {
                    frames.Add(new Frame([.. frameStrings]));
                    frameStrings = [];
                }
                else
                {
                    frameStrings.Add(line);
                }
            }
            frames.Add(new Frame([.. frameStrings]));
            return [.. frames];
        }

        public string[] GetInput()
        {
            return _inputService.GetInput();
        }
    }
}
