using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharactersAnimator
{
    public WeaponAnimations[] weaponAnimations;
    Dictionary<Equipment,AnimationClip[]> weaponAnimationsDict;
    protected override void Start() {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChange;

        weaponAnimationsDict = new Dictionary<Equipment, AnimationClip[]>();
        foreach(WeaponAnimations a in weaponAnimations) {
            weaponAnimationsDict.Add(a.weapon, a.clips);
        }
    }
    void OnEquipmentChange(Equipment newItem, Equipment oldItem) {
        if(newItem != null && newItem.equipmentSlot == EquipmentSlot.Weapon){
            animator.SetLayerWeight(1, 1);
            if(weaponAnimationsDict.ContainsKey(newItem)){
                currentAttackAnimSet = weaponAnimationsDict[newItem];
            }
        }
        else if(newItem == null && oldItem != null && oldItem.equipmentSlot == EquipmentSlot.Weapon){
            animator.SetLayerWeight(1, 0);
            currentAttackAnimSet = deafultAttackAnimSet;
        }

        if(newItem != null && newItem.equipmentSlot == EquipmentSlot.Shield)
            animator.SetLayerWeight(2, 1);
        else if(newItem == null && oldItem != null && oldItem.equipmentSlot == EquipmentSlot.Shield)
            animator.SetLayerWeight(2, 0);
    }

    [System.Serializable]
    public struct WeaponAnimations {
        public Equipment weapon;
        public AnimationClip[] clips;
    }
}
