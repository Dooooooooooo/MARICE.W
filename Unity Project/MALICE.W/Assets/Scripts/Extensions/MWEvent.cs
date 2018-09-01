using System;
using UniRx;

namespace MW.Extensions {
    public class MWEvent<T> {
        private event Action<T> m_EventHandler = t => {};
        private Subject<T>      m_Observer;
        
        public MWEvent() {
            m_Observer = new Subject<T>();
            m_Observer.Subscribe(m_EventHandler);
        }

        private void AssignEvent(Action<T> action) {
            m_EventHandler += action;
        }
        
        private void UnassignEvent(Action<T> action) {
            m_EventHandler -= action;
        }

        public void Invoke(T t) {
            m_Observer.OnNext(t);
        }

        public IObservable<T> AsObservable() {
            return m_Observer.AsObservable();
        }
        
        //MwEvent<T>, Action<T>での演算子オーバーロード
        public static MWEvent<T> operator+(MWEvent<T> mwEvent, Action<T> action) {
            mwEvent.AssignEvent(action);
            return mwEvent;
        }
        
        public static MWEvent<T> operator-(MWEvent<T> mwEvent, Action<T> action) {
            mwEvent.UnassignEvent(action);
            return mwEvent;
        }
        
        //MwEvent<T>, MwEvent<T>どうしの演算子オーバーロード
        public static MWEvent<T> operator+(MWEvent<T> mwEvent1, MWEvent<T> mwEvent2) {
            if (mwEvent1 == mwEvent2) return mwEvent1;
            mwEvent1.AssignEvent(mwEvent2.Invoke);
            return mwEvent1;
        }
        
        public static MWEvent<T> operator-(MWEvent<T> mwEvent1, MWEvent<T> mwEvent2) {
            if (mwEvent1 == mwEvent2) return mwEvent1;
            mwEvent1.UnassignEvent(mwEvent2.Invoke);
            return mwEvent1;
        }
    }
}