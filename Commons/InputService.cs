using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023.Commons
{
    public class InputService
    {
        private readonly string InputPath = "";
        private readonly string[] InputList = Array.Empty<string>();

        public InputService(string inputPath)
        {
            InputPath = inputPath;
        }
        public InputService(string[] inputList)
        {
            InputList = inputList;
        }

        public string[] GetInput()
        {
            if (InputPath != "")
            {
                var input = File.ReadAllLines(InputPath);
                return input;
            }
            else
            {
                return InputList;
            }
        }
        public static string[] SplitToArray(string str)
        {
            return str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }
    }
}
