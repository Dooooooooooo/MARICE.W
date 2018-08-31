using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using MW.UI;
using MW.UI.Extensions;

namespace MW.Database.Character {
    /// <summary>
    /// キャラクターの状態（State）を管理するクラス。
    /// </summary>
    class StateProvider {
        //Stateを格納するリスト。
        private readonly List<State> m_States;

        public StateProvider() {
            m_States = new List<State>();
        }

        /// <summary>
        /// 状態を追加する。状態の名前が一意性を持つことを保証する。（つまり、状態の名前は識別子として機能する。）
        /// </summary>
        /// <param name="state">状態</param>
        public void AddState(State state) {
            string stateName = state.StateName;
            
            if(m_States.All(s => s.StateName != stateName)) { //同一名称のStateがなければ
                m_States.Add(state); //追加する
            } else { //無いときには例外を出す
                throw new ArgumentException("Item with same key '" + stateName + "' has already been added.");
            }

            // TODO Stateを監視対象に置く
        }

        /// <summary>
        /// 状態を削除する。
        /// </summary>
        /// <param name="stateName">状態の名前</param>
        public bool DeleteState(string stateName) {
            return m_States.RemoveAll(s => {
                if(s.StateName == stateName) {
                    // TODO 削除処理
                    return true;
                } else {
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