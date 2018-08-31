using System;
using System.Collections.Generic;
using UniRx;

namespace MW.UI.Extensions {
    public class Unsubscriber<T> : IDisposable {
        private readonly List<IObserver<T>> m_Observers;
        private readonly IObserver<T>       m_Target;
        private bool                        m_Disposed = false;

        public Unsubscriber(IObserver<T> target, List<IObserver<T>> observers) {
            m_Observers = observers;
            m_Target    = target;
        }
        public void Dispose() {
            if(m_Disposed) return;

            lock(m_Observers) {
                m_Observers.Remove(m_Target);
            }
        }
    };
};