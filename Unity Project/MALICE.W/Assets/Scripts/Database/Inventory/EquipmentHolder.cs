using UnityEngine;
using MW.Database.Weapon;
using MW.System.Character.PlayerCharacter.Behaviour.AttackStrategy;

namespace MW.Database.Inventory {
    using Weapon = Weapon.Weapon;
    
    public class EquipmentHolder : IEquipmentInfo {
        private Weapon m_MainWeapon     = null;
        private Weapon m_SubWeapon      = null;
        private Weapon m_ThrowingWeapon = null;
        
        public GameObject GetMainWeapon() {
            return m_MainWeapon.GameObject;
        }

        public GameObject GetSubWeapon() {
            return m_SubWeapon.GameObject;
        }

        public GameObject GetThrowingWeapon() {
            return m_ThrowingWeapon.GameObject;
        }
        
        // TODO 武器のアサイン・アンアサイン処理
        void AssignMainWeapon(Weapon weapon) {
            UnassignMainWeapon();
            m_MainWeapon = weapon;
        }
        
        void AssignSubWeapon(Weapon weapon) {
            UnassignSubWeapon();
            m_SubWeapon = weapon;
        }
        
        void AssignThrowingWeapon(Weapon weapon) {
            UnassignThrowingWeapon();
            m_ThrowingWeapon = weapon;
        }
        
        void UnassignMainWeapon() {}
        void UnassignSubWeapon() {}
        void UnassignThrowingWeapon() {}
    };
};