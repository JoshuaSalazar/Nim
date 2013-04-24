using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    public class UserInput
    {
        public delegate void writerDelegate(string input);
        public writerDelegate writer;

        public delegate String readerDelegate();
        public readerDelegate readLine;

        private GameManager game;
        public UserInput(writerDelegate newWriter, readerDelegate newReader)
        {
            writer = new writerDelegate(newWriter);
            readLine = new readerDelegate(newReader);
            game = new GameManager(writer);
        }

        public bool Begin()
        {
            bool quit = false;
            do
            {
                writer("Choose:  (1) for Player vs Computer or (2) for Computer vs Computer");
                string selectMode = readLine();

                if (selectMode == "1")
                {
                    PlayerInput();
                }
                else if (selectMode == "2")
                {
                    ComputerVsComputer();
                }
                else
                {
                    quit = true;
                }

            } while (!quit);

            return false;
        }

        public void PlayerInput()
        {
            HumanPlayer p1 = new HumanPlayer(writer, readLine);
            ComputerPlayer p2 = new ComputerPlayer();
            game.newGame();
            Random randgen = new Random();
            int rand = randgen.Next(0, 2);
            bool isPlayerTurn = rand % 2 == 0;
            if (isPlayerTurn){
                writer("Congradulations, you get to go first!");
            }else{
                writer("The computer goes first.");
            }
            while (!game.gameIsOver())
            {
                if (isPlayerTurn)
                {
                    p1.makeMove(game);
                }
                else
                {
                    p2.makeMove(game);
                }
                isPlayerTurn = !isPlayerTurn;
                if (game.gameIsOver() && isPlayerTurn)
                {
                    writer("You win!");
                }
                else if (game.gameIsOver())
                {
                    writer("You lose");
                }
            }
        }

        private void playerTurn()
        {
            bool moveMade = false;
            while (!moveMade)
            {
                game.printBoard();
                writer("Choose number of row");
                writer("(0) for First Row, (1) for Second Row, (2) for Third Row");
                string rowNumber = readLine();
                int row = int.Parse(rowNumber);

                writer("How many pieces do you want to take away?");
                string takePieces = readLine();
                int num = int.Parse(takePieces);
                if (!game.makeMove(row, num))
                {
                    writer("Invalid Input, try again");
                }
                else
                {
                    moveMade = true;
                }
            }
        }

        public void ComputerVsComputer()
        {
            DateTime dt = DateTime.Now;

            ComputerPlayer cpu = new ComputerPlayer();
            writer("How many times do you want the Computers to play?");
            string numGames = readLine();

            int num = int.Parse(numGames);
            game.newGame();
            for (int i = 0; i < num; i++)
            {
                while (!game.gameIsOver())
                {
                    cpu.makeMove(game);
                }
                game.newGame();
            }

            TimeSpan ts = DateTime.Now - dt;
            writer(ts.ToString());
        }
    }
}