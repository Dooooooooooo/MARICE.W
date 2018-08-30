using System;
using System.Collections;
using System.Collections.Generic;

namespace MW.UI {
    public interface IObservableBase {
        T Observe<T>() where T : IObservantBase;
    };

    public interface IObservable<T> : IObservableBase
        where T : IObservantBase {
    };

    public interface IObserverBase {}
    public interface IObserver<_Observant> : IObserverBase
        where _Observant :  IObservantBase {
        void Handle(_Observant observant);
    }

    public interface IObservantBase {
    }
    
    public interface IObservant<_Observer> : IObservantBase
        where _Observer : IObserverBase {
        void Fire();
        void Subscribe(_Observer observer);
        void Unsubscribe(_Observer observer);
    }
}