using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class HumanPlayer : IPlayer
    {
        private String _name;
        public HumanPlayer(String name){
            _name = name;
        }
        public bool makeMove(GameManager game)
        {
            bool moveMade = false;
            while (!moveMade)
            {
                game.printBoard();
                Console.WriteLine("Choose number of row");
                Console.WriteLine("(0) for First Row, (1) for Second Row, (2) for Third Row");
                string rowNumber = Console.ReadLine();
                int row = int.Parse(rowNumber);

                Console.WriteLine("How many pieces do you want to take away?");
                string takePieces = Console.ReadLine();
                int num = int.Parse(takePieces);
                if (!game.makeMove(row, num))
                {
                    Console.WriteLine("Invalid Input, try again");
                }
                else
                {
                    moveMade = true;
                }
            }
            return true;
        }
    }
}
