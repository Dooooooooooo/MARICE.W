namespace MW.Database.Weapon {
    public abstract class WeaponSpecBase {
        private string m_WeaponName = "";

        public string WeaponName {
            get { return m_WeaponName; }
            private set { m_WeaponName = value; }
        }
    }
}