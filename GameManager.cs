using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class GameManager
    {
        public List<State> stateHistory;
        public int[] rows;
        private CurrentGame game;
        private Random rand;
        public GameManager()
        {
            rows = new int[3];
            rand = new Random();
            game = new CurrentGame();
            stateHistory = new List<State>();
            makeStates();
        }
        private void makeStates()
        {
            for (int t = 0; t < 4; t++)
            {
                for (int m = 0; m < 6; m++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        stateHistory.Add(new State(t, m, b, 0));
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
        public bool isGameOver()
        {
            if (rows[0] == 0 &&
                rows[1] == 0 &&
                rows[2] == 0)
            {
                endGame();
                newGame();
                return true;
            }
            return false;
        }
        public bool makeMove(int row, int num)
        {
            if (row >= rows.Length)
            {
                return false;
            }
            else if (rows[row] < num)
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
        public void moveMade()
        {
            game.addState(rows[0], rows[1], rows[2]);
        }
        public void endGame()
        {
            game.calcValues();
            for (int k = 0; k < game.totalStates; k++)
            {
                for (int i = 0; i < stateHistory.Count; i++)
                {
                    if (stateHistory[i].topRow == game.topRow[k] &&
                        stateHistory[i].midRow == game.midRow[k] &&
                        stateHistory[i].botRow == game.botRow[k])
                    {
                        stateHistory[i].sum += game.values[k];
                        stateHistory[i].num++;
                    }
                }
            }
        }
        public void computerMove()
        {
            int bestMove = -1;
            for (int i = 0; i < stateHistory.Count; i++)
            {
                //if it's possible to get there
                if (stateHistory[i].topRow > rows[0] ||
                    stateHistory[i].midRow > rows[1] ||
                    stateHistory[i].botRow > rows[2])
                {
                    //Can't be done
                    //Console.WriteLine("Found state that can't be done");
                }
                else
                {
                    int numRowsToMove = 0;
                    if (stateHistory[i].topRow < rows[0])
                    {
                        numRowsToMove++;
                    }
                    if (stateHistory[i].midRow < rows[1])
                    {
                        numRowsToMove++;
                    }
                    if (stateHistory[i].botRow < rows[2])
                    {
                        numRowsToMove++;
                    }
                    if (numRowsToMove == 1)
                    {
                        if (bestMove == -1)
                        {
                            bestMove = i;
                        }
                        else if (stateHistory[i].sum / stateHistory[i].num <= stateHistory[bestMove].sum / stateHistory[bestMove].num)
                        {
                            bestMove = i;
                            //Console.WriteLine("Found a better move");
                        }
                    }
                }
            }
            if (bestMove != -1 && stateHistory.Count > 0)
            {
                rows[0] = stateHistory[bestMove].topRow;
                rows[1] = stateHistory[bestMove].midRow;
                rows[2] = stateHistory[bestMove].botRow;
                moveMade();
            }
            else
            {
                //Random move
                bool hasMoved = false;
                while (!hasMoved)
                {
                    int randRow = rand.Next(3);

                    if (rows[randRow] > 0)
                    {
                        int numRemoved = rand.Next(rows[randRow] - 1);
                        rows[randRow] -= numRemoved + 1;
                        hasMoved = true;
                        //Console.WriteLine("This is a random move, removing "+(numRemoved+1)+" pieces from row "+randRow);
                        moveMade();
                    }
                }
            }
        }
    }
}