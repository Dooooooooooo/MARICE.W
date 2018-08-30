using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using MW.UI;
using MW.UI.Extensions;

namespace MW.Database.Character.State {
    class StateProvider {
        private List<State> m_States = new List<State>();

        public StateProvider() {}
 
        public void AddState(State state) {
            string stateName = state.StateName;
            
            if(m_States.All(s => s.StateName != stateName)) {
                m_States.Add(state);
            } else {
                throw new ArgumentException("Item with same key '" + stateName + "' has already been added.");
            }
        }

        public bool DeleteState(string stateName) {
            return m_States.RemoveAll(s => s.StateName == stateName) > 0;
        }

        public State SearchState(string stateName) {
            return m_States.First(s => s.StateName == stateName);
        }
    };
};