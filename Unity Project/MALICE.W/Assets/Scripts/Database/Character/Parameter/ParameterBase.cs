using UnityEngine;

namespace MW.Database.Character.Parameter
{
    public abstract class ParameterBase
    {
        private string m_ParameterName = "";

        public  string ParameterName   => m_ParameterName;
    }
}