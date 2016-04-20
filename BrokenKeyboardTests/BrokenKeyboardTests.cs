using System;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Compatibility;

namespace BrokenKeyboardTests
{
    [TestFixture]
    public class BrokenKeyboardTests
    {
        [Test]
        [TestCase(5, "This can't be solved by brute force.", 7)]
        [TestCase(1, "Mississippi", 2)]
        public void ExampleSolutions(int workingKeyCount, string textToType, int expectedResult)
        {
            var actualResult = BrokenKeyboard.BrokenKeyboard.Solve(workingKeyCount, textToType);
            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void RepeatedChars()
        {
            var timer = new Stopwatch();

            timer.Start();
            var repetitionCount = 100000;
            var textToType = new string('a', repetitionCount);
            var actualResult = BrokenKeyboard.BrokenKeyboard.Solve(1, textToType);
            actualResult.Should().Be(repetitionCount);
            timer.Stop();

            var duration = timer.Elapsed;

            Console.WriteLine("Elapsed: {0}", duration);
        }
    }
}
