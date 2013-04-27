using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class ComputerPlayer : IPlayer
    {
        private Random rand;
        public ComputerPlayer()
        {
            rand = new Random();
        }
        public bool makeMove(GameManager game)
        {
            int bestMove = -1;
            for (int numState = 0; numState < game.stateList.Count; numState++)
            {
                if (validMove(game, numState))
                {
                    if (numRowsToMove(game, numState) == 1)
                    {
                        if (isBestMove(game, numState, bestMove))
                        {
                            bestMove = numState;
                        }
                    }
                }
            }

            if (bestMove != -1 && game.stateList.Count > 0)
            {
                int topDiff = game.rows[0] - game.stateList[bestMove].TopRow;
                int midDiff = game.rows[1] - game.stateList[bestMove].MidRow;
                int botDiff = game.rows[2] - game.stateList[bestMove].BotRow;
                if (topDiff != 0)
                {
                    game.makeMove(0, topDiff);
                }
                else if (midDiff != 0)
                {
                    game.makeMove(1, midDiff);
                }
                else if (botDiff != 0)
                {
                    game.makeMove(2, botDiff);
                }
			}
            else
            {
                bool hasMoved = false;
                while (!hasMoved)
                {
                    int randRow = rand.Next(3);
                    int numToRemove = rand.Next(game.rows[randRow]+1);
                    hasMoved = game.makeMove(randRow, numToRemove);
                }
            }
            return true;
        }

        private bool validMove(GameManager game, int numState)
        {
            return (game.stateList[numState].TopRow <= game.rows[0] &&
                    game.stateList[numState].MidRow <= game.rows[1] &&
                    game.stateList[numState].BotRow <= game.rows[2]);
        }

        private bool isBestMove(GameManager game, int numState, int bestMove)
        {
            return (bestMove == -1 || game.stateList[numState].getWeight() <= game.stateList[bestMove].getWeight());
        }

        private int numRowsToMove(GameManager game, int numState)
        {
            int numrowsToMove = 0;
            if (game.stateList[numState].TopRow < game.rows[0])
            {
                numrowsToMove++;
            }
            if (game.stateList[numState].MidRow < game.rows[1])
            {
                numrowsToMove++;
            }
            if (game.stateList[numState].BotRow < game.rows[2])
            {
                numrowsToMove++;
            }
            return numrowsToMove;
        }
    }
}