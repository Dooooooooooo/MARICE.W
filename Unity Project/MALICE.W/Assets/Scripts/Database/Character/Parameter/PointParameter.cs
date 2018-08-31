using UnityEngine;

namespace MW.Database.Character.Parameter
{
    public class PointParameter : ParameterBase
    {
        private int m_Value = 0;
        private int m_Min   = 0;
        private int m_Max   = 0;

        public int Value {
            get { return m_Value; }
        }

        public int Min {
            get { return m_Min; }
        }

        public int Max {
            get { return m_Max; }
        }

        public void SafetyIncrease(int point) {}
        
        public void SafetyDecrease(int point) {}
        
        public void SetMinValue() {}
        
        public void SetMaxValue() {}
    }
}