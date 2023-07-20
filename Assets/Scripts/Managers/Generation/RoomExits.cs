using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RoomExits : MonoBehaviour
{
    public Object[] potentialRooms;
    BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //TODO: pop up that asks the player if theyre sure
            GoToNextRoom();
        }
    }

    void GoToNextRoom()
    {
        int randomIndex = Random.Range(0, potentialRooms.Length);
        Object randomScene = potentialRooms[randomIndex];
        
        // TEMPORARY DELETE LATER
        if (potentialRooms.Length == GameManager.instance.visitedRooms.Count)
        {
            return;
        }

        if (GameManager.instance.visitedRooms.Contains(randomScene))
        {
            Debug.Log("player has been to this room");
            GoToNextRoom();
        }
        else
        {
            SceneManager.LoadScene(randomScene.name);
        }
    }
}
