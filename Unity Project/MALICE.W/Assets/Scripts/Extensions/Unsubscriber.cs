using System;
using System.Collections.Generic;
using UniRx;

namespace MW.Extensions {
    public class Unsubscriber<T> : IDisposable {
        private readonly List<IObserver<T>> m_Observers;
        private readonly IObserver<T>       m_Target;
        private bool                        m_Disposed = false;

        public Unsubscriber(IObserver<T> target, List<IObserver<T>> observers) {
            m_Observers = observers;
            m_Target    = target;
        }
        public void Dispose() {
            //既に破棄されている場合は、やめる
            if(m_Disposed) return;
            
            //他のスレッドで操作できないようにしてから、削除
            lock(m_Observers) {
                m_Observers.Remove(m_Target);
            }
            //破棄されているというフラグを入れる
            m_Disposed = true;
        }
    };
};