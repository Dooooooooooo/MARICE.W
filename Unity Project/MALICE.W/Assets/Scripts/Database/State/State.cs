using System;
using UnityEngine;
using UnityEngine.Events;

namespace MW.Database {
    public class State {
        [SerializeField] private string     m_StateName;
        [SerializeField] private bool       m_HasDuration;
        [SerializeField] private float      m_Duration;
        [SerializeField] private float      m_RemainingDuration;
        [SerializeField] private UnityEvent m_CallbackEvent;

        public string StateName {
            get { return m_StateName; }
        }

        public State() {
            //initializer
        }

        public void UpdateDuration() {
        }

        public void RunCallbackEvent() {
        }

        public void Start() {

        }
    };
};