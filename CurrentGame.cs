using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class CurrentGame
    {
        private List<State> states;
        private List<float> values;

        public CurrentGame(){
            values = new List<float>();
            states = new List<State>();
        }

        public void addState(int top, int mid, int bot){
            states.Add(new State(top, mid, bot));
        }

        private void calcValues(){
            for (int i = 0; i < states.Count; i++){
                float weight = ((states.Count - (states.Count - i) % 2)) / (float)states.Count;
                if ((i - states.Count) % 2 == 0){
                    values.Add(-weight);
                }else{
                    values.Add(weight);
                }
            }
        }

        public List<State> States
        {
            get { return states; }
            set { states = value; }
        }

        public IList<float> Values
        {
            get {
                if (values.Count < states.Count)
                {
                    calcValues();
                }
                return values; 
            }
        }
    }
}