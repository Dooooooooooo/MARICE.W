using UnityEngine;

namespace MW.Database.Character.Parameter
{
    public class PointParameter : ParameterBase
    {
        [SerializeField] private int m_Value = 0;
        [SerializeField] private int m_Min   = 0;
        [SerializeField] private int m_Max   = 0;

        void SafetyIncrease(int point) {}
        
        void SafetyDecrease(int point) {}
        
        void SetMinValue() {}
        
        void SetMaxValue() {}
    }
}