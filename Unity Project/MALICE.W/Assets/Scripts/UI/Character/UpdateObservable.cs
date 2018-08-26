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
        List<IUpdateObserver> _observers         = new List<IUpdateObserver>();
        List<Action<T>>       _observerFunctions = new List<Action<T>>();
        List<Action<T>>       _observerFOnce     = new List<Action<T>>();
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
            foreach(var f in _observerFunctions) f(_item);
            foreach(var f in _observerFOnce) f(_item);
            _observerFOnce = new List<Action<T>>();
        }
        public void Subscribe(IUpdateObserver observer) {
            _observers.Add(observer);
        }

        public void Unsubscribe(IUpdateObserver observer) {
            _observers.Remove(observer);
        }

        public void Attach(Action<T> f) {
            _observerFunctions.Add(f);
        }

        public void AttachOnce(Action<T> f) {
            _observerFOnce.Add(f);
        }

        public void Deattach(Action<T> f) {
            _observerFunctions.Remove(f);
        }

    };
};