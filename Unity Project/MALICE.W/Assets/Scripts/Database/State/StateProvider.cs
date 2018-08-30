using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using MW.UI;
using MW.UI.ListExtension;

namespace MW.Database {
    class StateProvider {
        List<State> _states = new List<State>();

        public StateProvider() {}
 
        public void AddState(State state) {
            String _stateName = state.StateName;
            if(_states.All(s => s.StateName != _stateName)) {
                _states.Add(state);
            } else {
                throw new ArgumentException(String.Format("Item with same key '%s' has already been added.", _stateName));
            }
        }

        public bool DeleteState(string stateName) {
            return _states.RemoveAll(s => s.StateName == stateName) > 0;
        }

        public State SearchState(string stateName) {
            return _states.Where(s => s.StateName == stateName)
                          .First();
        }
    };
};