using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class HumanPlayer : IPlayer
    {
        public UserInput.writerDelegate writer;
        public UserInput.readerDelegate readLine;
        public HumanPlayer(UserInput.writerDelegate newWriter, UserInput.readerDelegate newReader){
            writer = newWriter;
            readLine = newReader;
        }
        public bool makeMove(GameManager game)
        {
            bool moveMade = false;
            do
            {
                game.printBoard();
                writer("Choose number of row");
                writer("(0) for First Row, (1) for Second Row, (2) for Third Row");
                int row = int.Parse(readLine());

                writer("How many pieces do you want to take away?");
                int num = int.Parse(readLine());
                if (game.makeMove(row, num))
                {
                    moveMade = true;
                }
                else
                {
                    writer("Invalid Input, try again");
                }
            } while (!moveMade);
            return true;
        }
    }
}
