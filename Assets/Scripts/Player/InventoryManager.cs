using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<GameObject> currentRunItemInventory = new List<GameObject>();
    public List<GameObject> persistingItemIntentory = new List<GameObject>();
    public List<GameObject> totalItemInventroy = new List<GameObject>();

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void AddItemToInventory(GameObject item)
    {
        currentRunItemInventory.Add(item);
        totalItemInventroy.Add(item);
    }
}
