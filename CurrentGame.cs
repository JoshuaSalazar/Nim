using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class CurrentGame
    {
        private List<int> topRow;
        private List<int> midRow;
        private List<int> botRow;
        private int totalStates;
        private List<float> values;

        public CurrentGame(){
            topRow = new List<int>();
            midRow = new List<int>();
            botRow = new List<int>();
            values = new List<float>();
        }

        public void addState(int top, int mid, int bot){
            topRow.Add(top);
            midRow.Add(mid);
            botRow.Add(bot);
            totalStates++;
        }

        private void calcValues(){
            for (int i = 0; i < totalStates; i++){
                if ((i - totalStates) % 2 == 0){
                    float value = -((totalStates - (totalStates - i) % 2)) / (float)totalStates;
                    values.Add(value);
                }else{
                    float value = ((totalStates - (totalStates - i) % 2)) / (float)totalStates;
                    values.Add(value);
                }
            }
        }

        public IList<int> TopRow
        {
            get { return topRow; }
        }

        public IList<int> MidRow
        {
            get { return midRow; }
        }

        public IList<int> BotRow
        {
            get { return botRow; }
        }

        public int TotalStates{
            get { return totalStates; }
        }

        public IList<float> Values
        {
            get {
                if (values.Count < topRow.Count){
                    calcValues();
                }
                return values; 
            }
        }
    }
}