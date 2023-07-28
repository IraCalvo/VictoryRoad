using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeChest : MonoBehaviour
{
    public GameObject item;
    public int itemQuantity;
    public Sprite openSprite;
    bool chestOpened;
    SpriteRenderer sr;
    Player player;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void InteractedWith()
    {
        player = FindObjectOfType<Player>();

        //make dialog appear here
        if (chestOpened == false)
        {
            for (int i = 0; i < itemQuantity; i++)
            {
                player.inventoryManager.AddItemToInventory(item);
            }

            sr.sprite = openSprite;
            chestOpened = true;
        }
        else 
        {
            Debug.Log("cehst already open");
        }

    }
}
