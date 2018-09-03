using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MW.UI {
    public class UpdateObservant<T> {
        List<Action<T>>       _observerFunctions = new List<Action<T>>();
        List<Action<T>>       _observerFOnce     = new List<Action<T>>();
        T                     _item;

        public UpdateObservant(T t) {
            _item = t;
        }

        public T GetValue() {
            return _item;
        }
        public void SetValue(T t) {
            _item = t;
            NotifyUpdate();
        }

        public void Fire() {
            NotifyUpdate();
        }

        public void NotifyUpdate() {
            foreach(var f in _observerFunctions) f(_item);
            foreach(var f in _observerFOnce)     f(_item);
            _observerFOnce = new List<Action<T>>();
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
