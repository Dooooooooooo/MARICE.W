using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MW.UI {
    /// <summary>
    /// recieverから得た値をformatterに従って表示します。
    /// UnityはジェネリックなMonoBehaviourに対応していないので、継承してからスクリプトとしてアサインするように。
    /// </summary>

    // TODO ジェネリックなMonoBehaviourとUniRxは相性が悪いので、いずれは廃止したい。IObservable.csもその遺物。

    public class FormattedField<T> : MonoBehaviour {
        UpdateObservant<T>  _observable        = null;
        Func<T>             _receiver          = null;

        Func<T, string>     _formatter         = _ => "(empty)";
        bool		        _needsUpdate       = false;

        public FormattedField<T> Bind(Func<T> receiver) {
            _observable = null;
            _receiver   = receiver;
            return this;
        }

        public FormattedField<T> WithFormat(Func<T, string> formatter) {
            _formatter = formatter;
            return this;
        }

        public void RequestUpdate() {
            _needsUpdate = true;
        }
        void Update() {
            //アップデートが不要なら関数から抜ける
            if (!_needsUpdate) return;
            
            //レジーバーが設定されてないならエラーを吐く
            if(_receiver == null)
                throw new NullReferenceException("Receiver is not set.");
            
            //フォーマッターに従ってフィールドの中身を入れ替える
            this.GetComponent<Text>().text = _formatter(_receiver());
            
            //アップデートのフラグを外す
            _needsUpdate = false;
        }
    }
}
