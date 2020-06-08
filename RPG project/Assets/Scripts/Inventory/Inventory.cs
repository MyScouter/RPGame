using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singelton
    public static Inventory instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory found");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    public List<Item> items = new List<Item>();
    public int capacity = 20;
    public bool Add(Item item)
    {
        if (!item.isDefaultItem) {
            if(items.Count >= capacity){
                Debug.Log("no more space");
                return false;
            }

            items.Add(item);

            if(OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if(OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
}
