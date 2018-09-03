using UniRx;
using UnityEngine.Events;
using System;

namespace MW.Database.Character.State {
    using Time = UnityEngine.Time;
    
    public class State : IObservable<State> {
        /* クラス図より・メンバ変数 */
        private string         m_StateName          = null;
        private bool           m_HasDuration        = false;
        private float          m_Duration           = 0.0f;
        private float          m_RemainingDuration  = 0.0f;
        private UnityEvent     m_CallbackEvent      = null;

        private Subject<State> m_StateChanged;
        private bool           m_IsActive           = false;
        
        public string StateName {
            get {
                if (m_StateName == null)
                    throw new NullReferenceException("MW.Database.Character.State name has not been set.");
                
                return m_StateName;
            }
            set {
                if (m_StateName == null)
                    m_StateName = value;
                else
                    throw new InvalidOperationException("MW.Database.Character.State may not be renamed.");
            }
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
            set {
                m_RemainingDuration = value;
                m_IsActive          = IsDurationValid(); //m_RemainingDurationが有効なら活性化する
                NotifyUpdate();
            }
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
        
        /* こまごまとしたサブルーチン */
        
        private bool IsDurationValid() {
            //1フレーム以下なら非アクティブにする
            return Math.Abs(m_RemainingDuration) > (1 / 60.0);
        }
        
        /* クラス図の記載による */

        private void UpdateDuration() {
            if (!m_HasDuration || !m_IsActive)
                return;

            //残り時間を計算して、m_RemainingDurationが有効かどうか調べる
            m_RemainingDuration = Math.Max(0, m_RemainingDuration - Time.deltaTime);
            m_IsActive = IsDurationValid();
            
            //無効になったら、m_RemainingDurationを0にする
            if(!m_IsActive)
                m_RemainingDuration = 0;
            
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