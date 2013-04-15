using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class State
    {
        private int topRow;
        private int midRow;
        private int botRow;
        private int num;
        private float sum;

        public State(int top, int mid, int bot){
            topRow = top;
            midRow = mid;
            botRow = bot;
            num = 0;
        }

        public void addInstance(float value){
            num++;
            sum += value;
        }

        public int TopRow{
            get { return topRow; }
        }
        public int MidRow{
            get { return midRow; }
        }
        public int BotRow{
            get { return botRow; }
        }
        public float getWeight(){
            return sum / (float)num;
        }
    }
}
