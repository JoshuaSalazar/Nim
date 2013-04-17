using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class ComputerPlayer : IPlayer
    {
        private Random rand;
        public ComputerPlayer(){
            rand = new Random();
        }
        public bool makeMove(GameManager game)
        {
            int bestMove = -1;
            for (int i = 0; i < game.stateList.Count; i++)
            {
                if (game.stateList[i].TopRow <= game.rows[0] &&
                    game.stateList[i].MidRow <= game.rows[1] &&
                    game.stateList[i].BotRow <= game.rows[2]){
                    int numRowsToMove = 0;
                    if (game.stateList[i].TopRow < game.rows[0])
                    {
                        numRowsToMove++;
                    }
                    if (game.stateList[i].MidRow < game.rows[1])
                    {
                        numRowsToMove++;
                    }
                    if (game.stateList[i].BotRow < game.rows[2]){
                        numRowsToMove++;
                    }
                    if (numRowsToMove == 1){
                        if (bestMove == -1){
                            bestMove = i;
                        }else if (game.stateList[i].getWeight() <= game.stateList[bestMove].getWeight()){
                            bestMove = i;
                        }
                    }
                }
            }
            if (bestMove != -1 && game.stateList.Count > 0){
                int topDiff = game.rows[0] - game.stateList[bestMove].TopRow;
                int midDiff = game.rows[1] - game.stateList[bestMove].MidRow;
                int botDiff = game.rows[2] - game.stateList[bestMove].BotRow;
                if (topDiff != 0){
                    game.makeMove(0, topDiff);
                    //Console.WriteLine("Computer removed " + topDiff + " pieces from row: 0");
                } else if (midDiff != 0){
                    game.makeMove(1, midDiff);
                    //Console.WriteLine("Computer removed " + midDiff + " pieces from row: 1");
                }
                else if (botDiff != 0)
                {
                    game.makeMove(2, botDiff);
                    //Console.WriteLine("Computer removed " + botDiff + " pieces from row: 2");
                }
            }else{
                bool hasMoved = false;
                while (!hasMoved){
                    int randRow = rand.Next(3);
                    if (game.rows[randRow] > 0){
                        int numRemoved = rand.Next(game.rows[randRow] - 1);
                        game.rows[randRow] -= numRemoved + 1;
                        hasMoved = true;
                        game.moveMade();
                    }
                }
            }
            return true;
        }
    }
}