namespace MW.Database.Weapon {
    public class ThrowingWeaponSpec : WeaponSpecBase {
        private int m_ItemCount      = 0;
        private int m_MaxItemCount   = 0;
        private int m_Firepower      = 0;
        private int m_FiringInterval = 0;
        
        public int ItemCount {
            get { return m_ItemCount; }
            private set { m_ItemCount = value; }
        }
        
        public int MaxItemCount {
            get { return m_MaxItemCount; }
            private set { m_MaxItemCount = value; }
        }
        
        public int Firepower {
            get { return m_Firepower; }
            private set { m_Firepower = value; }
        }
        
        public int FiringInterval {
            get { return m_FiringInterval; }
            private set { m_FiringInterval = value; }
        }
    }
}