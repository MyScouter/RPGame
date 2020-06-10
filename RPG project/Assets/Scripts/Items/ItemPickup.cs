using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact(){
        base.Interact();

        PickUp();
    }

    void PickUp() {
        Debug.Log("picking up " + item.name);
        
        if(Inventory.instance.Add(item))
            Destroy(gameObject);
    }
}
