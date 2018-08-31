using UnityEngine;

namespace MW.Database.Character.Parameter
{
    public class PointParameter : ParameterBase
    {
        private int m_Value = 0;
        private int m_Min   = 0;
        private int m_Max   = 0;

        public void SafetyIncrease(int point) {}
        
        public void SafetyDecrease(int point) {}
        
        public void SetMinValue() {}
        
        public void SetMaxValue() {}
    }
}