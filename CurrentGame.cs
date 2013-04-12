using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nim
{
    class CurrentGame
    {
        public List<int> topRow;
        public List<int> midRow;
        public List<int> botRow;
        public int totalStates;
        public List<float> values;
        public CurrentGame()
        {
            topRow = new List<int>();
            midRow = new List<int>();
            botRow = new List<int>();
            values = new List<float>();
        }
        public void addState(int top, int mid, int bot)
        {
            topRow.Add(top);
            midRow.Add(mid);
            botRow.Add(bot);
            totalStates++;
        }
        public void calcValues()
        {
            for (int i = 0; i < totalStates; i++)
            {
                if ((i - totalStates) % 2 == 0)
                {
                    float value = -((totalStates - (totalStates - i) % 2)) / (float)totalStates;
                    values.Add(value);
                }
                else
                {
                    float value = ((totalStates - (totalStates - i) % 2)) / (float)totalStates;
                    values.Add(value);
                }
            }
        }
    }
}