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
            Console.WriteLine("Choose:  (1) for Player vs Computer or (2) for Computer vs Computer");
            string selectMode = Console.ReadLine();

            if (selectMode == "1")
            {
                PlayerInput();
                return true;
            }
            else if (selectMode == "2")
            {
                ComputerVsComputer();
                return true;
            }
            return false;
        }

        public void PlayerInput()
        {
            game.newGame();

            while (!game.isGameOver())
            {
                game.printBoard();
                Console.WriteLine("Choose number of row");
                Console.WriteLine("(1) for First Row, (2) for Second Row, (3) for Third Row");
                string rowNumber = Console.ReadLine();
                int row = int.Parse(rowNumber);

                Console.WriteLine("How many pieces do you want to take away?");
                string takePieces = Console.ReadLine();
                int num = int.Parse(takePieces);

                if (game.makeMove(row, num)){
                    game.computerMove();
                }else{
                    Console.WriteLine("Invalid Input, try again");
                }
            }
        }

        public void ComputerVsComputer()
        {
            Console.WriteLine("How many types do the Computers play?");
            string numGames = Console.ReadLine();

            int num = int.Parse(numGames);
            game.newGame();
            for (int i = 0; i < num; i++)
            {
                while (!game.isGameOver())
                {
                    game.computerMove();
                }
                Console.WriteLine("Game #"+i+" complete.");
            }
        }
    }
}