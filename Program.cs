using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInput game = new UserInput(Console.WriteLine, Console.ReadLine);
            game.Begin();
        }
    }
}
