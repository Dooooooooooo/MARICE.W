using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

using MW.Extensions;

namespace MW.Database.Character.State
{
    /// <summary>
    /// キャラクターの状態（State）を管理するクラス。
    /// </summary>
    public class StateProvider {
        //Stateを格納するリスト。
        private readonly List<State>                     m_States;
        
        private readonly Subject<StateChange>            m_StateChangeObservers;
        private readonly Subject<StateChange>            m_NewStateObservers;
        private readonly Dictionary<string, IDisposable> m_Disposer;
        
        
        public List<State> States => m_States;
        
        /// <summary>
        /// StateProviderのコンストラクタ。空の状態にて初期化される。
        /// </summary>
        public StateProvider() {
            m_States               = new List<State>();
            
            m_StateChangeObservers = new Subject<StateChange>();
            m_NewStateObservers    = new Subject<StateChange>();
        }
        
        /* IObserver<StateChange>への通知メソッド */
        
        /// <summary>
        /// オブザーバーに状態の変更を通知する。
        /// </summary>
        /// <param name="state">変更された状態</param>
        private void NotifyChange(State state) {
            m_StateChangeObservers.OnNext(new StateChange {
                State    = state,
                Provider = this
            });
        }
        
        /// <summary>
        /// オブザーバーに状態の追加を通知する。
        /// </summary>
        /// <param name="state">追加された状態</param>
        private void NotifyNew(State state) {
            m_NewStateObservers.OnNext(new StateChange {
                State    = state,
                Provider = this
            });
        }
        
        /* IObservable<StateChange>を返すメソッド */
        
        /// <summary>
        /// 状態の追加をIObservable<StateChange>としてObserveする。
        /// </summary>
        /// <param name="state">追加された状態</param>
        public IObservable<StateChange> NewStateAsObservable() {
            return m_NewStateObservers.AsObservable();
        }
        
        /// <summary>
        /// 状態の変更をIObservable<StateChange>としてObserveする。
        /// </summary>
        /// <param name="state">追加された状態</param>
        public IObservable<StateChange> StateChangeAsObservable() {
            return m_StateChangeObservers.AsObservable();
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
                
                //Stateの変更通知を受け取れるようにする
                m_Disposer[stateName] = state.AsObservable()
                                             .Subscribe(NotifyChange);
            
                //新たなStateが追加されたことを通知
                NotifyNew(state);
            } else { //既にあるときには
                //例外を出す
                Exception e = new ArgumentException("Item with same key '" + stateName + "' has already been added.");
                throw e;
            }
        }

        /// <summary>
        /// 状態を削除する。
        /// </summary>
        /// <param name="stateName">状態の名前</param>
        public bool DeleteState(string stateName) {
            return m_States.RemoveAll(s => {
                if (s.StateName == stateName) {
                    m_Disposer[stateName].Dispose();
                    return true;
                }
                else {
                    return false;
                }
            }) > 0;
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