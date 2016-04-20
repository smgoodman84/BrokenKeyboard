using System.Collections.Generic;

namespace BrokenKeyboard
{
    public class BrokenKeyboard
    {
        public static int Solve(BrokenKeyboardProblem problem)
        {
            return Solve(problem.WorkingKeyCount, problem.TextToType);
        }

        public static int Solve(int workingKeyCount, string textToType)
        {
            var bk = new BrokenKeyboard(workingKeyCount, textToType);
            bk.FindSolution();
            return bk.MaximumDistance;
        }

        private readonly int workingKeyCount;
        private readonly string textToType;

        private BrokenKeyboard(int workingKeyCount, string textToType)
        {
            this.workingKeyCount = workingKeyCount;
            this.textToType = textToType;
            MaximumDistance = 0;
        }

        public int MaximumDistance { get; private set; }

        private int startIndex;
        private int endIndex;
        private List<char> keyboardChars;

        private int Distance => endIndex - startIndex;

        private void FindSolution()
        {
            startIndex = 0;
            endIndex = 0;
            keyboardChars = new List<char>();

            // Advance endIndex as far as possible
            while (endIndex < textToType.Length)
            {
                var c = textToType[endIndex];
                if (keyboardChars.Contains(c))
                {
                    endIndex += 1;
                }
                else
                {
                    if (keyboardChars.Count < workingKeyCount)
                    {
                        keyboardChars.Add(c);
                        endIndex += 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            MaximumDistance = Distance;

            while (Advance())
            {
                if (Distance > MaximumDistance)
                {
                    MaximumDistance = Distance;
                }
            }
        }

        private bool Advance()
        {
            var charToRemove = textToType[startIndex];
            keyboardChars.Remove(charToRemove);

            while (textToType[startIndex] == charToRemove)
            {
                startIndex += 1;

                if (startIndex >= textToType.Length)
                {
                    return false;
                }
            }

            for (var i = startIndex; i < endIndex; i++)
            {
                if (textToType[i] == charToRemove)
                {
                    endIndex = i;
                    break;
                }
            }

            if (endIndex < textToType.Length)
            {
                var charToAdd = textToType[endIndex];
                keyboardChars.Add(charToAdd);
                while (endIndex < textToType.Length && keyboardChars.Contains(textToType[endIndex]))
                {
                    endIndex += 1;
                }
            }

            return true;
        }
    }
}