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
            for (int i = 0; i < game.stateList.Count; i++)
            {
                if (game.stateList[i].TopRow <= game.rows[0] &&
                    game.stateList[i].MidRow <= game.rows[1] &&
                    game.stateList[i].BotRow <= game.rows[2])
                {
                    int numrowsToMove = 0;
                    if (game.stateList[i].TopRow < game.rows[0])
                    {
                        numrowsToMove++;
                    }
                    if (game.stateList[i].MidRow < game.rows[1])
                    {
                        numrowsToMove++;
                    }
                    if (game.stateList[i].BotRow < game.rows[2])
                    {
                        numrowsToMove++;
                    }
                    if (numrowsToMove == 1)
                    {
                        if (bestMove == -1)
                        {
                            bestMove = i;
                        }
                        else if (game.stateList[i].getWeight() <= game.stateList[bestMove].getWeight())
                        {
                            bestMove = i;
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
    }
}