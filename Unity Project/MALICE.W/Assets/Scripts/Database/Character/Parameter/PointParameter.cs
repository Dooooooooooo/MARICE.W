using System;
using UnityEngine;

namespace MW.Database.Character.Parameter
{
    public class PointParameter : ParameterBase
    {
        /* クラス図に沿ったメンバ変数*/
        
        private int m_Value = 0;
        private int m_Min   = 0;
        private int m_Max   = 0;
        
        /* アクセサ */
        
        public int Value {
            get { return m_Value; }
            set { SetValue(value);  }
        }

        public int Min {
            get { return m_Min; }
        }

        public int Max {
            get { return m_Max; }
        }

        private void SetValue(int value) {
            if (m_Min <= value && value <= m_Max)
                m_Value = value;
            else
                throw new ArgumentOutOfRangeException("Given value " + value.ToString() + " is not in the range.");
        }

        /* クラス図に沿ったメソッド */
        
        public void SafetyIncrease(int point) {
            //インクリメントした値を算出
            int value = m_Value + point;

            //範囲内なら上書き
            if (m_Min <= value && value <= m_Max)
                m_Value = value;
        }

        public void SafetyDecrease(int point) {
            SafetyIncrease(-point);
        }

        public void SetMinValue() {
            //m_Valueを最小値で書き換える、ってこと？
            m_Value = m_Min;
        }

        public void SetMaxValue() {
            //m_Valueを最大値で書き換える、ってこと？
            m_Value = m_Max;
        }
        
        /*
         //それとも...
         public void SetMinValue(int value) {
            //最小値を書き換える、ってこと？
            m_Min = value;
        }

        public void SetMaxValue(value) {
            //最大値を書き換える、ってこと？
            m_Max = value;
        }
         */
    }
}