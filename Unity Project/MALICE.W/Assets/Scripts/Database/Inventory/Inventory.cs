using System.Collections.Generic;
using System.Linq;
using MW.Database.Weapon;
using MW.Extensions;
using UnityEngine;


namespace MW.Database.Inventory {
    using Weapon = MW.Database.Weapon.Weapon;
    
    public class Inventory {
        private readonly List<Weapon> m_MainWeapons     = new List<Weapon>();
        private readonly List<Weapon> m_SubWeapons      = new List<Weapon>();
        private readonly List<Weapon> m_ThrowingWeapons = new List<Weapon>();

        private static Inventory      m_Inventory       = null;
        
        /* InventoryをSingletonにしてみる */   
        
        public static Inventory GetInventory() {
            return m_Inventory ?? (m_Inventory = new Inventory());
        }
        
        private Inventory() {}
        
        //追加用メソッド
        public void AddMainWeapon(Weapon weapon) {
            UnassignIfAvailable(weapon);
            m_MainWeapons.Add(weapon);
        }

        public void AddSubWeapon(Weapon weapon) {
            UnassignIfAvailable(weapon);
            m_SubWeapons.Add(weapon);
        }

        public void AddThrowingWeapon(Weapon weapon) {
            UnassignIfAvailable(weapon);
            m_ThrowingWeapons.Add(weapon);
        }
        
        //削除用メソッド
        public Weapon RemoveMainWeapon(int index) {
            return m_MainWeapons.TakeAt(index);
        }

        public Weapon RemoveSubWeapon(int index) {
            return m_SubWeapons.TakeAt(index);
        }

        public Weapon RemoveThrowingWeapon(int index) {
            return m_ThrowingWeapons.TakeAt(index);
        }
        
        //GameObject　-> Weapon紐付け
        public Weapon FindWeaponFor(GameObject gameObject) {
            return m_MainWeapons.Concat(m_SubWeapons)
                                .Concat(m_ThrowingWeapons)
                                .First(obj => obj == gameObject);
        }
        
        //アンアサイン用のメソッド（おそらく不要、または過剰）
        // TODO Inventory::Add*()呼び出し側の管理を徹底。
        private void UnassignIfAvailable(Weapon weapon) {
            m_MainWeapons.Remove(weapon);
            m_SubWeapons.Remove(weapon);
            m_ThrowingWeapons.Remove(weapon);
        }
    };
};