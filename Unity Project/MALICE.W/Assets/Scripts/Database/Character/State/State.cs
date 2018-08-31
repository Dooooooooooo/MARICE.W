using System;
using UnityEngine;
using UnityEngine.Events;

namespace MW.Database.Character.State {
    public class State {
        private string     m_StateName          = "";
        private bool       m_HasDuration        = false;
        private float      m_Duration           = 0.0f;
        private float      m_RemainingDuration  = 0.0f;
        private UnityEvent m_CallbackEvent      = null;

        public string StateName {
            get { return m_StateName; }
        }

        public void UpdateDuration() { //なぜprivate?
        }

        public void RunCallbackEvent() { //なぜprivate?
        }

        public void Start() { //なぜprivate?
        }
    };
};