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
                int row = promptForInt("(0) for First Row, (1) for Second Row, (2) for Third Row");
                int num = promptForInt("How many pieces do you want to take away?");
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
        private int promptForInt(String prompt)
        {
            bool success = false;
            int userInput = 0;
            do{
                writer(prompt);
                int.TryParse(readLine(), out userInput);
                if (!success){
                    writer("That's not a number, try again.");
                }
            }while (!success);
            return userInput;
        }
    }
}
