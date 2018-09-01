using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

public class CharacterField : MonoBehaviour, IObserver<Character> {
    Func<Character>             m_Receiver;
    Func<Character, string>     m_Formatter = _ => "(empty)";
    private IDisposable         m_Unsubscriber;
    private bool                m_NeedsUpdate;
    private Text                m_TextField;
    
    public CharacterField Bind(Func<Character> receiver) {
        m_Unsubscriber?.Dispose();
        m_Receiver   = receiver;
        return this;
    }

    public CharacterField Bind(IObservable<Character> observable) {
        m_Unsubscriber?.Dispose();
        m_Unsubscriber = observable.Subscribe(this);
        return this;
    }
    
    public CharacterField WithFormat(Func<Character, string> formatter) {
        m_Formatter = formatter;
        return this;
    }
    
    public void RequestUpdate() {
        m_NeedsUpdate = true;
        
        //強制更新をかけてみる
        Update();
    }
    
    public void RequestLazyUpdate() {
        m_NeedsUpdate = true;
    }

    void Start() {
        //既に取ってきていると楽なのでは？
        m_TextField = this.GetComponent<Text>();
    }
    
    void Update() {
        //アップデートが不要なら関数から抜ける
        if (!m_NeedsUpdate) return;
        
        //レジーバーが設定されてないならエラーを吐く
        if(m_Receiver == null)
            throw new NullReferenceException("Receiver is not set.");
        
        //フォーマッターに従ってフィールドの中身を入れ替える
        if (m_TextField != null) {
            m_TextField.text = m_Formatter(m_Receiver());
            
            //入れ替えに成功したら、アップデートのフラグを外す
            m_NeedsUpdate = false;
        }
    }

    public void OnCompleted() {
        //do nothing
    }

    public void OnError(Exception error) {
        //丸投げ
        throw error;
    }

    public void OnNext(Character value) {
        m_NeedsUpdate = true;
    }
}