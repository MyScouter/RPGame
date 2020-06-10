using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singelton

    public static EquipmentManager instance;


    private void Awake()
    {
        instance = this;
    }

    #endregion
    public Equipment[] defaultItems;
    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;
    public SkinnedMeshRenderer targetMesh;
    public Transform shield;
    public Transform sword;
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        EquipDefaultItems();
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;
        
        Equipment oldItem = Unequip(slotIndex);
        

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        SetEquipmentBlendShapes(newItem, 100);
        currentEquipment[slotIndex] = newItem;

        SkinnedMeshRenderer newMash = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        currentMeshes[slotIndex] = newMash;

        if(newItem != null && newItem.equipmentSlot == EquipmentSlot.Weapon)
        {
            newMash.rootBone = sword;

        }else if (newItem != null && newItem.equipmentSlot == EquipmentSlot.Shield)
        {
            newMash.rootBone = shield;

        }
        else
        {
            newMash.transform.parent = targetMesh.transform;
            newMash.bones = targetMesh.bones;
            newMash.rootBone = targetMesh.rootBone;
        }
    }

    public Equipment Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            Equipment oldItem = currentEquipment[slotIndex];
            SetEquipmentBlendShapes(oldItem, 0);
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItems();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
    void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach (EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
        }
    }
    void EquipDefaultItems()
    {
        foreach (Equipment item in defaultItems)
        {
            Equip(item);
        }
    }
}
