using System;
using MW.Database.Inventory;
using UnityEngine;

namespace MW.Database.Weapon {
    public class Weapon {
        private readonly WeaponSpecBase  m_WeaponSpec;
        private readonly GameObject      m_GameObj;
        private          EquipmentHolder m_EquippedBy;
        
        public WeaponSpecBase WeaponSpec => m_WeaponSpec;
        public GameObject     GameObject => m_GameObj;

        public bool IsEquipped { get; private set; }
        
        public Weapon(WeaponSpecBase weaponSpecification,
                      GameObject correspondingGameObject) {
            m_WeaponSpec = weaponSpecification;
            m_GameObj    = correspondingGameObject;
        }
        
        /* GameObjectへの暗黙による型変換 */
        
        public static implicit operator GameObject(Weapon self) {
            //絶対誰か一人はやる...たぶん。知らない。
            Debug.Log("MW.Database.Weapon is not GameObject!!"); 
            return self.m_GameObj;
        }
    }
}