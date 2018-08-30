using System;
using UnityEngine;
using UnityEngine.Events;

namespace MW.Database.Character.State {
    public class State {
        private string     m_StateName;
        private bool       m_HasDuration;
        private float      m_Duration;
        private float      m_RemainingDuration;
        private UnityEvent m_CallbackEvent;

        public string StateName {
            get { return m_StateName; }
        }

        public void UpdateDuration() {
        }

        public void RunCallbackEvent() {
        }

        public void Start() {

        }
    };
};