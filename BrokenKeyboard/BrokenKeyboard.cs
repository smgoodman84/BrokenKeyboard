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
            var maxDistance = 0;
            for (var startIndex = 0; startIndex < textToType.Length; startIndex++)
            {

                var distance = 0;
                var charactersOnKeyboard = new List<char>(workingKeyCount);

                for (var index = startIndex; index < textToType.Length; index++)
                {
                    var c = textToType[index];
                    if (charactersOnKeyboard.Contains(c))
                    {
                        distance += 1;
                    }
                    else
                    {
                        if (charactersOnKeyboard.Count < workingKeyCount)
                        {
                            charactersOnKeyboard.Add(c);
                            distance += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }

            return maxDistance;
        }
    }
}