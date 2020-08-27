using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory");
            return;
        }
        instance = this;
    }

    public List<item> items = new List<item>();

    public bool Add(item m_item)
    {
        if (!m_item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("out of room");
                return false;
            }
            else
                items.Add(m_item);
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
        
    }

    public void Remove(item m_item)
    {
        items.Remove(m_item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

    }

    public void CreateInventory()
    {
        Debug.Log("inventory Created");
    }
}

