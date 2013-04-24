using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    public class UserInput
    {
        private GameManager game;
        public UserInput()
        {
            game = new GameManager();
        }

        public bool Begin()
        {
            bool quit = false;
            do
            {
                Console.WriteLine("Choose:  (1) for Player vs Computer or (2) for Computer vs Computer");
                string selectMode = Console.ReadLine();

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
            HumanPlayer player1 = new HumanPlayer();
            ComputerPlayer computerPlayer = new ComputerPlayer();
            game.newGame();
            Random randgen = new Random();
            int rand = randgen.Next(0, 2);
            bool isPlayerTurn = rand % 2 == 0;
            if (isPlayerTurn){
                Console.WriteLine("Congradulations, you get to go first!");
            }else{
                Console.WriteLine("Congradulations, you get to go first!");
            }
            while (!game.gameIsOver())
            {
                if (isPlayerTurn)
                {
                    player1.makeMove(game);
                }
                else
                {
                    computerPlayer.makeMove(game);
                }
                isPlayerTurn = !isPlayerTurn;
                if (game.gameIsOver() && isPlayerTurn)
                {
                    Console.WriteLine("You win!");
                }
                else if (game.gameIsOver())
                {
                    Console.WriteLine("You lose");
                }
            }
        }

        private void playerTurn()
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
        }

        public void ComputerVsComputer()
        {
            DateTime dt = DateTime.Now;

            ComputerPlayer cpu = new ComputerPlayer();
            Console.WriteLine("How many times do you want the Computers to play?");
            string numGames = Console.ReadLine();

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
            Console.WriteLine(ts);
        }
    }
}