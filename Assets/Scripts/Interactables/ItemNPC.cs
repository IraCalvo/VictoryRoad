using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNPC : MonoBehaviour
{
    public GameObject itemToGiveToPlayer;
    public bool itemGiven;
    public string dialogToSayToThePlayerInitially;
    public string dialogToSayToThePlayerAfterItemGiven;
    Player player;

    public void InteractedWith()
    {
        player = FindObjectOfType<Player>();

        if (itemGiven == false)
        {
            Debug.Log(dialogToSayToThePlayerInitially);
            player.inventoryManager.AddItemToInventory(itemToGiveToPlayer);
            itemGiven = true;
        }
        else
        {
            Debug.Log(dialogToSayToThePlayerAfterItemGiven);
        }
    }
}
