using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace MW.Database.Character.State {
    public class State : IObservable<State> {
        /* クラス図より・メンバ変数 */
        private string         m_StateName          = "";
        private bool           m_HasDuration        = false;
        private float          m_Duration           = 0.0f;
        private float          m_RemainingDuration  = 0.0f;
        private UnityEvent     m_CallbackEvent      = null;

        private Subject<State> m_StateChanged;
        private bool           m_IsActive           = false;
        
        public string StateName {
            get { return m_StateName; }
        }

        public bool HasDuration {
            get { return m_HasDuration; }
            set { m_HasDuration = value; NotifyUpdate(); }
        }
        
        public float Duration {
            get { return m_Duration; }
            set { m_Duration = value; NotifyUpdate(); }
        }
        
        public float RemainingDuration {
            get { return m_RemainingDuration; }
            set { m_RemainingDuration = value; NotifyUpdate(); }
        }
        
        public UnityEvent CallbackEvent {
            get { return m_CallbackEvent; }
            set { m_CallbackEvent = value; NotifyUpdate(); }
        }
        
        public State() {
            m_StateChanged = new Subject<State>();
        }

        private void NotifyUpdate() {
            m_StateChanged.OnNext(this);
        }
        
        /* IObservable<T>の機能 */
        
        public IDisposable Subscribe(IObserver<State> observer) {
            return m_StateChanged.Subscribe(observer);
        }

        public IObservable<State> AsObservable() {
            return m_StateChanged.AsObservable();
        }
        
        /* クラス図の記載による */

        private void UpdateDuration() {
            if (!HasDuration || !m_IsActive) return;

            //残り時間を計算して、1フレーム以下なら非アクティブにする
            m_RemainingDuration = Math.Max(0, m_RemainingDuration - Time.deltaTime);
            m_IsActive = Math.Abs(m_RemainingDuration) > (1 / 60.0);

            //更新を知らせる
            NotifyUpdate();
        }

        private void RunCallbackEvent() {
            //m_CallbackEvent?.Invoke();
        }

        private void Start() {
        }
    };
};