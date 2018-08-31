using UnityEngine;

namespace MW.Database.Weapon {
    public class SubWeaponSpec : WeaponSpecBase {
        private int   m_MaxLoadedBulletsCount = 0;
        private int   m_MagazinesCount        = 0;
        private int   m_MaxMagazinesCount     = 0;
        private int   m_Firepower             = 0;
        private float m_FiringInterval        = 0.0f;
        private int   m_Recoil                = 0;
        
        public int MaxLoadedBulletsCount {
            get { return m_MaxLoadedBulletsCount; }
            private set { m_MaxLoadedBulletsCount = value; }
        }
        
        public int MagazinesCount {
            get { return m_MagazinesCount; }
            private set { m_MagazinesCount = value; }
        }
        
        public int MaxMagazinesCount {
            get { return m_MaxMagazinesCount; }
            private set { m_MaxMagazinesCount = value; }
        }
        
        public int Firepower {
            get { return m_Firepower; }
            private set { m_Firepower = value; }
        }
        
        public float FiringInterval {
            get { return m_FiringInterval; }
            private set { m_FiringInterval = value; }
        }
        
        public int Recoil {
            get { return m_Recoil; }
            private set { m_Recoil = value; }
        }
    }
}