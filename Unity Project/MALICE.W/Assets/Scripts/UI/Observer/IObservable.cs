using System;
using System.Collections;
using System.Collections.Generic;

namespace MW.UI {
    public interface IObservable<T> 
        where T : IObservantBase {
        T Observe();
    }

    public interface IObserverBase {}
    public interface IObserver<_Observant> : IObserverBase
        where _Observant :  IObservantBase {
        void Handle(_Observant observant);
    }

    public interface IObservantBase {
        void Fire();
    }
    
    public interface IObservant<_Observer> : IObservantBase
        where _Observer : IObserverBase {
        void Subscribe(_Observer observer);
        void Unsubscribe(_Observer observer);
    }
}