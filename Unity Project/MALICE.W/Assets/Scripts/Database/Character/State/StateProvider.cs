using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

using MW.UI.Extensions;

namespace MW.Database.Character
{
    /// <summary>
    /// キャラクターの状態（State）を管理するクラス。
    /// </summary>
    class StateProvider : IObservable<State> {
        //Stateを格納するリスト。
        private readonly List<State>            m_States;
        //IObserver<State>を格納するリスト。
        private readonly List<IObserver<State>> m_Observers;
        
        /// <summary>
        /// StateProviderのコンストラクタ。空の状態リストにて初期化される。
        /// </summary>
        public StateProvider() {
            m_States = new List<State>();
            m_Observers = new List<IObserver<State>>();
        }
        
        /* IObservable<T>の実装 */
        
        /// <summary>
        /// オブザーバーを購読することができる。IObservableのメソッド。
        /// </summary>
        /// <param name="observer"></param>
        /// <returns>IDisposableオブジェクト。Dispose()にて購読を解除できる。</returns>
        public IDisposable Subscribe(IObserver<State> observer) {
            m_Observers.Add(observer);
            return new Unsubscriber<State>(observer, m_Observers);
        }
        
        /* IObserver<State>への通知メソッド */
        
        /// <summary>
        /// オブザーバーに状態の変更を通知する。
        /// </summary>
        /// <param name="state">加わった状態</param>
        private void NotifyUpdate(State state) {
            lock(m_Observers) { //m_ObserversがUnsubscriberによって操作されているかもしれないので
                m_Observers.ForEach(observer => {
                    observer.OnNext(state);
                });
            }
        }
        
        /// <summary>
        /// オブザーバーにエラーを通知する。
        /// </summary>
        /// <param name="e">例外</param>
        private void NotifyError(Exception e) {
            lock(m_Observers) { //m_ObserversがUnsubscriberによって操作されているかもしれないので
                m_Observers.ForEach(observer => {
                    observer.OnError(e);
                });
            }
        }
        
        /* クラス図に沿った実装 */
        
        /// <summary>
        /// 状態を追加する。状態の名前が一意性を持つことを保証する。（つまり、状態の名前は識別子として機能する。）
        /// </summary>
        /// <param name="state">状態</param>
        public void AddState(State state) {
            string stateName = state.StateName;
            
            if(m_States.All(s => s.StateName != stateName)) { //同一名称のStateがなければ
                m_States.Add(state); //追加する
            } else { //無いときには
                //例外を出す
                Exception e = new ArgumentException("Item with same key '" + stateName + "' has already been added.");
                NotifyError(e);
                throw e;
            }

            //新たなStateが追加されたことを通知
            NotifyUpdate(state);
        }

        /// <summary>
        /// 状態を削除する。
        /// </summary>
        /// <param name="stateName">状態の名前</param>
        public bool DeleteState(string stateName) {
            return m_States.RemoveAll(s => s.StateName == stateName) > 0;
        }

        /// <summary>
        /// stateNameに一致する状態を返す。
        /// </summary>
        /// <param name="stateName">状態の名前</param>
        public State SearchState(string stateName) {
            //名前が一致したStateを返す
            return m_States.First(s => s.StateName == stateName);
        }
    };
};