using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MW.UI {
    public interface IUpdateObserver
    {
        void NotifyUpdate();
    }
    public class UpdateObservable<T> {
        List<IUpdateObserver> _observers = new List<IUpdateObserver>();
        T                     _item;

        public UpdateObservable(T t) {
            _item = t;
        }

        public T GetValue() {
            return _item;
        }
        public void SetValue(T t) {
            _item = t;
            NotifyUpdate();
        }

        public void NotifyUpdate() {
            foreach(var a in _observers) a.NotifyUpdate();
        }
        public void Subscribe(IUpdateObserver observer) {
            _observers.Add(observer);
        }

        public void Unsubscribe(IUpdateObserver observer) {
            _observers.Remove(observer);
        }
    };
};