using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class GameManager
    {
        public List<State> stateList;
        public int[] rows;
        private CurrentGame game;
        private Random rand;

        public GameManager(){
            rows = new int[3];
            rand = new Random();
            game = new CurrentGame();
            stateList = new List<State>();
            initStateList();
        }

        private void initStateList(){
            for (int t = 0; t < 4; t++){
                for (int m = 0; m < 6; m++){
                    for (int b = 0; b < 8; b++){
                        stateList.Add(new State(t, m, b));
                    }
                }
            }
        }

        public void printBoard()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("Row: 0 Pieces: " + rows[0]);
            Console.WriteLine("Row: 1 Pieces: " + rows[1]);
            Console.WriteLine("Row: 2 Pieces: " + rows[2]);
            Console.WriteLine("===========================");
        }

        public void newGame()
        {
            rows[0] = 3;
            rows[1] = 5;
            rows[2] = 7;
            game = new CurrentGame();
        }

        public bool gameIsOver()
        {
            if (rows[0] == 0 &&
                rows[1] == 0 &&
                rows[2] == 0)
            {
                return true;
            }
            return false;
        }

        public bool makeMove(int row, int num)
        {
            if (noPossibleMove(row, num))
            {
                return false;
            }
            else
            {
                rows[row] -= num;
                moveMade();
            }
            return true;
        }

        private void moveMade()
        {
            game.addState(rows[0], rows[1], rows[2]);
        }

        public void endGame()
        {
            for (int gameRows = 0; gameRows < game.States.Count; gameRows++)
            {
                for (int statesList = 0; statesList < stateList.Count; statesList++)
                {
                    if (statesEqualGame(statesList, gameRows) )
                    {
                        stateList[statesList].addInstance(game.Values[gameRows]);
                    }
                }
            }
        }

        public bool statesEqualGame(int statesLists, int gameRows)
        {
            return (stateList[statesLists].TopRow == game.States[gameRows].TopRow &&
                    stateList[statesLists].MidRow == game.States[gameRows].MidRow &&
                    stateList[statesLists].BotRow == game.States[gameRows].BotRow);
        }


        public bool noPossibleMove(int row, int num)
        {
            return (row >= rows.Length || rows[row] < num || num <= 0);
        }

    }
}