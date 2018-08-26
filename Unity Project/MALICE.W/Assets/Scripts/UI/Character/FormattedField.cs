using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MW.UI {
	public class FormattedField<T> : MonoBehaviour, IUpdateObserver {
		UpdateObservable<T> _observable        = null;
		Func<T>             _receiver          = null;

		Func<T, string>     _formatter         = _ => "(empty)";
		bool		        _needsUpdate       = false;

		public FormattedField<T> Bind(Func<T> receiver) {
			_observable = null;
			_receiver   = receiver;
			return this;
		}

		public FormattedField<T> Bind(UpdateObservable<T> observable) {
			_observable = observable;
			_receiver   = () => _observable.GetValue();
			observable.Subscribe(this);
			return this;
		}

		public FormattedField<T> WithFormat(Func<T, string> formatter) {
			_formatter = formatter;
			return this;
		}

		public void NotifyUpdate() {
			_needsUpdate = true;
		}

		//Unityのインターフェイス
		void Start() {
		}

		void Update() {
			if(_needsUpdate) {
				if(_receiver == null)
					throw new NullReferenceException("Receiver is not set.");
				
				this.GetComponent<Text>().text = _formatter(_receiver());
				_needsUpdate = false;
			}
		}
	}
}

/*

var nameField = name.AddComponent<FormattedField<Character>>();
nameField.Bind(_ => chara)
		 .WithFormat(c => c.GetNAME());

nameField.NotifyUpdate();

 */