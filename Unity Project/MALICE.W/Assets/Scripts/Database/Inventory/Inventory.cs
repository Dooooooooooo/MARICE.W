using System.Collections.Generic;
using UnityEngine;
using MW.Extensions;

namespace MW.Database.Inventory {
    public class Inventory {
        private readonly List<GameObject> m_MainWeapons     = new List<GameObject>();
        private readonly List<GameObject> m_SubWeapons      = new List<GameObject>();
        private readonly List<GameObject> m_ThrowingWeapons = new List<GameObject>();
        
        //追加用メソッド
        public void AddMainWeapon(GameObject weapon) {
            UnassignIfAvailable(weapon);
            m_MainWeapons.Add(weapon);
        }

        public void AddSubWeapon(GameObject weapon) {
            UnassignIfAvailable(weapon);
            m_SubWeapons.Add(weapon);
        }

        public void AddThrowingWeapon(GameObject weapon) {
            UnassignIfAvailable(weapon);
            m_ThrowingWeapons.Add(weapon);
        }
        
        //削除用メソッド
        public GameObject RemoveMainWeapon(int index) {
            return m_MainWeapons.TakeAt(index);
        }

        public GameObject RemoveSubWeapon(int index) {
            return m_SubWeapons.TakeAt(index);
        }

        public GameObject RemoveThrowingWeapon(int index) {
            return m_ThrowingWeapons.TakeAt(index);
        }
        
        //アンアサイン用のメソッド（おそらく不要、または過剰）
        // TODO Inventory::Add*()呼び出し側の管理を徹底。
        private void UnassignIfAvailable(GameObject weapon) {
            m_MainWeapons.Remove(weapon);
            m_SubWeapons.Remove(weapon);
            m_ThrowingWeapons.Remove(weapon);
        }
    };
};