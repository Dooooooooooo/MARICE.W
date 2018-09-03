using UnityEngine;

namespace MW.System.Character.PlayerCharacter.Behaviour.AttackStrategy {
    public interface IEquipmentInfo {
        GameObject GetMainWeapon();
        GameObject GetSubWeapon();
        GameObject GetThrowingWeapon();
    }
}