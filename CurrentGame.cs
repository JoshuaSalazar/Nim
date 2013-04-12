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
                    int dif = totalStates - i;
                    dif -= dif % 2;
                    float val = totalStates*(1 - dif)/(totalStates);
                    values.Add(val);
                }
                else
                {
                    int dif = totalStates - i;
                    dif -= dif % 2;
                    float val = -totalStates * (1 - dif) / (totalStates);
                    values.Add(val);
                }
            }
        }
    }
}