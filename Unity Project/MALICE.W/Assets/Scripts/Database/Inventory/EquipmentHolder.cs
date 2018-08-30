using UnityEngine;
using MW.System.Character.PlayerCharacter.Behaviour.AttackStrategy;
using NotImplementedException = System.NotImplementedException;

namespace MW.Database.Inventory {
    public class EquipmentHolder : IEquipmentInfo {
        private GameObject m_MainWeapon     = null;
        private GameObject m_SubWeapon      = null;
        private GameObject m_ThrowingWeapon = null;
        
        public GameObject GetMainWeapon() {
            return m_MainWeapon;
        }

        public GameObject GetSubWeapon() {
            return m_SubWeapon;
        }

        public GameObject GetThrowingWeapon() {
            return m_ThrowingWeapon;
        }
        
        void AssignMainWeapon(GameObject weapon) {
            UnassignMainWeapon();
            m_MainWeapon = weapon;
        }
        
        void AssignSubWeapon(GameObject weapon) {
            UnassignSubWeapon();
            m_SubWeapon = weapon;
        }
        
        void AssignThrowingWeapon(GameObject weapon) {
            UnassignThrowingWeapon();
            m_ThrowingWeapon = weapon;
        }

        void UnassignMainWeapon() {}
        void UnassignSubWeapon() {}
        void UnassignThrowingWeapon() {}
    };
};