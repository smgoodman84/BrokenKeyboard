using System;

namespace BrokenKeyboardCommandLine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            foreach (var problem in Parser.Parse(Console.In))
            {
                Console.WriteLine(BrokenKeyboard.BrokenKeyboard.Solve(problem));
            }
        }
    }
}
