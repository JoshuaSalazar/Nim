﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class HumanPlayer : IPlayer
    {
        public HumanPlayer(){
        }
        public bool makeMove(GameManager game)
        {
            bool moveMade = false;
            do
            {
                game.printBoard();
                Console.WriteLine("Choose number of row");
                Console.WriteLine("(0) for First Row, (1) for Second Row, (2) for Third Row");
                int row = int.Parse(Console.ReadLine());

                Console.WriteLine("How many pieces do you want to take away?");
                int num = int.Parse(Console.ReadLine());
                if (game.makeMove(row, num))
                {
                    moveMade = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input, try again");
                }
            } while (!moveMade);
            return true;
        }
    }
}
