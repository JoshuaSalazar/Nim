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
        }

        public void addState(int top, int mid, int bot){
            topRow.Add(top);
            midRow.Add(mid);
            botRow.Add(bot);
            totalStates++;
        }

        private void calcValues(){
            values = new List<float>();
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

        public List<int> TopRow{
            get { return topRow; }
        }

        public List<int> MidRow{
            get { return midRow; }
        }

        public List<int> BotRow{
            get { return botRow; }
        }

        public int TotalStates{
            get { return totalStates; }
        }

        public List<float> Values{
            get {
                if (values.Count < topRow.Count){
                    calcValues();
                }
                return values; 
            }
        }
    }
}