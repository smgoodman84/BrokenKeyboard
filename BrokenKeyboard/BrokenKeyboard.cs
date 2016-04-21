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
            return bk.GetMaximumDistance();
        }

        private List<char> keyboardChars;

        private int startIndex;
        private int endIndex;
        private int Distance => endIndex - startIndex;
        
        private readonly int workingKeyCount;
        private readonly string textToType;

        private BrokenKeyboard(int workingKeyCount, string textToType)
        {
            this.workingKeyCount = workingKeyCount;
            this.textToType = textToType;
        }

        public int GetMaximumDistance()
        {
            Initialise();

            AdvanceEnd();

            var maximumDistance = Distance;

            while (Advance())
            {
                if (Distance > maximumDistance)
                {
                    maximumDistance = Distance;
                }
            }

            return maximumDistance;
        }

        private void Initialise()
        {
            startIndex = 0;
            endIndex = 0;
            keyboardChars = new List<char>();
        }

        private bool Advance()
        {
            if (!AdvanceStart())
            {
                return false;
            }

            AdvanceEnd();

            return true;
        }

        private bool AdvanceStart()
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

            return true;
        }

        private void AdvanceEnd()
        {
            endIndex = startIndex;

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
        }
    }
}