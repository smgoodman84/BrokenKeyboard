using System.Collections.Generic;
using System.IO;
using BrokenKeyboard;

namespace BrokenKeyboardCommandLine
{
    internal class Parser
    {
        public static IEnumerable<BrokenKeyboardProblem> Parse(TextReader sr)
        {
            while (true)
            {
                var workingKeyCount = sr.ReadLine();
                var convertedWorkingKeyCount = int.Parse(workingKeyCount);

                if (convertedWorkingKeyCount == 0)
                {
                    yield break;
                }

                var textToType = sr.ReadLine();

                yield return new BrokenKeyboardProblem()
                {
                    WorkingKeyCount = convertedWorkingKeyCount,
                    TextToType = textToType
                };
            }
        }
    }
}