namespace AoC_2023.Solutions.Day13
{
    public class Frame
    {
        private string[] _frame;
        public int Rows;
        public int Columns;
        public string Rotation;

        public Frame(string[] chars)
        {
            _frame = chars;
            Rows = _frame.Length;
            Columns = _frame[0].Length;
            Rotation = "standard";
        }

        public void Print()
        {
            foreach (var row in _frame)
            {
                Console.WriteLine(row);
            }
        }

        public string[] GetFrame()
        {
            return _frame;
        }

        // Returns the n'th row which is mirrored between n and n-1. Returns -1 if no mirror is found.
        public int FindMirrorRow(int startingRow = 1)
        {
            for (int currentRow = startingRow; currentRow < _frame.Length; currentRow++)
            {
                int expansion = 1;
                var upperRow = _frame[currentRow - expansion];
                var lowerRow = _frame[currentRow + expansion - 1];
                while (currentRow - expansion > 0 && currentRow + expansion < _frame.Length && upperRow.Equals(lowerRow))
                {
                    expansion++;
                    lowerRow = _frame[currentRow + expansion - 1];
                    upperRow = _frame[currentRow - expansion];
                }
                if ((currentRow - expansion == 0 || currentRow + expansion == _frame.Length) && upperRow.Equals(lowerRow))
                {
                    // Found a mirror at the current row.
                    return currentRow;
                }
            }
            return -1;
        }

        public void ChangeSymbol(int row, int col)
        {
            var newRow = _frame[row].ToCharArray();
            newRow[col] = newRow[col] == '#' ? '.' : '#';
            _frame[row] = new string(newRow);
        }

        public void Flip()
        {
            string[] newFrame = new string[_frame[0].Length];

            for (int col = 0; col < _frame[0].Length; col++)
            {
                var tempRow = "";
                for (int row = 0; row < _frame.Length; row++)
                {
                    tempRow = tempRow + _frame[row][col];
                }
                newFrame[col] = tempRow;
            }
            _frame = newFrame;
            Rows = _frame.Length;
            Columns = _frame[0].Length;
            Rotation = Rotation == "standard" ? "flipped" : "standard";
        }
    }
}
