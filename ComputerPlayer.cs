using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class ComputerPlayer : IPlayer
    {
        private String _name;
        private Random rand;
        public ComputerPlayer(String name){
            _name = name;
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
                        }
                        else if (game.stateList[i].getWeight() <= game.stateList[bestMove].getWeight()){
                            bestMove = i;
                        }
                    }
                }
            }
            if (bestMove != -1 && game.stateList.Count > 0){
                game.rows[0] = game.stateList[bestMove].TopRow;
                game.rows[1] = game.stateList[bestMove].MidRow;
                game.rows[2] = game.stateList[bestMove].BotRow;
                game.moveMade();
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